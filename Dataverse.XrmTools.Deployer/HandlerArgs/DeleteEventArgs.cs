using System;
using Dataverse.XrmTools.Deployer.Models;

namespace Dataverse.XrmTools.Deployer.HandlerArgs
{
    public class DeleteEventArgs : EventArgs
    {
        public Solution Solution { get; set; }
    }
}
