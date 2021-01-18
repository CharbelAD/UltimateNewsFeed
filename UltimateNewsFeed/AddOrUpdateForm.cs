using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using INewsSourceLibrary;

namespace UltimateNewsFeed
{
    public partial class AddOrUpdateForm : Form
    {
        private readonly INewsSource _thisNewsSourceLibrary;
        private Entry oldEntry;
        private bool isUpdate;

        public AddOrUpdateForm(INewsSource thisNewsSourceLibrary, bool isUpdate, IEnumerable entrySingleton)
        {
            // The choice of IEnumerable was to preserve types and prevent casting
            _thisNewsSourceLibrary = thisNewsSourceLibrary;
            this.isUpdate = isUpdate;
            InitializeComponent();
            this.Text = isUpdate ? @"Update entry" : @"Add new entry";
            dataGridView1.DataSource = entrySingleton;
            if (isUpdate) // If we are updating an entry, we need to save the old one
            { // I need to clone the object otherwise it will be taken as a reference and not update correctly
                // Here, I am cloning using reflection, this has performance drawbacks but I'm assuming
                // it will not be used frequently throughout the lifetime of the app

                // TODO: Find a more efficient way to clone

                var initial = dataGridView1.Rows[0].DataBoundItem;
                Type type = dataGridView1.Rows[0].DataBoundItem.GetType();
                var result = Activator.CreateInstance(type) as Entry;

                var properties = type.GetProperties(
                    BindingFlags.Instance | BindingFlags.Public);

                foreach (var property in properties)
                {
                    var val = property.GetValue(initial, null);
                    property.SetValue(result, val, null);
                }
                oldEntry = result;
            }

        }

        private void btn_Okay_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows[0].Cells.Count; ++i)
                {
                    if (dataGridView1.Rows[0].Cells[i].Value == null || dataGridView1.Rows[0].Cells[i].Value.ToString() == "")
                    {
                        MessageBox.Show(@"Fields cannot be empty", @"Error");
                        return;
                    }
                }

                if (isUpdate)
                {
                    _thisNewsSourceLibrary.UpdateEntry(oldEntry, (Entry) dataGridView1.Rows[0].DataBoundItem);
                }
                else
                {
                    _thisNewsSourceLibrary.AddEntry((Entry) dataGridView1.Rows[0].DataBoundItem);
                }
                this.Close();
            }
            catch (NotSupportedException)
            {
                MessageBox.Show(@"This operation is not supported for this plugin or source.", @"Notice");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddOrUpdateForm_Load(object sender, EventArgs e)
        {

        }
    }
}
