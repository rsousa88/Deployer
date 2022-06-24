using Dataverse.XrmTools.Deployer.Enums;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class PackOperation : Operation
    {
        public OperationMode Mode{ get; set; }
        public string WorkingDir { get; set; }
        public string Packager { get; set; }
        public string Action { get; set; }
        public string ZipFile { get; set; }
        public string Folder { get; set; }
        public string PackageType { get; set; }
        public string Map { get; set; }
    }
}