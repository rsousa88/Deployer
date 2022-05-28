using Dataverse.XrmTools.Deployer.Enums;
using System;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class Solution
    {
        public Guid SolutionId { get; set; }
        public string LogicalName { get; set; }
        public string DisplayName { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public bool IsManaged{ get; set; }
        public Publisher Publisher { get; set; }
        public Package Package { get; set; }
    }

    public class Publisher
    {
        public string LogicalName { get; set; }
        public string DisplayName { get; set; }
    }
}