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
                    operation.OperationType.ToString(),
                    operation.Solution.DisplayName,
                    operation.Solution.Version,
                    operation.Solution.IsManaged ? "Yes" : "No",
                    operation.Solution.Publisher.DisplayName
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

        public static string GetProgressMessage(this string baseMessage, string replace, double progress)
        {
            return baseMessage.Replace(replace, progress.ToString());
        }
    }
}
