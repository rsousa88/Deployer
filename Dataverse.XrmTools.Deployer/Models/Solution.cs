namespace Dataverse.XrmTools.Deployer.Models
{
    public class Solution
    {
        public string LogicalName { get; set; }
        public string DisplayName { get; set; }
        public string Version { get; set; }
        public bool IsManaged{ get; set; }
        public Publisher Publisher { get; set; }
        public byte[] SolutionBytes { get; set; }
    }

    public class Publisher
    {
        public string LogicalName { get; set; }
        public string DisplayName { get; set; }
    }
}