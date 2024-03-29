﻿// System
using System;
using System.Linq;
using System.Collections.Generic;

namespace Dataverse.XrmTools.Deployer.AppSettings
{
    public class Settings
    {
        public List<Instance> Instances { get; set; }
        public List<Sort> Sorts { get; set; }
        public string WorkingDirectory { get; set; }
        public string PackagerPath { get; set; }
        public string PackagerVersion { get; set; }

        public Instance this[Guid orgId]
        {
            get
            {
                if (Instances is null)
                {
                    Instances = new List<Instance>();
                }

                return Instances.Where(org => org.Id.Equals(orgId)).FirstOrDefault();
            }
        }
    }
}
