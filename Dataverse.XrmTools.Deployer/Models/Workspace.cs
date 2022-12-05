using System.Collections.Generic;
using Dataverse.XrmTools.Deployer.AppSettings;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class Workspace
    {
        public Instance Source { get; set; }
        public IEnumerable<Solution> Solutions { get; set; }
        public string RootPath { get; set; }
        public string ProjectDisplayName { get; set; }
        public string ProjectLogicalName { get; set; }
        public string Version { get; set; }
    }
}
