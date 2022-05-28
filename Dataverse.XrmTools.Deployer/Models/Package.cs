using Dataverse.XrmTools.Deployer.Enums;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class Package
    {
        public PackageType PackageType { get; set; }
        public string ExportPath { get; set; }
        public byte[] SolutionBytes { get; set; }
    }
}