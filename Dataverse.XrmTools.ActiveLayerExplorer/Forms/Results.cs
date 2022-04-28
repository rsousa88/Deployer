using System;
using System.Text;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using static System.Windows.Forms.ListViewItem;
using Dataverse.XrmTools.ActiveLayerExplorer.Helpers;
using Dataverse.XrmTools.ActiveLayerExplorer.AppSettings;

namespace Dataverse.XrmTools.ActiveLayerExplorer.Forms
{
    public partial class Results : Form
    {
        private Settings _settings;
        private IEnumerable<ListViewItem> _recordItems;

        public Results(IEnumerable<ListViewItem> recordItems, Settings settings)
        {
            _settings = settings;
            _recordItems = recordItems;
            InitializeComponent();
        }

        private void LoadRecords(object sender, EventArgs e)
        {
            lvItems.Items.Clear();
            lvItems.Items.AddRange(_recordItems.ToArray());

            // Set summary
            SetSummary();
        }

        private void SetSummary()
        {
            var successCount = _recordItems.Where(prv => prv.SubItems[1].Equals("Ok")).Count();
            var errorCount = _recordItems.Where(prv => !prv.SubItems[1].Equals("Ok")).Count();

            lblSumSuccessValue.Text = successCount.ToString();
            lblSumErrorValue.Text = errorCount.ToString();
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            (sender as ListView).Sort(_settings, e.Column);
        }

        private void lvItems_KeyUp(object sender, KeyEventArgs e)
        {
            if (sender != lvItems) return;

            if (e.Control && e.KeyCode == Keys.C)
            {
                CopySelectedValuesToClipboard();
            }
        }

        private void Results_Resize(object sender, EventArgs e)
        {
            // re-render list view columns
            var maxWidth = lvItems.Width >= 1000 ? lvItems.Width : 1000;
            chResComponentName.Width = (int)Math.Floor(maxWidth * 0.29);
            chResDescription.Width = (int)Math.Floor(maxWidth * 0.7);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CopySelectedValuesToClipboard()
        {
            var builder = new StringBuilder();

            // add columns
            foreach (ColumnHeader column in lvItems.Columns)
            {
                builder.Append($"{column.Text};");
            }

            builder.AppendLine();

            // add rows
            foreach (ListViewItem item in lvItems.SelectedItems)
            {
                foreach (ListViewSubItem sub in item.SubItems)
                {
                    builder.Append($"{sub.Text};");
                }

                builder.AppendLine();
            }

            // set clipboard
            Clipboard.SetText(builder.ToString());
        }
    }
}
