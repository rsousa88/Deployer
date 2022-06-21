using System;
using System.Linq;
using System.Collections.Generic;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class OperationGroup
    {
        public OperationGroup(IEnumerable<Operation> operations, int index)
        {
            var groupId = Guid.NewGuid();

            GroupId = groupId;
            Index = index;
            Operations = operations.Select(op =>
            {
                op.GroupId = groupId;
                return op;
            });
        }

        public Guid GroupId { get; }
        public int Index { get; set; }
        public IEnumerable<Operation> Operations { get; }
    }
}