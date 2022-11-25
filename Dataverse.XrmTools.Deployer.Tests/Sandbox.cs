using System;
using System.Linq;
using System.Xml.Linq;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;
using Xunit;
using System.Text;

namespace Dataverse.XrmTools.Deployer.Tests
{
    public class Sandbox
    {
        [Fact]
        public void XmlTest()
        {
            var xml = "<MissingDependencies><MissingDependency><Required type=\"26\" schemaName=\"HGO Teams\" displayName=\"HGO Teams\" parentSchemaName=\"team\" parentDisplayName=\"Team\" solution=\"Active\" id=\"{f5d63d01-9269-ed11-9561-000d3adf73b8}\" /><Dependent type=\"80\" schemaName=\"hgo_HGOService\" displayName=\"HGO Service\" /></MissingDependency><MissingDependency><Required type=\"26\" schemaName=\"HGO Teams 2\" displayName=\"HGO Teams 2\" parentSchemaName=\"team\" parentDisplayName=\"Team\" solution=\"Active\" id=\"{f5d63d01-9269-ed11-9561-000d3adf73b8}\" /><Dependent type=\"80\" schemaName=\"hgo_HGOService2\" displayName=\"HGO Service 2\" /></MissingDependency></MissingDependencies>";
            var depsDoc = XDocument.Parse(xml);

            var dependencies = depsDoc.Root.Descendants("MissingDependency").Select(node =>
            {
                var required = node.Descendants("Required").First();
                var dependent = node.Descendants("Dependent").First();

                return new ImportDependency
                {
                    Required = new DependencyComponent
                    {
                        Id = required.Attribute("id") != null ? Guid.Parse(required.Attribute("id").Value) : Guid.Empty,
                        Type = required.Attribute("type") != null ? (ComponentType)required.Attribute("type").Value.TryParse<int>(int.TryParse) : ComponentType.Unknown,
                        LogicalName = required.Attribute("schemaName") != null ? required.Attribute("schemaName").Value : string.Empty,
                        DisplayName = required.Attribute("displayName") != null ? required.Attribute("displayName").Value : string.Empty
                    },
                    Dependent = new DependencyComponent
                    {
                        Id = dependent.Attribute("id") != null ? Guid.Parse(dependent.Attribute("id").Value) : Guid.Empty,
                        Type = dependent.Attribute("type") != null ? (ComponentType)dependent.Attribute("type").Value.TryParse<int>(int.TryParse) : ComponentType.Unknown,
                        LogicalName = dependent.Attribute("schemaName") != null ? dependent.Attribute("schemaName").Value : string.Empty,
                        DisplayName = dependent.Attribute("displayName") != null ? dependent.Attribute("displayName").Value : string.Empty
                    }
                };
            });

            var sb = new StringBuilder($"FAILURE: ");
            if (dependencies.Any())
            {
                sb.Append($"There are unresolved import dependencies");
                sb.AppendLine();
                var groups = dependencies.GroupBy(dep => dep.Dependent.LogicalName);

                foreach (var grp in groups)
                {
                    sb.AppendLine($"{grp.First().Dependent.Type} '{grp.First().Dependent.DisplayName}' ({grp.First().Dependent.LogicalName}) requires the following components:");
                    foreach (var dep in grp)
                    {
                        sb.AppendLine($"\tType: {dep.Required.Type}");
                        sb.AppendLine($"\tDisplay Name: {dep.Required.DisplayName}");
                        sb.AppendLine($"\tLogical Name: {dep.Required.LogicalName}");
                        sb.AppendLine($"\tComponent ID: {dep.Required.Id}");
                        sb.AppendLine();
                    }
                }
            }

            var str = sb.ToString();

            Assert.NotNull(dependencies);
            Assert.True(dependencies.Count() >0);
        }
    }
}
