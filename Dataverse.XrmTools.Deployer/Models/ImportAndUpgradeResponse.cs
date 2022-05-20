using Dataverse.XrmTools.Deployer.Enums;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class ImportAndUpgradeResponse
    {
        public Operation Operation { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
