namespace EDTradingTool.GUI.Input
{
    partial class JumpConnectionMask
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.SpaceStationComboBoxPanel = new System.Windows.Forms.Panel();
            this.ListView = new BrightIdeasSoftware.ObjectListView();
            this.SpaceStationName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.JumpRangeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ListView)).BeginInit();
            this.SuspendLayout();
            // 
            // SpaceStationComboBoxPanel
            // 
            this.SpaceStationComboBoxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpaceStationComboBoxPanel.Location = new System.Drawing.Point(3, 3);
            this.SpaceStationComboBoxPanel.MinimumSize = new System.Drawing.Size(100, 25);
            this.SpaceStationComboBoxPanel.Name = "SpaceStationComboBoxPanel";
            this.SpaceStationComboBoxPanel.Size = new System.Drawing.Size(100, 25);
            this.SpaceStationComboBoxPanel.TabIndex = 0;
            // 
            // ListView
            // 
            this.ListView.AllColumns.Add(this.SpaceStationName);
            this.ListView.AllColumns.Add(this.JumpRangeColumn);
            this.ListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SpaceStationName,
            this.JumpRangeColumn});
            this.ListView.Location = new System.Drawing.Point(3, 34);
            this.ListView.MinimumSize = new System.Drawing.Size(350, 250);
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(453, 259);
            this.ListView.TabIndex = 1;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.Details;
            // 
            // SpaceStationName
            // 
            this.SpaceStationName.AspectName = "SpaceStationName";
            this.SpaceStationName.Text = "Space Station";
            this.SpaceStationName.Width = 200;
            // 
            // JumpRangeColumn
            // 
            this.JumpRangeColumn.AspectName = "JumpRange";
            this.JumpRangeColumn.Text = "Jump Range";
            this.JumpRangeColumn.Width = 100;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveButton.Location = new System.Drawing.Point(381, 299);
            this.RemoveButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 2;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(300, 299);
            this.AddButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // JumpConnectionMask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.ListView);
            this.Controls.Add(this.SpaceStationComboBoxPanel);
            this.Name = "JumpConnectionMask";
            this.Size = new System.Drawing.Size(459, 325);
            ((System.ComponentModel.ISupportInitialize)(this.ListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SpaceStationComboBoxPanel;
        private BrightIdeasSoftware.ObjectListView ListView;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private BrightIdeasSoftware.OLVColumn SpaceStationName;
        private BrightIdeasSoftware.OLVColumn JumpRangeColumn;
    }
}
