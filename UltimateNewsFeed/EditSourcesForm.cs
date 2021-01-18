using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INewsSourceLibrary;

namespace UltimateNewsFeed
{
    public partial class EditSourcesForm : Form
    {
        private readonly INewsSource _thisNewsSource;
        
        public EditSourcesForm(INewsSource thisNewsSource)
        {
            _thisNewsSource = thisNewsSource;
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            bool correct = true;
            if (text_SourceName.Text == "")
            {
                // TODO: Add red borders in case of empty or invalid text entered
                correct = false;
                MessageBox.Show(@"All fields are required.", @"Error");
            }

            if (text_SourceLink.Text == "")
            {
                if (correct)
                    MessageBox.Show(@"All fields are required.", @"Error");
                correct = false;
            }
            
            if (!correct) return; // If a textbox is incomplete

            try
            {
                _thisNewsSource.AddSource(text_SourceName.Text.ToString(), text_SourceLink.Text.ToString());
                EditSourcesForm_Load(sender, e);
                btn_Clear_Click(sender, e);
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

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            text_SourceName.Text = "";
            text_SourceName.BorderStyle = BorderStyle.Fixed3D;
            text_SourceLink.Text = "";
            text_SourceLink.BorderStyle = BorderStyle.Fixed3D;
        }

        private void EditSourcesForm_Load(object sender, EventArgs e)
        {
            try
            {
                var sourcesList = _thisNewsSource.GetSources();
                dataGridView1.DataSource = sourcesList.ToList();
                dataGridView1.Columns[0].HeaderText = @"Name";
                dataGridView1.Columns[1].HeaderText = @"Link or path";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"Error");
            }
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = _thisNewsSource.DeleteSource(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                if (result)
                {
                    MessageBox.Show(@"Successfully deleted source.", @"Success");
                }
                else
                {
                    MessageBox.Show(@"Could not delete entry.", @"Notice");
                }
                EditSourcesForm_Load(sender, e);
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

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}
