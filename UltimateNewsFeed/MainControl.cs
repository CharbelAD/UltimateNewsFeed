using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using INewsSourceLibrary;

namespace UltimateNewsFeed
{
    public partial class MainControl : UserControl
    {
        private readonly INewsSource _thisNewsSource;

        public MainControl(INewsSource thisNewsSource)
        {
            this._thisNewsSource = thisNewsSource;
            InitializeComponent();
            _thisNewsSource.FeedChanged += NewsSourceFeedChanged;
        }

        private void NewsSourceFeedChanged(bool changed)
        {
            if (changed)
            {
                MessageBox.Show("Got FeedChanged event");
                _populateDGV();
            }
        }

        private void MainControl_Load(object sender, EventArgs e)
        {
            _populateDGV();
            groupBox1.Text = _thisNewsSource.GetDisplayName();
        }

        private void _populateDGV()
        {
            try
            {
                var feed = _thisNewsSource.GetFeed();
                dGV.DataSource = feed;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred\n" + ex.Message, "Error");
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            _populateDGV();
        }

        private void btn_About_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_thisNewsSource.GetDescription());
        }

        private void dGV_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dGV.Rows[e.RowIndex].Selected = true;
                this.dGV.CurrentCell = this.dGV.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dGV, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_Delete_Click(sender, e);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            List<Entry> toDeleteEntries = new List<Entry>();
            foreach (DataGridViewRow row in dGV.SelectedRows)
            {
                toDeleteEntries.Add((Entry)row.DataBoundItem);
            }

            if (toDeleteEntries.Count == 0)
            {
                MessageBox.Show(@"No rows selected.", @"Notice");
                return;
                
            }

            try
            {
                _thisNewsSource.DeleteEntries(toDeleteEntries);
                MessageBox.Show(@"Successfully deleted row(s).", @"Success");
               
            }
            catch (NotSupportedException)
            {
                MessageBox.Show(@"This operation is not supported for this plugin or source.", @"Notice");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error");
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            try
            {
                _thisNewsSource.ResetToDefault();
                MessageBox.Show(@"Successfully reset this plugin to the default.", @"Success");
                _populateDGV();
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(@"This operation is not supported for this plugin or source.", @"Notice");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error");
            }
        }

        private void btn_EditSources_Click(object sender, EventArgs e)
        {
            try
            {
                Form sourcesForm = new EditSourcesForm(_thisNewsSource);
                sourcesForm.ShowDialog();
                _populateDGV();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error");
            }
        }

        private void btn_AddEntry_Click(object sender, EventArgs e)
        {
            try
            {
                Type type = dGV.Rows[0].DataBoundItem.GetType();
                Type listType = typeof(List<>).MakeGenericType(new[] {type});
                IList list = (IList) Activator.CreateInstance(listType);
                var toAdd = Activator.CreateInstance(type);
                list.Add(toAdd);

                Form entryForm = new AddOrUpdateForm(_thisNewsSource, false, list);
                entryForm.Show();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void editRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Creating a generic list of the same type as the rows (a child of Entry)
                Type type = dGV.Rows[0].DataBoundItem.GetType();
                Type listType = typeof(List<>).MakeGenericType(new[] { type });
                IList list = (IList)Activator.CreateInstance(listType);
                var selected = dGV.SelectedRows[0].DataBoundItem;
                list.Add(selected);

                Form entryForm = new AddOrUpdateForm(_thisNewsSource, true, list);
                entryForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error");
            }
        }

        private void btn_Filter_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new FilterAndSortForm(_thisNewsSource.GetFeed());
                var result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Type type = dGV.Rows[0].DataBoundItem.GetType();
                    Type listType = typeof(List<>).MakeGenericType(new[] {type});
                    IList newSource = (IList) Activator.CreateInstance(listType);
                    foreach (var entry in frm.EntryList)
                    {
                        newSource.Add(entry);
                    }

                    dGV.DataSource = newSource;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error");
            }
        }

        private void btn_AddSource_Click(object sender, EventArgs e)
        {
            try
            {
                Form sourcesForm = new EditSourcesForm(_thisNewsSource);
                sourcesForm.ShowDialog();
                _populateDGV();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error");
            }
        }
    }
}
