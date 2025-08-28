using Microsoft.Xrm.Sdk;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class JointRecord
    {
        public JointRecord() { }

        public JointRecord(Entity record, Entity related)
        {
            Record = (Record)record;
            Related = (Record)related;
        }

        public Record Record { get; set; }
        public Record Related{ get; set; }
    }
}
