// System
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

// Deployer
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.AppSettings;
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.External;

// 3rd Party
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Dataverse.XrmTools.Deployer.Helpers
{
    public static class Utils
    {
        public delegate bool TryParseHandler<T>(string value, out T result);
        public static T? TryParse<T>(this string value, TryParseHandler<T> handler) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            if (handler(value, out T result))
            {
                return result;
            }
            return null;
        }

        public static T DeserializeObject<T>(this string json)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects
            };

            return JsonConvert.DeserializeObject<T>(json, settings);
        }

        public static T DeserializeObject<T>(this string json, params JsonConverter[] converters)
        {
            return JsonConvert.DeserializeObject<T>(json, converters);
        }

        public static string SerializeObject(this object value)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects
            };

            return JsonConvert.SerializeObject(value, Formatting.Indented, settings);
        }

        public static string SerializeObject(this object value, params JsonConverter[] converters)
        {
            return JsonConvert.SerializeObject(value, Formatting.Indented, converters);
        }

        public static ListViewItem ToListViewItem<T>(this T value)
        {
            if (value is Operation) {
                var operation = value as Operation;

                var item = new ListViewItem(new string[] {
                    operation.Index.ToString(),
                    operation.OperationType.ToString(),
                    operation.Solution != null ? operation.Solution.DisplayName : "-",
                    operation.Solution != null && operation.Solution.Publisher != null ? operation.Solution.Publisher.DisplayName : "-",
                    operation.Description
                });

                item.Tag = operation;
                return item;
            }
            if (value is Solution)
            {
                var solution = value as Solution;

                var item = new ListViewItem(new string[] {
                    solution.DisplayName,
                    solution.Version,
                    solution.IsManaged ? "Yes" : "No",
                    solution.Publisher.DisplayName
                });

                item.Tag = solution;
                return item;
            }

            return null;
        }

        public static object ToObject<T>(this ListViewItem lvItem, T output)
        {
            if (output is Operation)
            {
                var operation = lvItem.Tag as Operation;
                return operation;
            }
            if (output is Solution)
            {
                var solution = lvItem.Tag as Solution;
                return solution;
            }
            if (output is SolutionHistory)
            {
                var history = lvItem.Tag as SolutionHistory;
                return history;
            }

            return null;
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

        public static bool MatchFilter(this Solution solution, string filter)
        {
            if (string.IsNullOrWhiteSpace(filter)) { return true; }

            filter = filter.ToLower();

            if (solution.DisplayName.ToLower().Contains(filter) || solution.LogicalName.ToLower().Contains(filter)) { return true; }
            return false;
        }

        public static string SelectDirectory(this IntPtr owner, string initialDir)
        {
            var dialog = new FolderSelectDialog
            {
                InitialDirectory = !string.IsNullOrEmpty(initialDir) ? initialDir : "C:\\",
                Title = "Select directory..."
            };

            var dirPath = string.Empty;
            if (dialog.Show(owner)) { dirPath = dialog.FileName; }
            return dirPath;
        }

        public static string SelectFile(this IWin32Window owner, string filter)
        {
            var filePath = string.Empty;
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Select file...";
                dialog.Filter = filter;
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog(owner).Equals(DialogResult.OK)) { filePath = dialog.FileName; }
            }

            return filePath;
        }

        public static string SaveFile(this IWin32Window owner, string filter, string filename = null)
        {
            var filePath = string.Empty;
            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "Save file...";
                dialog.Filter = filter;
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;
                if (!string.IsNullOrEmpty(filename)) { dialog.FileName = filename; }

                if (dialog.ShowDialog(owner).Equals(DialogResult.OK)) { filePath = dialog.FileName; }
            }

            return filePath;
        }

        public static string RemoveSpecialCharacters(this string str)
        {
            var trimmed = str.Trim();
            return Regex.Replace(trimmed, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }
    }
}
