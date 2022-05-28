// System
using System;
using System.IO;
using System.Linq;
using System.ComponentModel;
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
        public IEnumerable<Entity> GetSolutions(string[] columns, PackageType queryType = PackageType.ALL, ConnectionType connType = ConnectionType.TARGET)
        {
            try
            {
                var query = new QueryExpression("solution")
                {
                    ColumnSet = new ColumnSet((from c in columns select c.ToLower()).ToArray()),
                    PageInfo = new PagingInfo() { Count = 5000, PageNumber = 1 }
                };

                if(!queryType.Equals(PackageType.ALL))
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

                var response = _source.Execute(request) as UpdateResponse;

                _logger.Log(LogLevel.INFO, $"Solution {operation.Solution.DisplayName} successfully updated");
            }
            catch
            {
                throw;
            }
        }

        public void ExportSolution(Operation operation)
        {
            try
            {
                _logger.Log(LogLevel.INFO, $"Exporting solution {operation.Solution.DisplayName}...");
                var exportReq = new OrganizationRequest("ExportSolutionAsync")
                {
                    Parameters =
                    {
                        { "SolutionName", operation.Solution.LogicalName },
                        { "Managed", operation.Solution.Package.PackageType.Equals(PackageType.MANAGED) }
                    }
                };

                var exportResp = _source.Execute(exportReq);

                _logger.Log(LogLevel.INFO, $"Waiting for export operation...");
                var result = CheckProgress(ConnectionType.SOURCE, Guid.Parse(exportResp["AsyncOperationId"].ToString()));
                if (!result.Success)
                {
                    throw new Exception($"Error on Export operation:\n{result.Message}");
                }

                _logger.Log(LogLevel.INFO, $"Downloading solution {operation.Solution.DisplayName}...");
                var downloadReq = new OrganizationRequest("DownloadSolutionExportData")
                {
                    Parameters =
                    {
                        { "ExportJobId", Guid.Parse(exportResp["ExportJobId"].ToString()) }
                    }
                };

                var downloadResp = _source.Execute(downloadReq);

                var package = operation.Solution.Package;
                package.SolutionBytes = downloadResp["ExportSolutionFile"] as byte[];

                var ending = package.PackageType.Equals(PackageType.MANAGED) ? "_managed.zip" : ".zip";
                var filename = $"{package.ExportPath}\\{operation.Solution.LogicalName}_{operation.Solution.Version}{ending}";
                using (var writer = new BinaryWriter(File.OpenWrite(filename)))
                {
                    writer.Write(package.SolutionBytes);
                }

                _logger.Log(LogLevel.INFO, $"Solution {operation.Solution.DisplayName} successfully exported");
            }
            catch
            {
                throw;
            }
        }

        public void ImportSolution(Solution solution, string progressMessage)
        {
            try
            {
                _logger.Log(LogLevel.INFO, $"Importing solution {solution.DisplayName}...");
                var request = new ImportSolutionAsyncRequest
                {
                    CustomizationFile = solution.Package.SolutionBytes,
                    OverwriteUnmanagedCustomizations = true,
                    PublishWorkflows = true,
                    HoldingSolution = true
                };

                var response = _target.Execute(request) as ImportSolutionAsyncResponse;

                _logger.Log(LogLevel.INFO, $"Waiting for import operation...");
                var result = CheckProgress(ConnectionType.TARGET, response.AsyncOperationId, Guid.Parse(response.ImportJobKey), progressMessage);
                if (!result.Success)
                {
                    throw new Exception($"Error on Import operation:\n{result.Message}");
                }

                _logger.Log(LogLevel.INFO, $"Solution {solution.DisplayName} successfully imported");
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
                if (!result.Success)
                {
                    throw new Exception($"Error on Upgrade operation:\n{result.Message}");
                }

                _logger.Log(LogLevel.INFO, $"Solution {solution.DisplayName} successfully upgraded");
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
                if (!result.Success)
                {
                    throw new Exception($"Error on Delete operation:\n{result.Message}");
                }

                _logger.Log(LogLevel.INFO, $"Solution {solution.DisplayName} successfully deleted");
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

        private OperationResponse CheckProgress(ConnectionType connType, Guid operationId, Guid? importJobId = null, string progressMsg = null)
        {
            if(progressMsg != null) { progressMsg = $"{progressMsg}\n__PROGRESS__%"; }

            var connection = connType.Equals(ConnectionType.SOURCE) ? _source : _target;

            var success = false;
            var opStatus = Enums.OperationStatus.IN_PROGRESS;
            var message = string.Empty;

            var completed = false;
            var startTime = DateTime.UtcNow;
            while (!completed)
            {
                var async = connection.Retrieve("asyncoperation", operationId, new ColumnSet(new string[] { "statecode", "statuscode", "friendlymessage", "message" }));

                var state = async.GetAttributeValue<OptionSetValue>("statecode").Value;
                var status = async.GetAttributeValue<OptionSetValue>("statuscode").Value;
                _logger.Log(LogLevel.DEBUG, $"State: {state} | Status: {status}");

                if (importJobId.HasValue)
                {
                    var importJob = connection.Retrieve("importjob", importJobId.Value, new ColumnSet(new string[] { "progress" }));
                    var progress = Math.Round(importJob.GetAttributeValue<double>("progress"), 2);
                    _logger.Log(LogLevel.INFO, $"Import progress: {progress}%");

                    progressMsg.GetProgressMessage("__PROGRESS__", progress);
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

            System.Threading.Thread.Sleep(sleepTimeInSeconds * 1000);
        }
        #endregion Private Methods
    }
}
