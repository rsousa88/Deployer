using System;
using Microsoft.Xrm.Sdk;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class ActiveLayer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public SolutionComponent SolutionComponent { get; set; }
    }
}