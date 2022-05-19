namespace Dataverse.XrmTools.Deployer.Models
{
    public class ComponentType
    {
        public int Value { get; set; }
        public string LogicalName { get; set; }
        public string DisplayName { get; set; }
        public int ComponentCount { get; set; }
        public int? LayersCount { get; set; }
    }
}