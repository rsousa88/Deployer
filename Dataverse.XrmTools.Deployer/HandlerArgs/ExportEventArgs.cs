using Dataverse.XrmTools.Deployer.Enums;

namespace Dataverse.XrmTools.Deployer.HandlerArgs
{
    public class ExportEventArgs : OperationEventArgs
    {
        public PackageType PackageType { get; set; }
        public string ExportPath { get; set; }
    }
}
