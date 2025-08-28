using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class Record : Entity
    {
        public Record(string logicalName, IEnumerable<string> columns, Entity entity)
        {
            LogicalName = logicalName;

            var collection = new AttributeCollection();
            foreach (var col in columns)
            {
                if (entity.Attributes.Contains(col)) { collection.Add(col, entity.Attributes[col]); }
            }

            Attributes = collection;
        }
    }
}
