// System
using System;

namespace Dataverse.XrmTools.Deployer.Enums
{
    [Flags]
    public enum Operation
    {
        Import = 1,
        Upgrade = 2
    }
}
