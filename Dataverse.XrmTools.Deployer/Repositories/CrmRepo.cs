// System
using System;

// Microsoft
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Tooling.Connector;

// Deployer
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.RepoInterfaces;
using Dataverse.XrmTools.Deployer.Helpers;
using Dataverse.XrmTools.Deployer.Enums;
using System.Collections.Generic;
using Microsoft.Xrm.Sdk.Messages;
using System.Linq;

namespace Dataverse.XrmTools.Deployer.Repositories
{
    public class CrmRepo : ICrmRepo
    {
        #region Private Fields
        private readonly IOrganizationService _service;
        private readonly CrmServiceClient _client;
        private readonly Logger _logger;
        #endregion Private Fields

        #region Constructors
        /// <summary>
        /// Creates an instance of the CRM Repository using the specified CRM client.
        /// </summary>
        /// <param name="service">Instantiated IOrganizationService object</param>
        /// <param name="client">Instantiated CrmServiceClient object</param>
        /// <param name="logger">Instantiated Logger object</param>
        public CrmRepo(IOrganizationService service, CrmServiceClient client, Logger logger)
        {
            _service = service;
            _client = client;
            _logger = logger;
        }
        #endregion Constructors

        #region Interface Methods
        public IEnumerable<Entity> GetManagedSolutions(string[] columns)
        {
            try
            {
                var filter = new FilterExpression(LogicalOperator.And)
                {
                    Conditions =
                    {
                        new ConditionExpression("ismanaged", ConditionOperator.Equal, true)
                    }
                };

                var query = new QueryExpression("solution")
                {
                    ColumnSet = new ColumnSet((from c in columns select c.ToLower()).ToArray()),
                    Criteria = filter,
                    PageInfo = new PagingInfo() { Count = 5000, PageNumber = 1 }
                };

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

        public void ImportSolution(Solution solution)
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

                var response = _service.Execute(request) as ImportSolutionAsyncResponse;

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

        public void UpgradeSolution(Solution solution)
        {
            try
            {
                _logger.Log(LogLevel.INFO, $"Upgrading solution {solution.DisplayName}...");
                var operationId = _client.DeleteAndPromoteSolutionAsync(solution.LogicalName);

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

                var response = _service.Execute(request) as BulkDeleteResponse;

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
                    response = _service.Execute(new RetrieveMultipleRequest() { Query = query }) as RetrieveMultipleResponse;
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
                var async = _service.Retrieve("asyncoperation", operationId, new ColumnSet(new string[] { "statecode", "statuscode", "friendlymessage", "message" }));

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
