using System;
using Dataverse.XrmTools.Deployer.Models;

namespace Dataverse.XrmTools.Deployer.HandlerArgs
{
    public class ImportEventArgs : EventArgs
    {
        public Solution Solution { get; set; }
    }
}
