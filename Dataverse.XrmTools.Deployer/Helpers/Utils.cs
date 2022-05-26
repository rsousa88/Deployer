﻿// System
using System;
using System.Linq;
using System.Windows.Forms;

// Deployer
using Dataverse.XrmTools.Deployer.Enums;
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
                    operation.Solution.LogicalName,
                    operation.Solution.DisplayName,
                    operation.Solution.Version,
                    operation.Solution.IsManaged ? "Yes" : "No",
                    operation.Solution.Publisher.DisplayName,
                    operation.Solution.Publisher.LogicalName

                });

                item.Tag = operation.Solution.SolutionId;
                return item;
            }
            if (value is Solution)
            {
                var solution = value as Solution;

                var item = new ListViewItem(new string[] {
                    solution.LogicalName,
                    solution.DisplayName,
                    solution.Version,
                    solution.IsManaged ? "Yes" : "No",
                    solution.Publisher.DisplayName,
                    solution.Publisher.LogicalName
                });

                item.Tag = solution.SolutionId;
                return item;
            }

            return null;
        }

        public static object ToObject<T>(this ListViewItem lvItem, T output)
        {
            if (output is Operation)
            {
                Enum.TryParse(lvItem.SubItems[0].Text, out OperationType type);

                return new Operation
                {
                    Type = type,
                    Solution = new Solution
                    {
                        SolutionId = Guid.Parse(lvItem.Tag.ToString()),
                        LogicalName = lvItem.SubItems[1].Text,
                        DisplayName = lvItem.SubItems[2].Text,
                        Version = lvItem.SubItems[3].Text,
                        IsManaged = lvItem.SubItems[4].Text.Equals("Yes") ? true : false,
                        Publisher = new Publisher { DisplayName = lvItem.SubItems[5].Text, LogicalName = lvItem.SubItems[6].Text }
                    }
                };
            }
            if (output is Solution)
            {
                return new Solution
                {
                    SolutionId = Guid.Parse(lvItem.Tag.ToString()),
                    LogicalName = lvItem.SubItems[0].Text,
                    DisplayName = lvItem.SubItems[1].Text,
                    Version = lvItem.SubItems[2].Text,
                    IsManaged = lvItem.SubItems[3].Text.Equals("Yes") ? true : false,
                    Publisher = new Publisher { DisplayName = lvItem.SubItems[4].Text, LogicalName = lvItem.SubItems[5].Text }
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

        public static bool MatchFilter(this Solution solution, string filter)
        {
            if (string.IsNullOrWhiteSpace(filter)) { return true; }

            filter = filter.ToLower();

            if (solution.DisplayName.ToLower().Contains(filter) || solution.LogicalName.ToLower().Contains(filter)) { return true; }
            return false;
        }
    }
}
