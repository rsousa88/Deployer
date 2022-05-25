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
        #endregion Interface Methods

        #region Private Methods
        private ImportAndUpgradeResponse CheckProgress(Guid operationId)
        {
            var success = false;
            var message = string.Empty;

            var completed = false;
            var startTime = DateTime.UtcNow;
            while (!completed)
            {
                _logger.Log(LogLevel.DEBUG, $"Checking progress...");

                var async = _service.Retrieve("asyncoperation", operationId, new ColumnSet(new string[] { "statecode", "statuscode", "message" }));

                var state = async.GetAttributeValue<OptionSetValue>("statecode").Value;
                var status = async.GetAttributeValue<OptionSetValue>("statuscode").Value;

                _logger.Log(LogLevel.DEBUG, $"State: {state} | Status: {status}");

                if (state.Equals(3))
                {
                    completed = true;

                    if (status.Equals(31))
                    {
                        var raw = async.GetAttributeValue<string>("message");

                        var delimiters = new string[] { "Message: ", "Detail: " };
                        var splitArr = raw.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                        message = splitArr[1];
                    }
                }

                success = completed && status.Equals(30) ? true : false;
                message = completed && status.Equals(30) ? "Solution successfully imported and upgraded" : message;

                Sleep(DateTime.UtcNow - startTime);
            }

            return new ImportAndUpgradeResponse
            {
                Success = success,
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
