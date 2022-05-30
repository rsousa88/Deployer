namespace Dataverse.XrmTools.Deployer.Models
{
    public class ImportOperation : Operation
    {
        public bool HoldingSolution { get; set; }
        public bool OverwriteUnmanaged { get; set; }
        public bool PublishWorkflows { get; set; }
    }
}