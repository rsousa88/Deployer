using System;
using Dataverse.XrmTools.Deployer.Models;

namespace Dataverse.XrmTools.Deployer.HandlerArgs
{
    public class ImportEventArgs : OperationEventArgs
    {
        public Solution Solution { get; set; }
    }
}
