using System;

namespace Dataverse.XrmTools.ActiveLayerExplorer.Models
{
    public class SolutionComponent
    {
        public Guid Id { get; set; }
        public Guid SolutionId { get; set; }
        public Guid ObjectId { get; set; }
        public ComponentType Type { get; set; }
    }
}