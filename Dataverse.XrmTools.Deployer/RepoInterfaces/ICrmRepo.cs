// System
using System;
using System.Collections.Generic;

// Microsoft
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Crm.Sdk.Messages;

// ActiveLayerExplorer
using Dataverse.XrmTools.Deployer.Models;

namespace Dataverse.XrmTools.Deployer.RepoInterfaces
{
    public interface ICrmRepo
    {
        /// <summary>
        /// Import solution
        /// </summary>
        /// <param name="solution">Solution object to be imported</param>
        /// <returns>A custom Import response object</returns>
        ImportAndUpgradeResponse ImportSolution(Solution solution);

        /// <summary>
        /// Upgrade solution
        /// </summary>
        /// <param name="solution">Solution object to be upgraded</param>
        /// <returns>A custom Upgrade response object</returns>
        ImportAndUpgradeResponse UpgradeSolution(Solution solution);








        /// <summary>
        /// Retrieve all managed Solutions
        /// </summary>
        /// <param name="columns">Columns to be retrieved</param>
        /// <returns>A list of Solutions</returns>
        IEnumerable<Entity> GetManagedSolutions(string[] columns);

        /// <summary>
        /// Retrieve all components for a given solution
        /// </summary>
        /// <param name="columns">Columns to be retrieved</param>
        /// <param name="solutionId">Solution ID</param>
        /// <returns>A list of Solution Components</returns>
        IEnumerable<Entity> GetSolutionComponents(string[] columns, Guid solutionId);

        /// <summary>
        /// Retrieve all active solution layers for a list of solution components
        /// </summary>
        /// <param name="columns">Columns to be retrieved</param>
        /// <param name="solutionComponents">The solution components to check for active layers</param>
        /// <returns>A list of Active Layers</returns>
        IEnumerable<ActiveLayer> GetActiveLayers(string[] columns, IEnumerable<SolutionComponent> solutionComponents);

        /// <summary>
        /// Delete active solution layers
        /// </summary>
        /// <param name="layers">Solution layers list to be deleted</param>
        IEnumerable<CrmBulkResponse> DeleteLayers(IEnumerable<ActiveLayer> layers);

        /// <summary>
        /// Retrieve Metadata of a single Table Column
        /// </summary>
        /// <param name="tableName">Logical name of the Table</param>
        /// <param name="columnName">Logical name of the Column</param>
        /// <returns></returns>
        EnumAttributeMetadata GetOptionSetMetadata(string tableName, string columnName);

        /// <summary>
        /// Retrieve an enumerable list of records
        /// </summary>
        /// <param name="query">Query expression to be executed</param>
        /// <param name="batchSize">Optional batch size</param>
        /// <returns></returns>
        IEnumerable<Entity> GetRecords(QueryExpression query, int batchSize = 250);

        /// <summary>
        /// Retrieves records by using Query Expression
        /// </summary>
        /// <param name="query">Query Expression object</param>
        /// <returns>The Entity Collection with the result of the query</returns>
        EntityCollection GetCollectionByExpression(QueryExpression query, int batchSize = 250);
    }
}
