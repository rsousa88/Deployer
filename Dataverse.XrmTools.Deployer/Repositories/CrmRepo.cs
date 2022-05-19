// System
using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;

// Microsoft
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Messages;

// ActiveLayerExplorer
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.RepoInterfaces;

namespace Dataverse.XrmTools.Deployer.Repositories
{
    public class CrmRepo : ICrmRepo
    {
        #region Private Fields
        private readonly IOrganizationService _service;
        private readonly int _batchSize;
        private readonly BackgroundWorker _worker;
        #endregion Private Fields

        #region Constructors
        /// <summary>
        /// Creates an instance of the CRM Repository using the specified CRM service.
        /// </summary>
        /// <param name="crmContext">Instantiated crmContext object</param>
        public CrmRepo(IOrganizationService service, int batchSize, BackgroundWorker worker = null)
        {
            _service = service;
            _batchSize = batchSize;
            _worker = worker;
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

                return GetRecords(query);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Entity> GetSolutionComponents(string[] columns, Guid solutionId)
        {
            try
            {
                var filter = new FilterExpression(LogicalOperator.And)
                {
                    Conditions =
                    {
                        new ConditionExpression("solutionid", ConditionOperator.Equal, solutionId)
                    }
                };

                var query = new QueryExpression("solutioncomponent")
                {
                    ColumnSet = new ColumnSet((from c in columns select c.ToLower()).ToArray()),
                    Criteria = filter,
                    PageInfo = new PagingInfo() { Count = 5000, PageNumber = 1 }
                };

                return GetRecords(query);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<ActiveLayer> GetActiveLayers(string[] columns, IEnumerable<SolutionComponent> solutionComponents)
        {
            try
            {
                var requests = solutionComponents.Select(sc => new RetrieveMultipleRequest
                {
                    Query = new QueryExpression("msdyn_componentlayer")
                    {
                        NoLock = true,
                        ColumnSet = new ColumnSet((from c in columns select c.ToLower()).ToArray()),
                        Criteria = new FilterExpression
                        {
                            Conditions =
                            {
                                new ConditionExpression("msdyn_solutionname", ConditionOperator.Equal, "Active"),
                                new ConditionExpression("msdyn_solutioncomponentname", ConditionOperator.Equal, sc.Type.LogicalName),
                                new ConditionExpression("msdyn_componentid", ConditionOperator.Equal, sc.ObjectId),
                            }
                        }
                    }
                });

                var responses = ExecuteMultiple(requests);

                var layers = responses.Select(resp => {
                    var record = resp.Records.FirstOrDefault();
                    if(record is null) { return null; }

                    var request = resp.Request as RetrieveMultipleRequest;
                    var query = request.Query as QueryExpression;
                    var objectId = (Guid)query.Criteria.Conditions.Last().Values.First();
                    var solutionComponent = solutionComponents.First(sc => sc.ObjectId.Equals(objectId));

                    return new ActiveLayer
                    {
                        Id = solutionComponent.Id,
                        Name = record.GetAttributeValue<string>("msdyn_name"),
                        SolutionComponent = solutionComponent
                    };
                });

                return layers.Where(lay => lay != null);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<CrmBulkResponse> DeleteLayers(IEnumerable<ActiveLayer> layers)
        {
            try
            {
                var requests = layers.Select(lay => {
                    var request = new OrganizationRequest("RemoveActiveCustomizations");
                    request.Parameters["SolutionComponentName"] = lay.SolutionComponent.Type.LogicalName;
                    request.Parameters["ComponentId"] = lay.SolutionComponent.ObjectId;

                    return request;
                });

                var responses = new List<CrmBulkResponse>();
                foreach (var req in requests)
                {
                    var response = new OrganizationResponse();
                    try
                    {
                        response = _service.Execute(req);

                        responses.Add(new CrmBulkResponse
                        {
                            Id = req.RequestId.GetValueOrDefault(Guid.Empty),
                            Success = true,
                            Request = req
                        });
                    }
                    catch (Exception ex)
                    {
                        responses.Add(new CrmBulkResponse
                        {
                            Id = req.RequestId.GetValueOrDefault(Guid.Empty),
                            Success = false,
                            Message = ex.Message,
                            Request = req
                        });
                    }
                }

                return responses;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public EnumAttributeMetadata GetOptionSetMetadata(string tableName, string columnName)
        {
            try
            {
                var request = new RetrieveAttributeRequest
                {
                    EntityLogicalName = tableName,
                    LogicalName = columnName,
                    RetrieveAsIfPublished = true
                };

                var response = _service.Execute(request) as RetrieveAttributeResponse;

                return response.AttributeMetadata as EnumAttributeMetadata;
            }
            catch
            {
                throw;
            }
        }

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
                    if (_worker != null && _worker.CancellationPending) return null;

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

        public EntityCollection GetCollectionByExpression(QueryExpression query, int batchSize = 250)
        {
            try
            {
                var records = GetRecords(query, batchSize).ToList();
                return new EntityCollection(records);
            }
            catch
            {
                throw;
            }
        }
        #endregion Interface Methods

        #region Private Methods
        private IEnumerable<CrmBulkResponse> ExecuteMultiple(IEnumerable<OrganizationRequest> requests)
        {
            try
            {
                var bulkResponses = new List<CrmBulkResponse>();
                var done = 0;
                var reqCount = requests.Count();
                var maxBatch = (int)Math.Ceiling((decimal)(reqCount) / _batchSize);
                for (int i = 0; i < maxBatch; i++)
                {
                    var batchNum = i + 1;
                    var batchReqs = requests.Skip(done).Take(_batchSize);

                    var multipleReq = new ExecuteMultipleRequest
                    {
                        Requests = new OrganizationRequestCollection(),
                        Settings = new ExecuteMultipleSettings { ContinueOnError = true, ReturnResponses = true }
                    };

                    multipleReq.Requests.AddRange(batchReqs);

                    var response = _service.Execute(multipleReq) as ExecuteMultipleResponse;

                    var responses = response.Responses
                        .Select(resp => new CrmBulkResponse
                        {
                            Id = multipleReq.Requests[resp.RequestIndex].RequestId.GetValueOrDefault(Guid.Empty),
                            Success = resp.Fault == null,
                            Message = resp.Fault != null ? resp.Fault.Message : string.Empty,
                            Request = multipleReq.Requests[resp.RequestIndex],
                            Records = resp.Response != null && resp.Response is RetrieveMultipleResponse ? (resp.Response as RetrieveMultipleResponse).EntityCollection.Entities : null
                        });

                    bulkResponses.AddRange(responses);

                    // increment done counter
                    done += batchReqs.Count();
                }

                return bulkResponses;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Private Methods
    }
}
