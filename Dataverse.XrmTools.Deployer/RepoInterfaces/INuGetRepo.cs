using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dataverse.XrmTools.Deployer.RepoInterfaces
{
    public interface INuGetRepo
    {
        Task<Dictionary<string, string>> DownloadCoreToolsAsync(string toolsDir, string feed, string package);
    }
}
