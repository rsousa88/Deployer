using System.Threading.Tasks;

namespace Dataverse.XrmTools.Deployer.RepoInterfaces
{
    public interface INuGetRepo
    {
        Task<string> DownloadCoreToolsAsync(string toolsDir, string feed, string package);
    }
}
