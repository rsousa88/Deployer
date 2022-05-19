// System
using System.Collections.Generic;

// ActiveLayerExplorer
using Dataverse.XrmTools.Deployer.AppSettings;

// 3rd Party
using XrmToolBox.Extensibility;

namespace Dataverse.XrmTools.Deployer.Helpers
{
    public class SettingsHelper
    {
        public static void GetSettings(out Settings settings)
        {
            try
            {
                if (!SettingsManager.Instance.TryLoad(typeof(DeployerControl), out settings))
                {
                    settings = new Settings { Instances = new List<Instance>(), Sorts = new List<Sort>() };
                    SetSettings(settings);
                }
            }
            catch { throw; }
        }

        public static bool SetSettings(Settings settings)
        {
            try
            {
                SettingsManager.Instance.Save(typeof(DeployerControl), settings);
                return true;
            }
            catch { throw; }
        }
    }
}