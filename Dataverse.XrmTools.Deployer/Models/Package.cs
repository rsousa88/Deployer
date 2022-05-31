using Dataverse.XrmTools.Deployer.Enums;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class Package
    {
        public PackageType Type { get; set; }
        public string Name { get; set; }
        public string ExportPath { get; set; }
        public string UnpackPath { get; set; }
        public byte[] Bytes { get; set; }
    }
}