using System.Collections.Generic;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class Project
    {
        public Workspace Workspace { get; set; }
        public IList<Operation> Operations { get; set; }
    }
}
