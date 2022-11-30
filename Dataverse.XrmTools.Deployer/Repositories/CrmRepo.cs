// System
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
using System.Xml.Linq;
using System.Text;

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
        /// <param name="target">Source instance client</param>
        /// <param name="logger">Instantiated Logger object</param>
        /// <param name="source">[Optional] Target instance client</param>
        /// <param name="worker">[Optional] Async background worker</param>
        public CrmRepo(CrmServiceClient source, Logger logger, CrmServiceClient target = null, BackgroundWorker worker = null)
        {
            _source = source;
            _logger = logger;
            _target = target;
            _worker = worker;
        }
        #endregion Constructors

        #region Interface Methods
        public IEnumerable<JointRecord> GetAllSolutions(ConnectionType connType = ConnectionType.SOURCE)
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
                        Record = new Record("solution", new string[] { "solutionid", "uniquename", "friendlyname", "version", "ismanaged", "description" }, join.sol),
                        Related = new Record("publisher", new string[] { "uniquename", "friendlyname" }, join.pub)
                    });

                return query;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<JointRecord> GetSolutionsByType(PackageType queryType = PackageType.UNMANAGED, ConnectionType connType = ConnectionType.SOURCE)
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
                        Record = new Record("solution", new string[] { "solutionid", "uniquename", "friendlyname", "version", "ismanaged", "description" }, join.sol),
                        Related = new Record("publisher", new string[] { "uniquename", "friendlyname" }, join.pub)
                    });

                return query;
            }
            catch
            {
                throw;
            }
        }

        public Entity GetSolution(string logicalName, string[] columns, ConnectionType connType = ConnectionType.SOURCE)
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
                _logger.Log(LogLevel.INFO, $"Updating solution {update.Solution.DisplayName} to verion {update.Version}...");
                var request = new UpdateRequest
                {
                    Target = new Entity("solution")
                    {
                        Attributes =
                        {
                            { "solutionid", update.Solution.SolutionId },
                            { "version", update.Version }
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
                        { "Managed", export.PackageType.Equals(PackageType.MANAGED) }
                    }
                };

                var exportResp = _source.Execute(exportReq);

                _logger.Log(LogLevel.INFO, $"Waiting for export operation...");
                var result = CheckProgress(ConnectionType.SOURCE, Guid.Parse(exportResp["AsyncOperationId"].ToString()));
                if (result.Status.Equals(Enums.OperationStatus.CANCELED)) { return; }

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

                var package = new Package
                {
                    Name = export.PackageName,
                    Type = export.PackageType,
                    Bytes = downloadResp["ExportSolutionFile"] as byte[],
                    Path = export.PackagePath
                };

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

                if(!File.Exists(import.Package.Path))
                {
                    throw new Exception($"Error on Import operation\nInvalid package on path '{import.Package.Path}'");
                }

                var bytes = File.ReadAllBytes(import.Package.Path);
                var request = new ImportSolutionAsyncRequest
                {
                    CustomizationFile = bytes,
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
                    throw new Exception($"Error on Import operation\n{result.Message}");
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
                if (!File.Exists(unpack.Packager))
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

        //public void PublishCustomizations()
        //{
        //    try
        //    {
        //        _logger.Log(LogLevel.INFO, $"Publishing all customizations...");

        //        var response = _target.Execute(new OrganizationRequest("PublishAllXmlAsync"));

        //        _logger.Log(LogLevel.INFO, $"Waiting for publish operation...");
        //        var result = CheckProgress(ConnectionType.TARGET, Guid.Parse(response["AsyncOperationId"].ToString()));
        //        if (result.Status.Equals(Enums.OperationStatus.CANCELED)) { return; }

        //        if (!result.Success)
        //        {
        //            throw new Exception($"Error on Publish operation:\n{result.Message}");
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        #endregion Interface Methods

        #region Private Methods
        private OperationResponse CheckProgress(ConnectionType connType, Guid operationId, Guid? importJobId = null, string baseMsg = null)
        {
            var connection = connType.Equals(ConnectionType.SOURCE) ? _source : _target;

            var success = false;
            var jobMessage = string.Empty;
            var opStatus = Enums.OperationStatus.IN_PROGRESS;
            var opMessage = string.Empty;
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
                    var importJob = connection.Retrieve("importjob", importJobId.Value, new ColumnSet(new string[] { "progress", "data" }));
                    var progress = Math.Round(importJob.GetAttributeValue<double>("progress"), 2);
                    _logger.Log(LogLevel.DEBUG, $"Import progress: {progress}%");

                    var progressMsg = $"{baseMsg}\n{progress}%";
                    _worker.ReportProgress(Convert.ToInt32(progress), progressMsg);

                    if(!string.IsNullOrEmpty(importJob.GetAttributeValue<string>("data")))
                    {
                        var xmlStr = importJob.GetAttributeValue<string>("data");
                        var xmlDoc = XDocument.Parse(xmlStr);

                        var jobStatusAttr = xmlDoc.Root.Attribute("succeeded");
                        var jobMessageAttr = xmlDoc.Root.Attribute("status");
                        var dependencies = new List<ImportDependency>();
                        if(jobStatusAttr != null && jobMessageAttr != null)
                        {
                            var jobMessageStr = xmlDoc.Root.Attribute("status").Value;
                            if(jobMessageStr.Contains("<MissingDependencies>"))
                            {
                                var startDelimiter = "<MissingDependencies>";
                                var endDelimiter = "</MissingDependencies>";

                                var start = jobMessageStr.IndexOf(startDelimiter);
                                var end = jobMessageStr.IndexOf(endDelimiter) + endDelimiter.Length;

                                var depsXml = jobMessageStr.Substring(start, end - start);
                                var depsDoc = XDocument.Parse(depsXml);

                                dependencies = depsDoc.Root.Descendants("MissingDependency").Select(node =>
                                {
                                    var required = node.Descendants("Required").First();
                                    var dependent = node.Descendants("Dependent").First();

                                    return new ImportDependency
                                    {
                                        Required = new DependencyComponent
                                        {
                                            Id = required.Attribute("id") != null ? Guid.Parse(required.Attribute("id").Value) : Guid.Empty,
                                            Type = required.Attribute("type") != null ? (ComponentType)required.Attribute("type").Value.TryParse<int>(int.TryParse) : ComponentType.Unknown,
                                            LogicalName = required.Attribute("schemaName") != null ? required.Attribute("schemaName").Value : string.Empty,
                                            DisplayName = required.Attribute("displayName") != null ? required.Attribute("displayName").Value : string.Empty
                                        },
                                        Dependent = new DependencyComponent
                                        {
                                            Id = dependent.Attribute("id") != null ? Guid.Parse(dependent.Attribute("id").Value) : Guid.Empty,
                                            Type = dependent.Attribute("type") != null ? (ComponentType)dependent.Attribute("type").Value.TryParse<int>(int.TryParse) : ComponentType.Unknown,
                                            LogicalName = dependent.Attribute("schemaName") != null ? dependent.Attribute("schemaName").Value : string.Empty,
                                            DisplayName = dependent.Attribute("displayName") != null ? dependent.Attribute("displayName").Value : string.Empty
                                        }
                                    };
                                }).ToList();
                            }

                            var jobStatus = jobStatusAttr.Value.ToUpper();
                            var sb1 = new StringBuilder($"{jobStatus}: ");
                            if (dependencies.Any())
                            {
                                sb1.Append($"There are unresolved import dependencies, check logs for details.");
                                sb1.AppendLine();
                                var groups = dependencies.GroupBy(dep => dep.Dependent.LogicalName);

                                var sb2 = new StringBuilder();
                                foreach (var grp in groups)
                                {
                                    sb2.AppendLine($"{grp.First().Dependent.Type} '{grp.First().Dependent.DisplayName}' ({grp.First().Dependent.LogicalName}) requires the following components:");
                                    foreach (var dep in grp)
                                    {
                                        sb2.AppendLine($"\tType: {dep.Required.Type}");
                                        sb2.AppendLine($"\tDisplay Name: {dep.Required.DisplayName}");
                                        sb2.AppendLine($"\tLogical Name: {dep.Required.LogicalName}");
                                        sb2.AppendLine($"\tComponent ID: {dep.Required.Id}");
                                        sb2.AppendLine();
                                    }
                                }

                                _logger.Log(LogLevel.ERROR, sb2.ToString());
                            }
                            else
                            {
                                sb1.Append(jobMessageStr);
                                sb1.AppendLine();
                            }

                            jobMessage = sb1.ToString();
                        }
                    }
                }

                if (state.Equals(3))
                {
                    completed = true;
                    opStatus = (Enums.OperationStatus)status;

                    if (status > 30)
                    {
                        if (!string.IsNullOrEmpty(async.GetAttributeValue<string>("friendlymessage")))
                        {
                            opMessage = async.GetAttributeValue<string>("friendlymessage");
                        }
                        else if (!string.IsNullOrEmpty(async.GetAttributeValue<string>("message")))
                        {
                            var raw = async.GetAttributeValue<string>("message");

                            var delimiters = new string[] { "Message: ", "Detail: " };
                            var splitArr = raw.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                            opMessage = splitArr[1];
                        }
                        else
                        {
                            opMessage = $"Unknown error during import operation";
                        }
                    }
                }

                success = completed && status.Equals(30) ? true : false;
                if(completed && status.Equals(30))
                {
                    message = "Solution successfully imported and upgraded";
                }
                else if (completed && !status.Equals(30))
                {
                    message = !string.IsNullOrEmpty(jobMessage) ? jobMessage : opMessage;
                }

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
