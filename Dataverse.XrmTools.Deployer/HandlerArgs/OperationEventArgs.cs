using System;
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;

namespace Dataverse.XrmTools.Deployer.HandlerArgs
{
    public class OperationEventArgs : EventArgs
    {
        public OperationType Type { get; set; }
        public Solution Solution { get; set; }
    }
}
