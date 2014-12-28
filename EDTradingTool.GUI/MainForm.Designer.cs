namespace EDTradingTool.GUI
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.SolarSystemPage = new System.Windows.Forms.TabPage();
            this.SolarSystemLayout = new System.Windows.Forms.TableLayoutPanel();
            this.AddSolarSystemMask = new EDTradingTool.GUI.InputMask.AddSolarSystemMask();
            this.FederationPage = new System.Windows.Forms.TabPage();
            this.SpaceStationPage = new System.Windows.Forms.TabPage();
            this.CommodityGroupPage = new System.Windows.Forms.TabPage();
            this.CommodityTypePage = new System.Windows.Forms.TabPage();
            this.MarketEntryPage = new System.Windows.Forms.TabPage();
            this.EntityTreeView = new EDTradingTool.GUI.EntityTreeView();
            this.TreeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl.SuspendLayout();
            this.SolarSystemPage.SuspendLayout();
            this.SolarSystemLayout.SuspendLayout();
            this.TreeContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.SolarSystemPage);
            this.TabControl.Controls.Add(this.FederationPage);
            this.TabControl.Controls.Add(this.SpaceStationPage);
            this.TabControl.Controls.Add(this.CommodityGroupPage);
            this.TabControl.Controls.Add(this.CommodityTypePage);
            this.TabControl.Controls.Add(this.MarketEntryPage);
            this.TabControl.Location = new System.Drawing.Point(218, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(554, 378);
            this.TabControl.TabIndex = 4;
            // 
            // SolarSystemPage
            // 
            this.SolarSystemPage.Controls.Add(this.SolarSystemLayout);
            this.SolarSystemPage.Location = new System.Drawing.Point(4, 22);
            this.SolarSystemPage.Name = "SolarSystemPage";
            this.SolarSystemPage.Padding = new System.Windows.Forms.Padding(3);
            this.SolarSystemPage.Size = new System.Drawing.Size(546, 352);
            this.SolarSystemPage.TabIndex = 0;
            this.SolarSystemPage.Text = "Solar Systems";
            this.SolarSystemPage.UseVisualStyleBackColor = true;
            // 
            // SolarSystemLayout
            // 
            this.SolarSystemLayout.ColumnCount = 1;
            this.SolarSystemLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SolarSystemLayout.Controls.Add(this.AddSolarSystemMask, 0, 0);
            this.SolarSystemLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SolarSystemLayout.Location = new System.Drawing.Point(3, 3);
            this.SolarSystemLayout.Name = "SolarSystemLayout";
            this.SolarSystemLayout.RowCount = 2;
            this.SolarSystemLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.SolarSystemLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SolarSystemLayout.Size = new System.Drawing.Size(540, 346);
            this.SolarSystemLayout.TabIndex = 0;
            // 
            // AddSolarSystemMask
            // 
            this.AddSolarSystemMask.AutoSize = true;
            this.AddSolarSystemMask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddSolarSystemMask.Location = new System.Drawing.Point(3, 3);
            this.AddSolarSystemMask.MinimumSize = new System.Drawing.Size(200, 52);
            this.AddSolarSystemMask.Name = "AddSolarSystemMask";
            this.AddSolarSystemMask.Size = new System.Drawing.Size(534, 52);
            this.AddSolarSystemMask.TabIndex = 0;
            // 
            // FederationPage
            // 
            this.FederationPage.Location = new System.Drawing.Point(4, 22);
            this.FederationPage.Name = "FederationPage";
            this.FederationPage.Padding = new System.Windows.Forms.Padding(3);
            this.FederationPage.Size = new System.Drawing.Size(546, 352);
            this.FederationPage.TabIndex = 1;
            this.FederationPage.Text = "Federations";
            this.FederationPage.UseVisualStyleBackColor = true;
            // 
            // SpaceStationPage
            // 
            this.SpaceStationPage.Location = new System.Drawing.Point(4, 22);
            this.SpaceStationPage.Name = "SpaceStationPage";
            this.SpaceStationPage.Padding = new System.Windows.Forms.Padding(3);
            this.SpaceStationPage.Size = new System.Drawing.Size(546, 352);
            this.SpaceStationPage.TabIndex = 3;
            this.SpaceStationPage.Text = "Space Stations";
            this.SpaceStationPage.UseVisualStyleBackColor = true;
            // 
            // CommodityGroupPage
            // 
            this.CommodityGroupPage.Location = new System.Drawing.Point(4, 22);
            this.CommodityGroupPage.Name = "CommodityGroupPage";
            this.CommodityGroupPage.Padding = new System.Windows.Forms.Padding(3);
            this.CommodityGroupPage.Size = new System.Drawing.Size(546, 352);
            this.CommodityGroupPage.TabIndex = 2;
            this.CommodityGroupPage.Text = "Commodity Groups";
            this.CommodityGroupPage.UseVisualStyleBackColor = true;
            // 
            // CommodityTypePage
            // 
            this.CommodityTypePage.Location = new System.Drawing.Point(4, 22);
            this.CommodityTypePage.Name = "CommodityTypePage";
            this.CommodityTypePage.Padding = new System.Windows.Forms.Padding(3);
            this.CommodityTypePage.Size = new System.Drawing.Size(546, 352);
            this.CommodityTypePage.TabIndex = 4;
            this.CommodityTypePage.Text = "Commodity Types";
            this.CommodityTypePage.UseVisualStyleBackColor = true;
            // 
            // MarketEntryPage
            // 
            this.MarketEntryPage.Location = new System.Drawing.Point(4, 22);
            this.MarketEntryPage.Name = "MarketEntryPage";
            this.MarketEntryPage.Padding = new System.Windows.Forms.Padding(3);
            this.MarketEntryPage.Size = new System.Drawing.Size(546, 352);
            this.MarketEntryPage.TabIndex = 5;
            this.MarketEntryPage.Text = "Market Entries";
            this.MarketEntryPage.UseVisualStyleBackColor = true;
            // 
            // EntityTreeView
            // 
            this.EntityTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.EntityTreeView.ContextMenuStrip = this.TreeContextMenu;
            this.EntityTreeView.Location = new System.Drawing.Point(12, 12);
            this.EntityTreeView.MinimumSize = new System.Drawing.Size(200, 0);
            this.EntityTreeView.Name = "EntityTreeView";
            this.EntityTreeView.Size = new System.Drawing.Size(200, 378);
            this.EntityTreeView.TabIndex = 0;
            // 
            // TreeContextMenu
            // 
            this.TreeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripMenuItem,
            this.DeleteToolStripMenuItem});
            this.TreeContextMenu.Name = "TreeContextMenu";
            this.TreeContextMenu.Size = new System.Drawing.Size(153, 70);
            this.TreeContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.TreeContextMenu_Opening);
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.Enabled = false;
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AddToolStripMenuItem.Text = "Add";
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DeleteToolStripMenuItem.Text = "Delete";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 402);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.EntityTreeView);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.TabControl.ResumeLayout(false);
            this.SolarSystemPage.ResumeLayout(false);
            this.SolarSystemLayout.ResumeLayout(false);
            this.SolarSystemLayout.PerformLayout();
            this.TreeContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public EntityTreeView EntityTreeView;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage SolarSystemPage;
        private System.Windows.Forms.TabPage FederationPage;
        private System.Windows.Forms.TabPage SpaceStationPage;
        private System.Windows.Forms.TabPage CommodityGroupPage;
        private System.Windows.Forms.TabPage CommodityTypePage;
        private System.Windows.Forms.TabPage MarketEntryPage;
        private System.Windows.Forms.TableLayoutPanel SolarSystemLayout;
        private InputMask.AddSolarSystemMask AddSolarSystemMask;
        private System.Windows.Forms.ContextMenuStrip TreeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;

    }
}