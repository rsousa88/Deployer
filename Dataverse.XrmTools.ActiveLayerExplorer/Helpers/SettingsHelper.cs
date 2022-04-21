// System
using System.Collections.Generic;

// ActiveLayerExplorer
using Dataverse.XrmTools.ActiveLayerExplorer.AppSettings;

// 3rd Party
using XrmToolBox.Extensibility;

namespace Dataverse.XrmTools.ActiveLayerExplorer.Helpers
{
    public class SettingsHelper
    {
        public static void GetSettings(out Settings settings)
        {
            try
            {
                if (!SettingsManager.Instance.TryLoad(typeof(ActiveLayerExplorerControl), out settings))
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
                SettingsManager.Instance.Save(typeof(ActiveLayerExplorerControl), settings);
                return true;
            }
            catch { throw; }
        }
    }
}