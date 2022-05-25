using Dataverse.XrmTools.Deployer.Enums;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class Operation
    {
        public OperationType Type { get; set; }
        public Solution Solution{ get; set; }
    }
}