// System
using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

// Microsoft
using Microsoft.Xrm.Sdk;

// ActiveLayerExplorer
using Dataverse.XrmTools.ActiveLayerExplorer.Models;
using Dataverse.XrmTools.ActiveLayerExplorer.AppSettings;

namespace Dataverse.XrmTools.ActiveLayerExplorer.Helpers
{
    public static class Utils
    {
        public delegate bool TryParseHandler<T>(string value, out T result);
        public static T? TryParse<T>(this string value, TryParseHandler<T> handler) where T : struct
        {
            if (string.IsNullOrEmpty(value)) { return null; }

            if (handler(value, out T result)) { return result; }

            return null;
        }

        public static int? ToInt<T>(this T value)
        {
            return value.ToString().TryParse<int>(int.TryParse);
        }

        public static Guid ToGuid<T>(this T value)
        {
            var guid = value.ToString().TryParse<Guid>(Guid.TryParse);
            return guid.HasValue ? guid.Value : Guid.Empty;
        }

        public static ListViewItem ToListViewItem<T>(this T value, Tuple<string, object> parameters = null)
        {
            if (value is Solution) {
                var solution = value as Solution;
                return new ListViewItem(new string[] { solution.SolutionId.ToString(), solution.LogicalName, solution.DisplayName });
            }
            if (value is ComponentType)
            {
                var componentType = value as ComponentType;
                return new ListViewItem(new string[] { componentType.Label, componentType.ComponentCount.ToString() });
            }
            //if (value is Models.Attribute) {
            //    var attribute = value as Models.Attribute;
            //    return new ListViewItem(new string[] { attribute.DisplayName, attribute.LogicalName, attribute.Type }); ;
            //}
            //if (value is Entity)
            //{
            //    var entity = value as Entity;
            //    if (parameters == null || !parameters.Item1.Equals("table") || !(parameters.Item2 is Dictionary<string, string> dictionary)) { throw new Exception("Invalid parameters for Entity type cast"); }

            //    var attrName = dictionary.FirstOrDefault(kvp => kvp.Key.Equals("attributename")).Value;
            //    var actionName = dictionary.FirstOrDefault(kvp => kvp.Key.Equals("action")).Value;
            //    var description = dictionary.FirstOrDefault(kvp => kvp.Key.Equals("description")).Value;

            //    return new ListViewItem(new string[]
            //    {
            //        actionName,
            //        entity.Id.ToString(),
            //        entity.GetAttributeValue<string>(attrName),
            //        description
            //    });
            //}
            //if (value is ExecuteMultipleResponseItem)
            //{
            //    var response = value as ExecuteMultipleResponseItem;
            //    if (parameters == null || !parameters.Item1.Equals("table") || !(parameters.Item2 is Table table)) { throw new Exception("Invalid parameters for ExecuteMultipleResponseItem type cast"); }

            //    return new ListViewItem(new string[] { table.DisplayName, response.Fault.Message });
            //}

            return null;
        }

        public static object ToObject<T>(this ListViewItem lvItem, T output, Tuple<string, object> parameters = null)
        {
            if (output is Solution)
            {
                return new Solution
                {

                    SolutionId = Guid.Parse(lvItem.SubItems[0].Text),
                    LogicalName = lvItem.SubItems[1].Text,
                    DisplayName = lvItem.SubItems[2].Text
                };
            }
            //if (output is Models.Attribute)
            //{
            //    return new Models.Attribute
            //    {
            //        DisplayName = lvItem.SubItems[0].Text,
            //        LogicalName = lvItem.SubItems[1].Text,
            //        Type = lvItem.SubItems[2].Text
            //    };
            //}
            //if (output is Entity)
            //{
            //    if (parameters == null || !parameters.Item1.Equals("table") || !(parameters.Item2 is Dictionary<string, string> dictionary)) { throw new Exception("Invalid parameters for Entity type cast"); }

            //    var logicalName = dictionary.FirstOrDefault(kvp => kvp.Key.Equals("logicalname")).Value;

            //    return new Entity(logicalName, Guid.Parse(lvItem.SubItems[1].Text));
            //}

            return null;
        }

        public static T DeserializeObject<T>(this string json, DataContractJsonSerializerSettings settings = null)
        {
            using (var stream = new MemoryStream())
            {
                if (settings == null) { settings = new DataContractJsonSerializerSettings(); }

                var serializer = new DataContractJsonSerializer(typeof(T), settings);

                var writer = new StreamWriter(stream);
                writer.Write(json);
                writer.Flush();
                stream.Position = 0;
                return (T)serializer.ReadObject(stream);
            }
        }

        public static string SerializeObject<T>(this object obj)
        {
            using (var stream = new MemoryStream())
            {

                var serializer = new DataContractJsonSerializer(typeof(T));

                using (var writer = JsonReaderWriterFactory.CreateJsonWriter(stream, Encoding.UTF8, false, true))
                {
                    serializer.WriteObject(writer, obj);
                }

                stream.Position = 0;

                var reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
        }

        public static T ToEnum<T>(this string enumString)
        {
            return (T)Enum.Parse(typeof(T), enumString);
        }

        public static bool MatchFilter(this Solution solution, string filter)
        {
            if (string.IsNullOrWhiteSpace(filter)) { return true; }

            filter = filter.ToLower();

            if (solution.DisplayName.ToLower().Contains(filter) || solution.LogicalName.ToLower().Contains(filter)) { return true; }
            return false;
        }

        public static void Sort(this ListView listview, Settings settings, int column)
        {
            var savedSort = settings.Sorts.FirstOrDefault(sor => sor.ListViewName.Equals(listview.Name));
            if (savedSort == null)
            {
                savedSort = new Sort { ListViewName = listview.Name };
                settings.Sorts.Add(savedSort);
            }

            if (!savedSort.ColumnIndex.HasValue || !savedSort.ColumnIndex.Value.Equals(column))
            {
                savedSort.ColumnIndex = column;
                listview.Sorting = SortOrder.Ascending;
            }
            else
            {
                listview.Sorting = listview.Sorting.Equals(SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            }

            listview.ListViewItemSorter = new ListViewComparer(column, listview.Sorting);
        }
    }
}
