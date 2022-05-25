// System
using System.Linq;
using System.Windows.Forms;

// Deployer
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.AppSettings;

namespace Dataverse.XrmTools.Deployer.Helpers
{
    public static class Utils
    {
        public static ListViewItem ToListViewItem<T>(this T value)
        {
            if (value is Operation) {
                var operation = value as Operation;

                var item = new ListViewItem(new string[] {
                    operation.Type.ToString(),
                    operation.Solution.DisplayName,
                    operation.Solution.Version,
                    operation.Solution.IsManaged ? "Yes" : "No",
                    operation.Solution.Publisher.DisplayName,
                    operation.Solution.Publisher.LogicalName

                });

                item.Tag = operation.Solution.LogicalName;
                return item;
            }

            return null;
        }

        public static object ToObject<T>(this ListViewItem lvItem, T output)
        {
            if (output is Operation)
            {
                return new Operation
                {
                    Type = Enums.OperationType.IMPORT,
                    Solution = new Solution
                    {
                        LogicalName = (string)lvItem.Tag,
                        DisplayName = lvItem.SubItems[0].Text,
                        Version = lvItem.SubItems[1].Text,
                        IsManaged = lvItem.SubItems[2].Text.Equals("Yes") ? true : false,
                        Publisher = new Publisher { DisplayName = lvItem.SubItems[3].Text, LogicalName = lvItem.SubItems[4].Text }
                    }
                };
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
    }
}
