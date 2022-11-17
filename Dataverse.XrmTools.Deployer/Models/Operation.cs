using System;
using Dataverse.XrmTools.Deployer.Enums;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class Operation
    {
        public Operation()
        {
            OperationId = Guid.NewGuid();
        }

        public Guid OperationId { get; }
        public int Index { get; set; }
        public OperationType OperationType { get; set; }
        public Solution Solution { get; set; }
        public string Description { get; set; }
    }
}