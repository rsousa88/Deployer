namespace Dataverse.XrmTools.Deployer.Models
{
    public class UpdateOperation : Operation
    {
        public string OldDisplayName { get; set; }
        public string OldVersion { get; set; }
        public string OldDescription { get; set; }
    }
}