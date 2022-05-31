using System.Collections.Generic;
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;

namespace Dataverse.XrmTools.Deployer.Helpers
{
    public delegate IEnumerable<Solution> SolutionsRetrieve(PackageType queryType, ConnectionType connType);
    public delegate Solution SingleSolutionRetrieve(string logicalName, ConnectionType connType);
    public delegate IEnumerable<Operation> OperationsRetrieve(OperationType opType);
    public delegate void WorkingStateSet(bool working);
}
