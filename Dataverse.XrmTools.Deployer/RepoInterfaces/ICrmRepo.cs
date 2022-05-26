using System.Collections.Generic;
using Microsoft.Xrm.Sdk;
using Dataverse.XrmTools.Deployer.Models;

namespace Dataverse.XrmTools.Deployer.RepoInterfaces
{
    public interface ICrmRepo
    {
        /// <summary>
        /// Retrieve all managed Solutions
        /// </summary>
        /// <param name="columns">Columns to be retrieved</param>
        /// <returns>A list of Solutions</returns>
        IEnumerable<Entity> GetManagedSolutions(string[] columns);

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

        /// <summary>
        /// Delete solution
        /// </summary>
        /// <param name="solution">Solution object to be deleted</param>
        void DeleteSolution(Solution solution);
    }
}
