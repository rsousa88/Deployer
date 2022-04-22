// System
using System;
using System.Collections.Generic;

// Microsoft
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Metadata;

// ActiveLayerExplorer
using Dataverse.XrmTools.ActiveLayerExplorer.Models;

namespace Dataverse.XrmTools.ActiveLayerExplorer.RepoInterfaces
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
        /// 
        /// </summary>
        /// <param name="columns">Columns to be retrieved</param>
        /// <param name="solutionId">Solution ID</param>
        /// <returns>A list of Solution Components</returns>
        IEnumerable<Entity> GetSolutionComponents(string[] columns, Guid solutionId);

        /// <summary>
        /// Retrieve Metadata from all Tables
        /// </summary>
        /// <returns>A list of EntityMetadata</returns>
        IEnumerable<EntityMetadata> GetOrgTables();

        /// <summary>
        /// Retrieve Metadata of a single Table
        /// </summary>
        /// <param name="logicalName">Logical name of the Table</param>
        /// <returns>EntityMetadata of a Table</returns>
        EntityMetadata GetTableMetadata(string logicalName);

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
        /// Retrieve a list of users by an array of domains
        /// </summary>
        /// <param name="domainList">The array of domains to be used in the query</param>
        /// <param name="columns">Select columns to be retrieved</param>
        /// <returns>Enumerable list of records</returns>
        IEnumerable<Entity> GetUsersInDomainList(string[] domainList, string[] columns);

        /// <summary>
        /// Retrieve a list of teams by an array of names
        /// </summary>
        /// <param name="nameList">The array of names to be used in the query</param>
        /// <param name="columns">Select columns to be retrieved</param>
        /// <returns>Enumerable list of records</returns>
        IEnumerable<Entity> GetTeamsInNameList(string[] nameList, string[] columns);

        /// <summary>
        /// Retrieves records by using Query Expression
        /// </summary>
        /// <param name="query">Query Expression object</param>
        /// <returns>The Entity Collection with the result of the query</returns>
        EntityCollection GetCollectionByExpression(QueryExpression query, int batchSize = 250);

        /// <summary>
        /// Retrieves records by using fetch XML
        /// </summary>
        /// <param name="fetchXml">Fetch XML string query</param>
        /// <returns>The Entity Collection with the result of the fetch query</returns>
        EntityCollection GetCollectionByFetchXml(string fetchXml, int batchSize = 250);

        /// <summary>
        /// Create records in bulk
        /// </summary>
        /// <param name="records">Entity list of the records to be created</param>
        /// <returns>List of responses</returns>
        IEnumerable<CrmBulkResponse> CreateRecords(IEnumerable<Entity> records);

        /// <summary>
        /// Update records in bulk
        /// </summary>
        /// <param name="records">Entity list of the records to be updated</param>
        /// <returns>List of responses</returns>
        IEnumerable<CrmBulkResponse> UpdateRecords(IEnumerable<Entity> records);

        /// <summary>
        /// Delete records in bulk
        /// </summary>
        /// <param name="records">Entity list of the records to be deleted</param>
        /// <returns>List of responses</returns>
        IEnumerable<CrmBulkResponse> DeleteRecords(IEnumerable<Entity> records);
    }
}
