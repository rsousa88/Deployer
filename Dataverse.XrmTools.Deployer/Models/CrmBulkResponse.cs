using System;
using System.Collections.Generic;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class CrmBulkResponse
    {
        public Guid Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public OrganizationRequest Request { get; set; }
        public IEnumerable<Entity> Records { get; set; }
    }
}
