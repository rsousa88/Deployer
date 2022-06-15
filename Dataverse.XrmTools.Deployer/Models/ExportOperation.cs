using System;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class ExportOperation : Operation
    {
        public Guid QuickUpdateId { get; set; }
        public Guid QuickUnpackId { get; set; }
        public Guid QuickPackId { get; set; }
    }
}