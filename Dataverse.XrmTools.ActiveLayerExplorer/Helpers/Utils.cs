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
using System.Text.RegularExpressions;

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

                var item = new ListViewItem(new string[] { solution.DisplayName });
                item.Tag = solution.SolutionId;
                return item;
            }
            if (value is ComponentType)
            {
                var componentType = value as ComponentType;
                var item = new ListViewItem(new string[] { componentType.DisplayName, componentType.ComponentCount.ToString(), componentType.LayersCount.ToString()});
                item.Tag = componentType.Value;
                return item;
            }
            if (value is ActiveLayer)
            {
                var layer = value as ActiveLayer;
                var item = new ListViewItem(new string[] { layer.Name, layer.SolutionComponent.ObjectId.ToString(), layer.SolutionComponent.Type.DisplayName });
                item.Tag = layer.Id;
                return item;
            }
            if (value is OperationResult)
            {
                var result = value as OperationResult;
                var item = new ListViewItem(new string[] { result.ComponentName, result.Description });
                item.Tag = result.ComponentId;
                return item;
            }

            return null;
        }

        public static object ToObject<T>(this ListViewItem lvItem, T output, Tuple<string, object> parameters = null)
        {
            if (output is Solution)
            {
                return new Solution
                {
                    SolutionId = (Guid)lvItem.Tag,
                    DisplayName = lvItem.SubItems[0].Text
                };
            }
            if (output is ComponentType)
            {
                return new ComponentType
                {
                    Value = (int)lvItem.Tag,
                    DisplayName = lvItem.SubItems[0].Text,
                    ComponentCount = lvItem.SubItems[1].Text.ToInt().Value,
                    LayersCount = lvItem.SubItems[2].Text.ToInt().Value
                };
            }

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

        public static string RemoveSpaces(this string plain)
        {
            return Regex.Replace(plain, @"\s+", "");
        }
    }
}
