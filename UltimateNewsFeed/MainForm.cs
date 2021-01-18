using System;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadPlugin(string pathname)
        {
            try
            {
                // Loading the dll
                var DLL = Assembly.LoadFile(pathname);
                dynamic newsSourceInstance = null;
                // Checking the types in the dll
                foreach (var type in DLL.GetExportedTypes())
                {
                    // Plugins must adhere to the naming convention to be recognized
                    // Here, type.FullName might be something like RSSNewsSource.RssNewsSource
                    //   so we need to check the part after the dot
                    if (type.FullName != null && type.FullName.Split('.')[1].Contains("NewsSource"))
                    {
                        //dynamic newsSourceInstance = Activator.CreateInstance(type);
                        newsSourceInstance = Activator.CreateInstance(type);
                        //var newsSource = newsSourceInstance as INewsSource;
                    }

                }
                if (newsSourceInstance != null)
                {
                    var newsSource = newsSourceInstance as INewsSource;
                    // Creating a new control to add to the new tab
                    MainControl mnControl = new MainControl(newsSource)
                        { AutoSize = true, Dock = DockStyle.Fill };

                    // Creating the new tab
                    TabPage page = new TabPage(newsSource.GetShortDisplayName());
                    page.Controls.Add(mnControl);
                    tabControl1.TabPages.Add(page);
                    tabControl1.SelectedTab = TabPage.GetTabPageOfComponent(page);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"There was an error loading this plugin." + Environment.NewLine + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void addNewPluginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var loadLibraryDialog = new OpenFileDialog())
            {
                loadLibraryDialog.Title = @"Select a library to add";
                loadLibraryDialog.Filter = @"C# Libraries|*.dll";
                if (loadLibraryDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadPlugin(loadLibraryDialog.FileName);
                }
            }
        }

        private void btn_AddPlugin_Click(object sender, EventArgs e)
        {
            addNewPluginToolStripMenuItem_Click(sender, e);
        }

        private void removeCurrentPluginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: persistence of tabs, save in a file
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }
    }
}
