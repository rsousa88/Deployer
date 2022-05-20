using Dataverse.XrmTools.Deployer.Models;

namespace Dataverse.XrmTools.Deployer.RepoInterfaces
{
    public interface ICrmRepo
    {
        /// <summary>
        /// Import solution
        /// </summary>
        /// <param name="solution">Solution object to be imported</param>
        void ImportSolution(Solution solution);

        /// <summary>
        /// Upgrade solution
        /// </summary>
        /// <param name="solution">Solution object to be upgraded</param>
        void UpgradeSolution(Solution solution);
    }
}
