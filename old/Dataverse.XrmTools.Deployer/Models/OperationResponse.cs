using Dataverse.XrmTools.Deployer.Enums;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class OperationResponse
    {
        public bool Success { get; set; }
        public OperationStatus Status { get; set; }
        public string Message { get; set; }
    }
}
