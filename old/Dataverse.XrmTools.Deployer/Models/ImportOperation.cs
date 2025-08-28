using Dataverse.XrmTools.Deployer.Enums;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class ImportOperation : Operation
    {
        public Package Package { get; set; }
        public bool HoldingSolution { get; set; }
        public bool OverwriteUnmanaged { get; set; }
        public bool PublishWorkflows { get; set; }
    }
}