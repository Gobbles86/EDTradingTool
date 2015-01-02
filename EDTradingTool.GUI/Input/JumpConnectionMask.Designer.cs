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
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.SpaceStationName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.JumpRangeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // SpaceStationComboBoxPanel
            // 
            this.SpaceStationComboBoxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpaceStationComboBoxPanel.Location = new System.Drawing.Point(3, 3);
            this.SpaceStationComboBoxPanel.MinimumSize = new System.Drawing.Size(500, 25);
            this.SpaceStationComboBoxPanel.Name = "SpaceStationComboBoxPanel";
            this.SpaceStationComboBoxPanel.Size = new System.Drawing.Size(643, 25);
            this.SpaceStationComboBoxPanel.TabIndex = 0;
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.SpaceStationName);
            this.objectListView1.AllColumns.Add(this.JumpRangeColumn);
            this.objectListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SpaceStationName,
            this.JumpRangeColumn});
            this.objectListView1.Location = new System.Drawing.Point(3, 34);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(643, 308);
            this.objectListView1.TabIndex = 1;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveButton.Location = new System.Drawing.Point(571, 348);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 2;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(490, 348);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
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
            // JumpConnectionMask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.SpaceStationComboBoxPanel);
            this.Name = "JumpConnectionMask";
            this.Size = new System.Drawing.Size(649, 374);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SpaceStationComboBoxPanel;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private BrightIdeasSoftware.OLVColumn SpaceStationName;
        private BrightIdeasSoftware.OLVColumn JumpRangeColumn;
    }
}
