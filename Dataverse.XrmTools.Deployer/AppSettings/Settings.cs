// System
using System;
using System.Linq;
using System.Collections.Generic;

namespace Dataverse.XrmTools.Deployer.AppSettings
{
    public class Settings
    {
        public List<Instance> Instances { get; set; }
        public List<Sort> Sorts { get; set; }
        public int BatchSize { get; set; }
        public string Filter { get; set; }

        public Instance this[Guid orgId]
        {
            get
            {
                if (Instances == null)
                {
                    Instances = new List<Instance>();
                }

                return Instances.Where(org => org.Id.Equals(orgId)).FirstOrDefault();
            }
        }
    }
}
