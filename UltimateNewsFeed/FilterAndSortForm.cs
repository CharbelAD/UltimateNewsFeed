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
using INewsSourceLibrary;

namespace UltimateNewsFeed
{
    public partial class FilterAndSortForm : Form
    {
        private IEnumerable<Entry> _entries;
        private FlowLayoutPanel _panel;
        public IEnumerable<Entry> EntryList
        {
            get => _entries;
            set => _entries = value;
        }

        public FilterAndSortForm(IEnumerable<Entry> entry)
        {
            _entries = entry;
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FilterAndSortForm_Load(object sender, EventArgs e)
        {
            // Not letting the user type in values for the comboboxes
            comboBoxCriteria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxChoice.DropDownStyle = ComboBoxStyle.DropDownList;

            _panel = new FlowLayoutPanel() {FlowDirection = FlowDirection.TopDown, Dock = DockStyle.Fill};
            groupBox1.Controls.Add(_panel);

            // Populating the combobox of criterias and the radio buttons
            Type type = _entries.FirstOrDefault()?.GetType();
            IList<string> choices = new List<string>();
            choices.Add("-- Select --");
            foreach (var propertyInfo in type.GetProperties())
            {
                choices.Add(propertyInfo.Name);
                _panel.Controls.Add(new RadioButton() { Text = propertyInfo.Name});
            }

            comboBoxCriteria.DataSource = choices;
        }

        private void comboBoxCriteria_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                // Getting the property to filter by
                Type type = _entries.FirstOrDefault()?.GetType();
                PropertyInfo p = type.GetProperty(comboBoxCriteria.SelectedValue.ToString());
                if (p != null)
                {
                    // Filtering by the selected property
                    var listOfDistinctValues = EntryList.Select(person => p.GetValue(person)).Distinct().ToList();
                    comboBoxChoice.DataSource = listOfDistinctValues;
                }
                else if (comboBoxCriteria.SelectedValue.ToString() == "-- Select --")
                {
                    // Do nothing: no filtering was needed
                }
                else
                {
                    // In case the passed property name was empty or wrong
                    MessageBox.Show(@"An error has occurred.", @"Error");
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btn_Okay_Click(object sender, EventArgs e)
        {
            // ----------------- Filtering
            if (comboBoxCriteria.SelectedValue.ToString() != "-- Select --")
            {// if filtering is needed, take the selected value from comboBoxChoice,
             // and only select the appropriate entries
                try
                {
                     Type type = _entries.FirstOrDefault()?.GetType();
                     PropertyInfo p = type.GetProperty(comboBoxCriteria.SelectedValue.ToString());

                     if (p != null)
                     {
                         var newList = (from row in _entries
                             where p.GetValue(row).ToString() == comboBoxChoice.SelectedValue.ToString()
                             select row);
                         _entries = newList;
                     }
                     else
                     {
                         MessageBox.Show(@"An error has occurred.", @"Error");
                     }
                }
                catch (Exception ex)
                {
                 MessageBox.Show("An error has occurred.\n" + ex.Message, @"Error");
                }
            }

            // ----------------- Sorting
            // Get which radiobutton was pressed
            RadioButton rbSelected = _panel.Controls
                .OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);
            
            if (rbSelected == null)
            {
                // None selected
                // return without changing the list
            }
            else
            {
                // Need to sort according to criteria selected and direction
                // As always, get the needed types and properties
                Type type = _entries.FirstOrDefault()?.GetType();
                PropertyInfo p = type.GetProperty(rbSelected.Text);
                /*_entries.Sort((x1, x2) =>
                {
                    if (p.GetValue(x1) > p.GetValue(x2))
                        return 1;
                    if (p.GetValue(x1) < p.GetValue(x2))
                        return -1;
                    return 0;
                });*/
                
                //Type listType = typeof(List<>).MakeGenericType(new[] { type });
                //IList newSource = (IList)Activator.CreateInstance(listType);
                if (p != null)
                {
                    var newSource = _entries.ToList();
                    newSource.Sort((x1, x2) => ((IComparable) p.GetValue(x1)).CompareTo(p.GetValue(x2)));
                    _entries = newSource;
                    if (radioButtonDescending.Checked)
                        _entries = _entries.Reverse();
                }
                else
                {
                    MessageBox.Show(@"An error occurred.", @"Error");
                }

            }
            // Need to return
            // The final list can then be accessed through the property Entry
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
