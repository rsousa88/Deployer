using System;
using Dataverse.XrmTools.Deployer.Models;

namespace Dataverse.XrmTools.Deployer.HandlerArgs
{
    public class ExportEventArgs : EventArgs
    {
        public Solution Solution { get; set; }
    }
}
