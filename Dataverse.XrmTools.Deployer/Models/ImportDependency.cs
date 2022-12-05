namespace Dataverse.XrmTools.Deployer.Models
{
    public class ImportDependency
    {
        public DependencyComponent Required { get; set; }
        public DependencyComponent Dependent { get; set; }
    }
}
