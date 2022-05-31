namespace Dataverse.XrmTools.Deployer.Models
{
    public class ExportOperation : Operation
    {
        public bool UnpackSolution { get; set; }
        public PackagerOptions Packager { get; set; }
    }
}