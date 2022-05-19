using System;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class Solution
    {
        public Guid SolutionId{ get; set; }
        public string LogicalName { get; set; }
        public string DisplayName { get; set; }
    }
}