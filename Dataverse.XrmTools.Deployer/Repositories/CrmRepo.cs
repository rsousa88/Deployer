﻿// System
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;

// Microsoft
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Tooling.Connector;

// Deployer
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;
using Dataverse.XrmTools.Deployer.RepoInterfaces;

namespace Dataverse.XrmTools.Deployer.Repositories
{
    public class CrmRepo : ICrmRepo
    {
        #region Private Fields
        private readonly CrmServiceClient _target;
        private readonly CrmServiceClient _source;
        private readonly Logger _logger;
        private readonly BackgroundWorker _worker;
        #endregion Private Fields

        #region Constructors
        /// <summary>
        /// Creates an instance of the CRM Repository using the specified CRM client.
        /// </summary>
        /// <param name="target">Target instance client</param>
        /// <param name="logger">Instantiated Logger object</param>
        /// <param name="source">[Optional] Source instance client</param>
        /// <param name="worker">[Optional] Async background worker</param>
        public CrmRepo(CrmServiceClient target, Logger logger, CrmServiceClient source = null, BackgroundWorker worker = null)
        {
            _target = target;
            _logger = logger;
            _source = source;
            _worker = worker;
        }
        #endregion Constructors

        #region Interface Methods
        public IEnumerable<SolutionHistory> GetSolutionHistory(ConnectionType connType = ConnectionType.TARGET)
        {
            try
            {
                var connection = connType.Equals(ConnectionType.SOURCE) ? _source : _target;
                var orgContext = new OrganizationServiceContext(connection);

                var query = orgContext.CreateQuery("msdyn_solutionhistory")
                    .Select(sh => new SolutionHistory
                    {
                        LogicalName = sh.GetAttributeValue<string>("msdyn_name"),
                        Operation = (HistoryOperation)sh.GetAttributeValue<OptionSetValue>("msdyn_operation").Value,
                        Status = (HistoryStatus)sh.GetAttributeValue<OptionSetValue>("msdyn_status").Value,
                        Result = sh.GetAttributeValue<bool>("msdyn_result") ? HistoryResult.SUCCESS : HistoryResult.FAILURE,
                        StartTime = sh.GetAttributeValue<DateTime>("msdyn_starttime"),
                        Message = sh.GetAttributeValue<string>("msdyn_exceptionmessage")
                    }).AsEnumerable().OrderByDescending(sh => sh.StartTime).Take(100);

                return query;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<JointRecord> GetAllSolutions(ConnectionType connType = ConnectionType.TARGET)
        {
            try
            {
                var connection = connType.Equals(ConnectionType.SOURCE) ? _source : _target;
                var orgContext = new OrganizationServiceContext(connection);

                var query = orgContext.CreateQuery("solution")
                    .Join(
                        orgContext.CreateQuery("publisher"),
                        sol => sol["publisherid"],
                        pub => pub["publisherid"],
                        (sol, pub) => new { sol, pub })
                    .Select(join => new JointRecord
                    {
                        Record = new Record("solution", new string[] { "uniquename", "friendlyname", "version", "ismanaged", "description" }, join.sol),
                        Related = new Record("publisher", new string[] { "uniquename", "friendlyname" }, join.pub)
                    });

                return query;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<JointRecord> GetSolutionsByType(PackageType queryType = PackageType.UNMANAGED, ConnectionType connType = ConnectionType.TARGET)
        {
            try
            {
                if(queryType.Equals(PackageType.BOTH))
                {
                    throw new Exception($"For all solution package types, please use method GetAllSolutions()");
                }

                var connection = connType.Equals(ConnectionType.SOURCE) ? _source : _target;
                var orgContext = new OrganizationServiceContext(connection);

                var query = orgContext.CreateQuery("solution")
                    .Join(
                        orgContext.CreateQuery("publisher"),
                        sol => sol["publisherid"],
                        pub => pub["publisherid"],
                        (sol, pub) => new { sol, pub })
                    .Where(join => join.sol.GetAttributeValue<bool>("ismanaged").Equals(queryType.Equals(PackageType.MANAGED)))
                    .Select(join => new JointRecord
                    {
                        Record = new Record("solution", new string[] { "uniquename", "friendlyname", "version", "ismanaged", "description" }, join.sol),
                        Related = new Record("publisher", new string[] { "uniquename", "friendlyname" }, join.pub)
                    });

                return query;
            }
            catch
            {
                throw;
            }
        }

        public Entity GetSolution(string logicalName, string[] columns, ConnectionType connType = ConnectionType.TARGET)
        {
            try
            {
                var connection = connType.Equals(ConnectionType.SOURCE) ? _source : _target;
                var orgContext = new OrganizationServiceContext(connection);

                var query = orgContext.CreateQuery("solution")
                    .Where(sol => sol.GetAttributeValue<string>("uniquename").Equals(logicalName))
                    .Select(sol => new Record("solution", columns, sol));

                return query.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateSolution(UpdateOperation update)
        {
            try
            {
                _logger.Log(LogLevel.INFO, $"Updating solution {update.Solution.DisplayName}...");
                var request = new UpdateRequest
                {
                    Target = new Entity("solution")
                    {
                        Attributes =
                        {
                            { "solutionid", update.Solution.SolutionId },
                            { "friendlyname", update.Solution.DisplayName },
                            { "version", update.Solution.Version },
                            { "description", update.Solution.Description }
                        }
                    }
                };

                _source.Execute(request);
            }
            catch
            {
                throw;
            }
        }

        public void ExportSolution(ExportOperation export)
        {
            try
            {
                _logger.Log(LogLevel.INFO, $"Exporting solution {export.Solution.DisplayName}...");
                var exportReq = new OrganizationRequest("ExportSolutionAsync")
                {
                    Parameters =
                    {
                        { "SolutionName", export.Solution.LogicalName },
                        { "Managed", export.Solution.Package.Type.Equals(PackageType.MANAGED) }
                    }
                };

                var exportResp = _source.Execute(exportReq);

                _logger.Log(LogLevel.INFO, $"Waiting for export operation...");
                var result = CheckProgress(ConnectionType.SOURCE, Guid.Parse(exportResp["AsyncOperationId"].ToString()));
                if(result.Status.Equals(Enums.OperationStatus.CANCELED)) { return; }

                if (!result.Success)
                {
                    throw new Exception($"Error on Export operation:\n{result.Message}");
                }

                _logger.Log(LogLevel.INFO, $"Downloading solution {export.Solution.DisplayName}...");
                var downloadReq = new OrganizationRequest("DownloadSolutionExportData")
                {
                    Parameters =
                    {
                        { "ExportJobId", Guid.Parse(exportResp["ExportJobId"].ToString()) }
                    }
                };

                var downloadResp = _source.Execute(downloadReq);

                var package = export.Solution.Package;
                package.Bytes = downloadResp["ExportSolutionFile"] as byte[];

                using (var writer = new BinaryWriter(File.OpenWrite(package.Path)))
                {
                    writer.Write(package.Bytes);
                }
            }
            catch
            {
                throw;
            }
        }

        public void ImportSolution(ImportOperation import, string progressMessage)
        {
            try
            {
                _logger.Log(LogLevel.INFO, $"Importing solution {import.Solution.DisplayName}...");
                var request = new ImportSolutionAsyncRequest
                {
                    CustomizationFile = import.Solution.Package.Bytes,
                    HoldingSolution = import.HoldingSolution,
                    OverwriteUnmanagedCustomizations = import.OverwriteUnmanaged,
                    PublishWorkflows = import.PublishWorkflows
                };

                var response = _target.Execute(request) as ImportSolutionAsyncResponse;

                _logger.Log(LogLevel.INFO, $"Waiting for import operation...");
                var result = CheckProgress(ConnectionType.TARGET, response.AsyncOperationId, Guid.Parse(response.ImportJobKey), progressMessage);
                if (result.Status.Equals(Enums.OperationStatus.CANCELED)) { return; }

                if (!result.Success)
                {
                    throw new Exception($"Error on Import operation:\n{result.Message}");
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpgradeSolution(Solution solution)
        {
            try
            {
                _logger.Log(LogLevel.INFO, $"Upgrading solution {solution.DisplayName}...");
                var operationId = _target.DeleteAndPromoteSolutionAsync(solution.LogicalName);

                _logger.Log(LogLevel.INFO, $"Waiting for upgrade operation...");
                var result = CheckProgress(ConnectionType.TARGET, operationId);
                if (result.Status.Equals(Enums.OperationStatus.CANCELED)) { return; }

                if (!result.Success)
                {
                    throw new Exception($"Error on Upgrade operation:\n{result.Message}");
                }
            }
            catch
            {
                throw;
            }
        }

        public void DeleteSolution(Solution solution)
        {
            try
            {
                _logger.Log(LogLevel.INFO, $"Deleting solution {solution.DisplayName}...");

                var filter = new FilterExpression(LogicalOperator.And)
                {
                    Conditions =
                    {
                        new ConditionExpression("solutionid", ConditionOperator.Equal, solution.SolutionId)
                    }
                };

                var request = new BulkDeleteRequest
                {
                    JobName = $"Solution {solution.DisplayName} Delete",
                    QuerySet = new QueryExpression[]
                    {
                        new QueryExpression("solution")
                        {
                            ColumnSet = new ColumnSet("solutionid"),
                            Criteria = filter
                        }
                    },
                    ToRecipients = new Guid[] { },
                    CCRecipients = new Guid[] { },
                    RecurrencePattern = string.Empty
                };

                var response = _target.Execute(request) as BulkDeleteResponse;

                _logger.Log(LogLevel.INFO, $"Waiting for delete operation...");
                var result = CheckProgress(ConnectionType.TARGET, response.JobId);
                if (result.Status.Equals(Enums.OperationStatus.CANCELED)) { return; }

                if (!result.Success)
                {
                    throw new Exception($"Error on Delete operation:\n{result.Message}");
                }
            }
            catch
            {
                throw;
            }
        }

        public void UnpackSolution(UnpackOperation unpack)
        {
            try
            {
                _logger.Log(LogLevel.INFO, $"Checking requirements...");
                if(!File.Exists(unpack.Packager))
                {
                    throw new Exception($"Solution Packager not found - Please download Solution Packager before executing an Unpack operation");
                }

                _logger.Log(LogLevel.INFO, $"Cleaning output directory...");
                if (Directory.Exists(unpack.Folder))
                {
                    var dirInfo = new DirectoryInfo(unpack.Folder);
                    foreach (var file in dirInfo.GetFiles()) { file.Delete(); }
                    foreach (var dir in dirInfo.GetDirectories()) { dir.Delete(true); }
                }

                _logger.Log(LogLevel.INFO, $"Unpacking solution {unpack.Solution.DisplayName}...");
                var process = new Process
                {
                    StartInfo =
                {
                    FileName = unpack.Packager,
                    Arguments = $"/action:{unpack.Action} /zipfile:\"{unpack.ZipFile}\" /folder:\"{unpack.Folder}\" /packagetype:\"{unpack.PackageType}\" /allowDelete:\"No\"",
                    WorkingDirectory = unpack.WorkingDir,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                },
                    EnableRaisingEvents = true
                };

                _logger.Output(LogLevel.PACKAGER, "Process starting...");

                process.Start();

                while (!process.StandardOutput.EndOfStream)
                {
                    var output = process.StandardOutput.ReadLine();
                    _logger.Output(LogLevel.PACKAGER, output);
                }

                while (!process.StandardError.EndOfStream)
                {
                    var errors = process.StandardError.ReadLine();
                    _logger.Output(LogLevel.PACKAGER, errors);
                }

                process.WaitForExit(30000);

                if (process.ExitCode != 0)
                {
                    throw new Exception("An error occurred while executing Solution Packager");
                }
            }
            catch
            {
                throw;
            }
        }

        public void PackSolution(PackOperation pack)
        {
            try
            {
                _logger.Log(LogLevel.INFO, $"Checking requirements...");
                if (!File.Exists(pack.Packager))
                {
                    throw new Exception($"Solution Packager not found - Please download Solution Packager before executing a Pack operation");
                }

                _logger.Log(LogLevel.INFO, $"Packing solution {pack.Solution.DisplayName}...");
                var process = new Process
                {
                    StartInfo =
                    {
                        FileName = pack.Packager,
                        Arguments = $"/action:{pack.Action} /zipfile:\"{pack.ZipFile}\" /folder:\"{pack.Folder}\" /packagetype:\"{pack.PackageType}\" /allowDelete:\"No\"",
                        WorkingDirectory = pack.WorkingDir,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    },
                    EnableRaisingEvents = true
                };

                _logger.Output(LogLevel.PACKAGER, "Process starting...");

                process.Start();

                while (!process.StandardOutput.EndOfStream)
                {
                    var output = process.StandardOutput.ReadLine();
                    _logger.Output(LogLevel.PACKAGER, output);
                }

                while (!process.StandardError.EndOfStream)
                {
                    var errors = process.StandardError.ReadLine();
                    _logger.Output(LogLevel.PACKAGER, errors);
                }

                process.WaitForExit(30000);

                if (process.ExitCode != 0)
                {
                    throw new Exception("An error occurred while executing Solution Packager");
                }
            }
            catch
            {
                throw;
            }
        }

        public void PublishCustomizations()
        {
            try
            {
                _logger.Log(LogLevel.INFO, $"Publishing all customizations...");

                var response = _target.Execute(new OrganizationRequest("PublishAllXmlAsync"));

                _logger.Log(LogLevel.INFO, $"Waiting for publish operation...");
                var result = CheckProgress(ConnectionType.TARGET, Guid.Parse(response["AsyncOperationId"].ToString()));
                if (result.Status.Equals(Enums.OperationStatus.CANCELED)) { return; }

                if (!result.Success)
                {
                    throw new Exception($"Error on Publish operation:\n{result.Message}");
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion Interface Methods

        #region Private Methods
        private OperationResponse CheckProgress(ConnectionType connType, Guid operationId, Guid? importJobId = null, string baseMsg = null)
        {
            var connection = connType.Equals(ConnectionType.SOURCE) ? _source : _target;

            var success = false;
            var opStatus = Enums.OperationStatus.IN_PROGRESS;
            var message = string.Empty;

            var completed = false;
            var startTime = DateTime.UtcNow;
            while (!completed)
            {
                if (_worker.CancellationPending) { return new OperationResponse { Status = Enums.OperationStatus.CANCELED, Success = true, Message = "Operation canceled by user" }; }

                var async = connection.Retrieve("asyncoperation", operationId, new ColumnSet(new string[] { "statecode", "statuscode", "friendlymessage", "message" }));

                var state = async.GetAttributeValue<OptionSetValue>("statecode").Value;
                var status = async.GetAttributeValue<OptionSetValue>("statuscode").Value;
                _logger.Log(LogLevel.DEBUG, $"State: {state} | Status: {status}");

                if (importJobId.HasValue)
                {
                    var importJob = connection.Retrieve("importjob", importJobId.Value, new ColumnSet(new string[] { "progress" }));
                    var progress = Math.Round(importJob.GetAttributeValue<double>("progress"), 2);
                    _logger.Log(LogLevel.DEBUG, $"Import progress: {progress}%");

                    var progressMsg = $"{baseMsg}\n{progress}%";
                    _worker.ReportProgress(Convert.ToInt32(progress), progressMsg);
                }

                if (state.Equals(3))
                {
                    completed = true;
                    opStatus = (Enums.OperationStatus)status;

                    if (status > 30)
                    {
                        message = async.GetAttributeValue<string>("friendlymessage");
                        if(string.IsNullOrEmpty(message))
                        {
                            var raw = async.GetAttributeValue<string>("message");

                            var delimiters = new string[] { "Message: ", "Detail: " };
                            var splitArr = raw.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                            message = splitArr[1];
                        }
                    }
                }

                success = completed && status.Equals(30) ? true : false;
                message = completed && status.Equals(30) ? "Solution successfully imported and upgraded" : message;

                if (!state.Equals(3)) { Sleep(DateTime.UtcNow - startTime); }
            }

            return new OperationResponse
            {
                Success = success,
                Status = opStatus,
                Message = message
            };
        }

        private void Sleep(TimeSpan elapsed)
        {
            int sleepTimeInSeconds;
            if (elapsed < TimeSpan.FromMinutes(5))
            {
                sleepTimeInSeconds = 10;
                _logger.Log(LogLevel.DEBUG, $"Sleeping for {sleepTimeInSeconds} seconds");
            }
            else if (elapsed < TimeSpan.FromMinutes(10))
            {
                sleepTimeInSeconds = 20;
                _logger.Log(LogLevel.DEBUG, $"Sleeping for {sleepTimeInSeconds} seconds");
            }
            else if (elapsed < TimeSpan.FromMinutes(30))
            {
                sleepTimeInSeconds = 30;
                _logger.Log(LogLevel.DEBUG, $"Sleeping for {sleepTimeInSeconds} seconds");
            }
            else
            {
                sleepTimeInSeconds = 60;
                _logger.Log(LogLevel.DEBUG, $"Sleeping for {sleepTimeInSeconds} seconds");
            }

            Thread.Sleep(sleepTimeInSeconds * 1000);
        }
        #endregion Private Methods
    }
}
