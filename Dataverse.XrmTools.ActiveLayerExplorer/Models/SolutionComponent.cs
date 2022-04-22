using System;

namespace Dataverse.XrmTools.ActiveLayerExplorer.Models
{
    public class SolutionComponent
    {
        public Guid Id { get; set; }
        public Guid SolutionId { get; set; }
        public Guid ObjectId { get; set; }
        public int Type { get; set; }
        public string TypeName { get; set; }
        public int ActiveLayers { get; set; }
    }
}