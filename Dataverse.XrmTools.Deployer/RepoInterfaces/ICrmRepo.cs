using System.Collections.Generic;
using Microsoft.Xrm.Sdk;
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.HandlerArgs;

namespace Dataverse.XrmTools.Deployer.RepoInterfaces
{
    public interface ICrmRepo
    {
        /// <summary>
        /// Retrieve Solutions
        /// </summary>
        /// <param name="columns">Columns to be retrieved</param>
        /// <param name="managedOnly">Retrieve all or only managed solutions</param>
        /// <returns>A list of Solutions</returns>
        IEnumerable<Entity> GetSolutions(string[] columns, PackageType queryType = PackageType.ALL);

        /// <summary>
        /// Export solution
        /// </summary>
        /// <param name="solution">Solution object to be exported</param>
        void ExportSolution(Solution solution, ExportEventArgs data);

        /// <summary>
        /// Import solution
        /// </summary>
        /// <param name="solution">Solution object to be imported</param>
        void ImportSolution(Solution solution, ImportEventArgs data);

        /// <summary>
        /// Upgrade solution
        /// </summary>
        /// <param name="solution">Solution object to be upgraded</param>
        void UpgradeSolution(Solution solution, ImportEventArgs data);

        /// <summary>
        /// Delete solution
        /// </summary>
        /// <param name="solution">Solution object to be deleted</param>
        void DeleteSolution(Solution solution, DeleteEventArgs data);
    }
}
