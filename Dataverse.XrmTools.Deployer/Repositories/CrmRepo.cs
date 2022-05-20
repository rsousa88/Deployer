// System
using System;
using System.ComponentModel;

// Microsoft
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Tooling.Connector;

// Deployer
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.RepoInterfaces;
using Dataverse.XrmTools.Deployer.Enums;

namespace Dataverse.XrmTools.Deployer.Repositories
{
    public class CrmRepo : ICrmRepo
    {
        #region Private Fields
        private readonly IOrganizationService _service;
        private readonly CrmServiceClient _client;
        #endregion Private Fields

        #region Constructors
        /// <summary>
        /// Creates an instance of the CRM Repository using the specified CRM client.
        /// </summary>
        /// <param name="service">Instantiated IOrganizationService object</param>
        /// <param name="client">Instantiated CrmServiceClient object</param>
        public CrmRepo(IOrganizationService service, CrmServiceClient client)
        {
            _service = service;
            _client = client;
        }
        #endregion Constructors

        #region Interface Methods
        public void ImportSolution(Solution solution)
        {
            try
            {
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
                var operationId = _client.DeleteAndPromoteSolutionAsync(solution.LogicalName);
                var result = CheckProgress(operationId);
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
                var async = _service.Retrieve("asyncoperation", operationId, new ColumnSet(new string[] { "statecode", "statuscode", "message" }));

                var state = async.GetAttributeValue<OptionSetValue>("statecode").Value;
                var status = async.GetAttributeValue<OptionSetValue>("statuscode").Value;

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
            if (elapsed < TimeSpan.FromMinutes(5))
            {
                System.Threading.Thread.Sleep(10000);
            }
            else if (elapsed < TimeSpan.FromMinutes(10))
            {
                System.Threading.Thread.Sleep(20000);
            }
            else if (elapsed < TimeSpan.FromMinutes(30))
            {
                System.Threading.Thread.Sleep(30000);
            }
            else
            {
                System.Threading.Thread.Sleep(60000);
            }
        }
        #endregion Private Methods
    }
}
