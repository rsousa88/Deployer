using System;
using Dataverse.XrmTools.Deployer.Enums;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class DependencyComponent
    {
        public ComponentType Type { get; set; }
        public Guid Id { get; set; }
        public string LogicalName { get; set; }
        public string DisplayName { get; set; }
    }
}
