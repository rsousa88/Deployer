namespace Dataverse.XrmTools.Deployer.Models
{
    public class UpdateOperation : Operation
    {
        public Solution Solution { get; set; }
        public string Version { get; set; }
    }
}