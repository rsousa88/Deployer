// System
using System.Collections.Generic;

// Deployer
using Dataverse.XrmTools.Deployer.AppSettings;

// 3rd Party
using XrmToolBox.Extensibility;

namespace Dataverse.XrmTools.Deployer.Helpers
{
    public static class SettingsHelper
    {
        public static void GetSettings(out Settings settings)
        {
            try
            {
                if (!SettingsManager.Instance.TryLoad(typeof(DeployerControl), out settings))
                {
                    settings = new Settings { Instances = new List<Instance>(), Sorts = new List<Sort>(), Defaults = new Defaults() };
                    settings.SaveSettings();
                }
            }
            catch { throw; }
        }

        public static bool SaveSettings(this Settings settings)
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