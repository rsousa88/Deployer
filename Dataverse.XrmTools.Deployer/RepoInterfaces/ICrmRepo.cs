using System.Collections.Generic;
using Microsoft.Xrm.Sdk;
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;
using System;

namespace Dataverse.XrmTools.Deployer.RepoInterfaces
{
    public interface ICrmRepo
    {
        /// <summary>
        /// Retrieve Solutions (with Publisher) of both types (managed and unmanaged)
        /// </summary>
        /// <param name="connType">[OPTIONAL] Connection type to be used (defaults to TARGET - query target instance)</param>
        /// <returns>A list of Solutions with Publishers</returns>
        IEnumerable<JointRecord> GetAllSolutions(ConnectionType connType = ConnectionType.TARGET);

        /// <summary>
        /// Retrieve Solutions (with Publisher) of a specific type (managed or unmanaged)
        /// </summary>
        /// <param name="queryType">[OPTIONAL] Solution package type to retrieved (defaults to ALL - both unmanaged and managed)</param>
        /// <param name="connType">[OPTIONAL] Connection type to be used (defaults to TARGET - query target instance)</param>
        /// <returns>A list of Solutions with Publishers</returns>
        IEnumerable<JointRecord> GetSolutionsByType(PackageType queryType = PackageType.UNMANAGED, ConnectionType connType = ConnectionType.TARGET);

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
        /// <param name="update">Operation object that contains all the required data to update a referenced solution</param>
        void UpdateSolution(UpdateOperation update);

        ///// <summary>
        ///// Export solution
        ///// </summary>
        ///// <param name="export">Operation object that contains all the required data to export a referenced solution</param>
        //void ExportSolution(ExportOperation export);

        ///// <summary>
        ///// Import solution
        ///// </summary>
        ///// <param name="import">Operation object that contains all the required data to import a referenced solution</param>
        ///// <param name="progressMessage">Base message for the progress report</param>
        //void ImportSolution(ImportOperation import, string progressMessage);

        ///// <summary>
        ///// Upgrade solution
        ///// </summary>
        ///// <param name="solution">Solution object to be upgraded</param>
        //void UpgradeSolution(Solution solution);

        ///// <summary>
        ///// Delete solution
        ///// </summary>
        ///// <param name="solution">Solution object to be deleted</param>
        //void DeleteSolution(Solution solution);

        ///// <summary>
        ///// Unpack solution
        ///// </summary>
        ///// <param name="unpack">Operation object that contains all the required data to unpack a referenced solution</param>
        //void UnpackSolution(UnpackOperation unpack);

        ///// <summary>
        ///// Pack solution
        ///// </summary>
        ///// <param name="pack">Operation object that contains all the required data to pack a referenced solution</param>
        //void PackSolution(PackOperation pack);

        /// <summary>
        /// Publish all customizations
        /// </summary>
        void PublishCustomizations();
    }
}
