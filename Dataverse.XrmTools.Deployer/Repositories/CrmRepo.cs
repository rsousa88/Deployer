// System
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

// Microsoft
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Tooling.Connector;

// Deployer
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;
using Dataverse.XrmTools.Deployer.RepoInterfaces;

// 3rd Party
using NuGet.Protocol;
using NuGet.Packaging;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;

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
        public IEnumerable<Entity> GetSolutions(string[] columns = null, PackageType queryType = PackageType.BOTH, ConnectionType connType = ConnectionType.TARGET)
        {
            try
            {
                if(columns is null) { columns = new string[] { "solutionid" }; }
                var query = new QueryExpression("solution")
                {
                    ColumnSet = new ColumnSet((from c in columns select c.ToLower()).ToArray()),
                    PageInfo = new PagingInfo() { Count = 5000, PageNumber = 1 }
                };

                if (!queryType.Equals(PackageType.BOTH))
                {
                    query.Criteria = new FilterExpression(LogicalOperator.And)
                    {
                        Conditions =
                        {
                            new ConditionExpression("ismanaged", ConditionOperator.Equal, queryType.Equals(PackageType.MANAGED) ? true : false)
                        }
                    };
                }

                var publisher = query.AddLink("publisher", "publisherid", "publisherid");
                publisher.EntityAlias = "publisher";
                publisher.Columns.AddColumns("uniquename", "friendlyname");

                return GetRecords(query, connType);
            }
            catch
            {
                throw;
            }
        }

        public Entity GetSolution(string logicalName, string[] columns = null, ConnectionType connType = ConnectionType.TARGET)
        {
            try
            {
                if (columns is null) { columns = new string[] { "solutionid" }; }
                var filter = new FilterExpression(LogicalOperator.And)
                {
                    Conditions =
                        {
                            new ConditionExpression("uniquename", ConditionOperator.Equal, logicalName)
                        }
                };

                var query = new QueryExpression("solution")
                {
                    ColumnSet = new ColumnSet((from c in columns select c.ToLower()).ToArray()),
                    Criteria = filter,
                    PageInfo = new PagingInfo() { Count = 5000, PageNumber = 1 }
                };

                return GetRecords(query, connType).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateSolution(Operation operation)
        {
            try
            {
                _logger.Log(LogLevel.INFO, $"Updating solution {operation.Solution.DisplayName}...");
                var request = new UpdateRequest
                {
                    Target = new Entity("solution")
                    {
                        Attributes =
                        {
                            { "solutionid", operation.Solution.SolutionId },
                            { "friendlyname", operation.Solution.DisplayName },
                            { "version", operation.Solution.Version },
                            { "description", operation.Solution.Description }
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

                var fullPath = $"{package.ExportPath}\\{export.Solution.Package.Name}";
                using (var writer = new BinaryWriter(File.OpenWrite(fullPath)))
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

                var query = new QueryExpression("solution")
                {
                    ColumnSet = new ColumnSet("solutionid"),
                    Criteria = filter
                };

                var request = new BulkDeleteRequest
                {
                    JobName = $"Solution {solution.DisplayName} Delete",
                    QuerySet = new QueryExpression[]
                    {
                        query
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

        public void PackSolution(ImportOperation import)
        {
            try
            {
                _logger.Log(LogLevel.INFO, $"Packing solution {import.Solution.DisplayName}...");
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
        public IEnumerable<Entity> GetRecords(QueryExpression query, ConnectionType connType, int batchSize = 250)
        {
            try
            {
                // page info settings
                query.PageInfo.PageNumber = 1;
                query.PageInfo.Count = batchSize;

                RetrieveMultipleResponse response;

                var records = new List<Entity>();
                do
                {
                    var connection = connType.Equals(ConnectionType.SOURCE) ? _source : _target;
                    response = connection.Execute(new RetrieveMultipleRequest() { Query = query }) as RetrieveMultipleResponse;
                    if (response == null || response.EntityCollection == null) { break; }

                    records.AddRange(response.EntityCollection.Entities);
                    query.PageInfo.PageNumber++;
                    query.PageInfo.PagingCookie = response.EntityCollection.PagingCookie;
                }
                while (response.EntityCollection.MoreRecords);

                return records.AsEnumerable();
            }
            catch
            {
                throw;
            }
        }

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
