using System.Collections.Generic;
using Microsoft.Xrm.Sdk;
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;

namespace Dataverse.XrmTools.Deployer.RepoInterfaces
{
    public interface ICrmRepo
    {
        /// <summary>
        /// Retrieve Solutions
        /// </summary>
        /// <param name="columns">[OPTIONAL] Columns to be retrieved</param>
        /// <param name="queryType">[OPTIONAL] Solution package type to retrieved (defaults to ALL - both unmanaged and managed)</param>
        /// <param name="connType">[OPTIONAL] Connection type to be used (defaults to TARGET - query target instance)</param>
        /// <returns>A list of Solutions</returns>
        IEnumerable<Entity> GetSolutions(string[] columns = null, PackageType queryType = PackageType.ALL, ConnectionType connType = ConnectionType.TARGET);

        /// <summary>
        /// Retrieve a single solution by logical name
        /// </summary>
        /// <param name="logicalName">Logical name of the solution to be retrieved</param>
        /// <param name="columns">[OPTIONAL] Columns to be retrieved</param>
        /// <param name="connType">[OPTIONAL] Connection type to be used (defaults to TARGET - query target instance)</param>
        /// <returns>A list of Solutions</returns>
        Entity GetSolution(string logicalName, string[] columns = null, ConnectionType connType = ConnectionType.TARGET);

        /// <summary>
        /// Update solution
        /// </summary>
        /// <param name="operation">Operation object that contains all the required data to update a referenced solution</param>
        void UpdateSolution(Operation operation);

        /// <summary>
        /// Export solution
        /// </summary>
        /// <param name="operation">Operation object that contains all the required data to export a referenced solution</param>
        void ExportSolution(Operation operation);

        /// <summary>
        /// Import solution
        /// </summary>
        /// <param name="solution">Solution object to be imported</param>
        /// <param name="progressMessage">Base message for the progress report</param>
        void ImportSolution(ImportOperation operation, string progressMessage);

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

        /// <summary>
        /// Publish all customizations
        /// </summary>
        void PublishCustomizations();
    }
}
