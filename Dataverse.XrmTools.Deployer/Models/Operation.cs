using System;
using Dataverse.XrmTools.Deployer.Enums;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class Operation
    {
        public Guid OperationId { get; set; }
        public int Index { get; set; }
        public OperationType OperationType { get; set; }
        public Solution Solution { get; set; }
    }
}