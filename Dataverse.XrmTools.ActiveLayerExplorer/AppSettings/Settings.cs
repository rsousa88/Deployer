﻿// System
using System;
using System.Linq;
using System.Collections.Generic;

// ActiveLayerExplorer
using Dataverse.XrmTools.ActiveLayerExplorer.Models;

namespace Dataverse.XrmTools.ActiveLayerExplorer.AppSettings
{
    public class Settings
    {
        public List<Instance> Instances { get; set; }
        public List<Sort> Sorts { get; set; }

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