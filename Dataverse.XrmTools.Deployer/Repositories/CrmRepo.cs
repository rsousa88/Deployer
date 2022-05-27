// System
using System;
using System.Linq;
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
using Dataverse.XrmTools.Deployer.HandlerArgs;
using System.IO;

namespace Dataverse.XrmTools.Deployer.Repositories
{
    public class CrmRepo : ICrmRepo
    {
        #region Private Fields
        private readonly CrmServiceClient _target;
        private readonly CrmServiceClient _source;
        private readonly Logger _logger;
        #endregion Private Fields

        #region Constructors
        /// <summary>
        /// Creates an instance of the CRM Repository using the specified CRM client.
        /// </summary>
        /// <param name="target">Instantiated CrmServiceClient object</param>
        /// <param name="logger">Instantiated Logger object</param>
        public CrmRepo(CrmServiceClient target, Logger logger, CrmServiceClient source = null)
        {
            _target = target;
            _logger = logger;
            _source = source;
        }
        #endregion Constructors

        #region Interface Methods
        public IEnumerable<Entity> GetSolutions(string[] columns, PackageType queryType = PackageType.ALL)
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

                return GetRecords(query);
            }
            catch
            {
                throw;
            }
        }

        public void ExportSolution(Solution solution, ExportEventArgs data)
        {
            try
            {
                _logger.Log(LogLevel.INFO, $"Exporting solution {solution.DisplayName}...");
                var exportReq = new OrganizationRequest("ExportSolutionAsync")
                {
                    Parameters =
                    {
                        { "SolutionName", solution.LogicalName },
                        { "Managed", data.PackageType.Equals(PackageType.MANAGED) }
                    }
                };

                var exportResp = _target.Execute(exportReq);

                _logger.Log(LogLevel.INFO, $"Waiting for export operation...");
                var result = CheckProgress(Guid.Parse(exportResp["AsyncOperationId"].ToString()));
                if (!result.Success)
                {
                    throw new Exception($"Error on Export operation:\n{result.Message}");
                }

                _logger.Log(LogLevel.INFO, $"Downloading solution {solution.DisplayName}...");
                var downloadReq = new OrganizationRequest("DownloadSolutionExportData")
                {
                    Parameters =
                    {
                        { "ExportJobId", Guid.Parse(exportResp["ExportJobId"].ToString()) }
                    }
                };

                var downloadResp = _target.Execute(downloadReq);

                var exported = new Solution
                {
                    SolutionId = solution.SolutionId,
                    LogicalName = solution.LogicalName,
                    DisplayName = solution.DisplayName,
                    Version = solution.Version,
                    IsManaged = solution.IsManaged,
                    Publisher = solution.Publisher,
                    SolutionBytes = downloadResp["ExportSolutionFile"] as byte[]
                };

                var ending = data.PackageType.Equals(PackageType.MANAGED) ? "_managed.zip" : ".zip";
                var filename = $"{data.ExportPath}\\{solution.LogicalName}_{solution.Version}{ending}";
                using (var writer = new BinaryWriter(File.OpenWrite(filename)))
                {
                    writer.Write(exported.SolutionBytes);
                }

                _logger.Log(LogLevel.INFO, $"Solution {solution.DisplayName} successfully exported");
            }
            catch
            {
                throw;
            }
        }

        public void ImportSolution(Solution solution, ImportEventArgs data)
        {
            try
            {
                _logger.Log(LogLevel.INFO, $"Importing solution {solution.DisplayName}...");
                var request = new ImportSolutionAsyncRequest
                {
                    CustomizationFile = solution.SolutionBytes,
                    OverwriteUnmanagedCustomizations = true,
                    PublishWorkflows = true,
                    HoldingSolution = true
                };

                var response = _target.Execute(request) as ImportSolutionAsyncResponse;

                _logger.Log(LogLevel.INFO, $"Waiting for import operation...");
                var result = CheckProgress(response.AsyncOperationId);
                if(!result.Success)
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

        public void UpgradeSolution(Solution solution, ImportEventArgs data)
        {
            try
            {
                _logger.Log(LogLevel.INFO, $"Upgrading solution {solution.DisplayName}...");
                var operationId = _target.DeleteAndPromoteSolutionAsync(solution.LogicalName);

                _logger.Log(LogLevel.INFO, $"Waiting for upgrade operation...");
                var result = CheckProgress(operationId);
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

        public void DeleteSolution(Solution solution, DeleteEventArgs data)
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
                var result = CheckProgress(response.JobId);
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
        public IEnumerable<Entity> GetRecords(QueryExpression query, int batchSize = 250)
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
                    response = _target.Execute(new RetrieveMultipleRequest() { Query = query }) as RetrieveMultipleResponse;
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

        private OperationResponse CheckProgress(Guid operationId)
        {
            var success = false;
            var opStatus = Enums.OperationStatus.IN_PROGRESS;
            var message = string.Empty;

            var completed = false;
            var startTime = DateTime.UtcNow;
            while (!completed)
            {
                var async = _target.Retrieve("asyncoperation", operationId, new ColumnSet(new string[] { "statecode", "statuscode", "friendlymessage", "message" }));

                var state = async.GetAttributeValue<OptionSetValue>("statecode").Value;
                var status = async.GetAttributeValue<OptionSetValue>("statuscode").Value;

                _logger.Log(LogLevel.DEBUG, $"State: {state} | Status: {status}");

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
