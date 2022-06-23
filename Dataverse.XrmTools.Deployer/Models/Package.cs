using Dataverse.XrmTools.Deployer.Enums;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class Package
    {
        public PackageType Type { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public byte[] Bytes { get; set; }
    }
}