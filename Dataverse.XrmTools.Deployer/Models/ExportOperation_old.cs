using Dataverse.XrmTools.Deployer.Enums;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class ExportOperation_old : Operation
    {
        public PackageType PackageType { get; set; }
        public string PackageName { get; set; }
        //public Guid QuickUpdateId { get; set; }
        //public Guid QuickUnpackId { get; set; }
        //public Guid QuickPackId { get; set; }
    }
}