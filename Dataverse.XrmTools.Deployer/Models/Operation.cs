using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.HandlerArgs;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class Operation
    {
        public OperationType Type { get; set; }
        public Solution Solution{ get; set; }
        public OperationEventArgs Data { get; set; }
    }
}