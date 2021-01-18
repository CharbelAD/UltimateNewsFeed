namespace UltimateNewsFeed
{
    partial class MainControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Filter = new System.Windows.Forms.Button();
            this.btn_AddEntry = new System.Windows.Forms.Button();
            this.btn_EditSources = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_About = new System.Windows.Forms.Button();
            this.btn_AddSource = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.dGV = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unlockRowForEditingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Filter);
            this.groupBox1.Controls.Add(this.btn_AddEntry);
            this.groupBox1.Controls.Add(this.btn_EditSources);
            this.groupBox1.Controls.Add(this.btn_Reset);
            this.groupBox1.Controls.Add(this.btn_Delete);
            this.groupBox1.Controls.Add(this.btn_About);
            this.groupBox1.Controls.Add(this.btn_AddSource);
            this.groupBox1.Controls.Add(this.btn_Refresh);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btn_Filter
            // 
            this.btn_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_Filter.Location = new System.Drawing.Point(15, 83);
            this.btn_Filter.Name = "btn_Filter";
            this.btn_Filter.Size = new System.Drawing.Size(100, 23);
            this.btn_Filter.TabIndex = 7;
            this.btn_Filter.Text = "Refine results";
            this.btn_Filter.UseVisualStyleBackColor = true;
            this.btn_Filter.Click += new System.EventHandler(this.btn_Filter_Click);
            // 
            // btn_AddEntry
            // 
            this.btn_AddEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_AddEntry.Location = new System.Drawing.Point(163, 30);
            this.btn_AddEntry.Name = "btn_AddEntry";
            this.btn_AddEntry.Size = new System.Drawing.Size(100, 23);
            this.btn_AddEntry.TabIndex = 6;
            this.btn_AddEntry.Text = "Add entry";
            this.btn_AddEntry.UseVisualStyleBackColor = true;
            this.btn_AddEntry.Click += new System.EventHandler(this.btn_AddEntry_Click);
            // 
            // btn_EditSources
            // 
            this.btn_EditSources.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_EditSources.Location = new System.Drawing.Point(311, 83);
            this.btn_EditSources.Name = "btn_EditSources";
            this.btn_EditSources.Size = new System.Drawing.Size(100, 23);
            this.btn_EditSources.TabIndex = 5;
            this.btn_EditSources.Text = "Edit sources";
            this.btn_EditSources.UseVisualStyleBackColor = true;
            this.btn_EditSources.Click += new System.EventHandler(this.btn_EditSources_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_Reset.Location = new System.Drawing.Point(459, 83);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(100, 23);
            this.btn_Reset.TabIndex = 4;
            this.btn_Reset.Text = "Reset to defaults";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_Delete.Location = new System.Drawing.Point(163, 83);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(100, 23);
            this.btn_Delete.TabIndex = 3;
            this.btn_Delete.Text = "Delete selected";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_About
            // 
            this.btn_About.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_About.Location = new System.Drawing.Point(459, 30);
            this.btn_About.Name = "btn_About";
            this.btn_About.Size = new System.Drawing.Size(100, 23);
            this.btn_About.TabIndex = 2;
            this.btn_About.Text = "About";
            this.btn_About.UseVisualStyleBackColor = true;
            this.btn_About.Click += new System.EventHandler(this.btn_About_Click);
            // 
            // btn_AddSource
            // 
            this.btn_AddSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_AddSource.Location = new System.Drawing.Point(311, 30);
            this.btn_AddSource.Name = "btn_AddSource";
            this.btn_AddSource.Size = new System.Drawing.Size(100, 23);
            this.btn_AddSource.TabIndex = 1;
            this.btn_AddSource.Text = "Add Source";
            this.btn_AddSource.UseVisualStyleBackColor = true;
            this.btn_AddSource.Click += new System.EventHandler(this.btn_AddSource_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_Refresh.Location = new System.Drawing.Point(15, 30);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(100, 23);
            this.btn_Refresh.TabIndex = 0;
            this.btn_Refresh.Text = "Refresh Feed";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // dGV
            // 
            this.dGV.AllowUserToAddRows = false;
            this.dGV.AllowUserToDeleteRows = false;
            this.dGV.AllowUserToOrderColumns = true;
            this.dGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV.Location = new System.Drawing.Point(0, 137);
            this.dGV.Name = "dGV";
            this.dGV.ReadOnly = true;
            this.dGV.Size = new System.Drawing.Size(574, 365);
            this.dGV.TabIndex = 1;
            this.dGV.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dGV_CellMouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteRowToolStripMenuItem,
            this.unlockRowForEditingToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 48);
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.deleteRowToolStripMenuItem.Text = "Delete row";
            this.deleteRowToolStripMenuItem.Click += new System.EventHandler(this.deleteRowToolStripMenuItem_Click);
            // 
            // unlockRowForEditingToolStripMenuItem
            // 
            this.unlockRowForEditingToolStripMenuItem.Name = "unlockRowForEditingToolStripMenuItem";
            this.unlockRowForEditingToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.unlockRowForEditingToolStripMenuItem.Text = "Edit row";
            this.unlockRowForEditingToolStripMenuItem.Click += new System.EventHandler(this.editRowToolStripMenuItem_Click);
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dGV);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(574, 502);
            this.Load += new System.EventHandler(this.MainControl_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_AddSource;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.DataGridView dGV;
        private System.Windows.Forms.Button btn_About;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteRowToolStripMenuItem;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_EditSources;
        private System.Windows.Forms.Button btn_AddEntry;
        private System.Windows.Forms.ToolStripMenuItem unlockRowForEditingToolStripMenuItem;
        private System.Windows.Forms.Button btn_Filter;
    }
}
