using Dataverse.XrmTools.Deployer.Enums;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class ExportOperation : Operation
    {
        public PackageType PackageType { get; set; }
        public string PackageName { get; set; }
        public bool UpdateVersion { get; set; }
        public string Version { get; set; }
        public bool Unpack { get; set; }
        public bool Pack { get; set; }
    }
}