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
            this.TreeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CommodityGroupPage = new System.Windows.Forms.TabPage();
            this.CommodityTypePage = new System.Windows.Forms.TabPage();
            this.SolarSystemPage = new System.Windows.Forms.TabPage();
            this.SpaceStationPage = new System.Windows.Forms.TabPage();
            this.MarketEntryPage = new System.Windows.Forms.TabPage();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlanNewTradeRouteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EntityTreeView = new EDTradingTool.GUI.EntityTreeView();
            this.TreeContextMenu.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeContextMenu
            // 
            this.TreeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripMenuItem,
            this.DeleteToolStripMenuItem});
            this.TreeContextMenu.Name = "TreeContextMenu";
            this.TreeContextMenu.Size = new System.Drawing.Size(108, 48);
            this.TreeContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.TreeContextMenu_Opening);
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.Enabled = false;
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.AddToolStripMenuItem.Text = "Add";
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.DeleteToolStripMenuItem.Text = "Delete";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // CommodityGroupPage
            // 
            this.CommodityGroupPage.Location = new System.Drawing.Point(4, 22);
            this.CommodityGroupPage.Name = "CommodityGroupPage";
            this.CommodityGroupPage.Padding = new System.Windows.Forms.Padding(3);
            this.CommodityGroupPage.Size = new System.Drawing.Size(546, 330);
            this.CommodityGroupPage.TabIndex = 2;
            this.CommodityGroupPage.Text = "Commodity Groups";
            this.CommodityGroupPage.UseVisualStyleBackColor = true;
            // 
            // CommodityTypePage
            // 
            this.CommodityTypePage.Location = new System.Drawing.Point(4, 22);
            this.CommodityTypePage.Name = "CommodityTypePage";
            this.CommodityTypePage.Padding = new System.Windows.Forms.Padding(3);
            this.CommodityTypePage.Size = new System.Drawing.Size(546, 330);
            this.CommodityTypePage.TabIndex = 4;
            this.CommodityTypePage.Text = "Commodity Types";
            this.CommodityTypePage.UseVisualStyleBackColor = true;
            // 
            // SolarSystemPage
            // 
            this.SolarSystemPage.Location = new System.Drawing.Point(4, 22);
            this.SolarSystemPage.Name = "SolarSystemPage";
            this.SolarSystemPage.Padding = new System.Windows.Forms.Padding(3);
            this.SolarSystemPage.Size = new System.Drawing.Size(546, 330);
            this.SolarSystemPage.TabIndex = 0;
            this.SolarSystemPage.Text = "Solar Systems";
            this.SolarSystemPage.UseVisualStyleBackColor = true;
            // 
            // SpaceStationPage
            // 
            this.SpaceStationPage.Location = new System.Drawing.Point(4, 22);
            this.SpaceStationPage.Name = "SpaceStationPage";
            this.SpaceStationPage.Padding = new System.Windows.Forms.Padding(3);
            this.SpaceStationPage.Size = new System.Drawing.Size(546, 330);
            this.SpaceStationPage.TabIndex = 3;
            this.SpaceStationPage.Text = "Space Stations";
            this.SpaceStationPage.UseVisualStyleBackColor = true;
            // 
            // MarketEntryPage
            // 
            this.MarketEntryPage.Location = new System.Drawing.Point(4, 22);
            this.MarketEntryPage.Name = "MarketEntryPage";
            this.MarketEntryPage.Padding = new System.Windows.Forms.Padding(3);
            this.MarketEntryPage.Size = new System.Drawing.Size(546, 337);
            this.MarketEntryPage.TabIndex = 5;
            this.MarketEntryPage.Text = "Market Entries";
            this.MarketEntryPage.UseVisualStyleBackColor = true;
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.MarketEntryPage);
            this.TabControl.Controls.Add(this.SpaceStationPage);
            this.TabControl.Controls.Add(this.SolarSystemPage);
            this.TabControl.Controls.Add(this.CommodityTypePage);
            this.TabControl.Controls.Add(this.CommodityGroupPage);
            this.TabControl.Location = new System.Drawing.Point(218, 27);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(554, 363);
            this.TabControl.TabIndex = 4;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(784, 24);
            this.MenuStrip.TabIndex = 5;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlanNewTradeRouteItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // PlanNewTradeRouteItem
            // 
            this.PlanNewTradeRouteItem.Name = "PlanNewTradeRouteItem";
            this.PlanNewTradeRouteItem.Size = new System.Drawing.Size(191, 22);
            this.PlanNewTradeRouteItem.Text = "Plan New Trade Route";
            this.PlanNewTradeRouteItem.Click += new System.EventHandler(this.PlanNewTradeRouteItem_Click);
            // 
            // EntityTreeView
            // 
            this.EntityTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.EntityTreeView.ContextMenuStrip = this.TreeContextMenu;
            this.EntityTreeView.Location = new System.Drawing.Point(12, 27);
            this.EntityTreeView.MinimumSize = new System.Drawing.Size(200, 0);
            this.EntityTreeView.Name = "EntityTreeView";
            this.EntityTreeView.Size = new System.Drawing.Size(200, 363);
            this.EntityTreeView.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 402);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.EntityTreeView);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.TreeContextMenu.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public EntityTreeView EntityTreeView;
        private System.Windows.Forms.ContextMenuStrip TreeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.TabPage CommodityGroupPage;
        private System.Windows.Forms.TabPage CommodityTypePage;
        private System.Windows.Forms.TabPage SolarSystemPage;
        private System.Windows.Forms.TabPage SpaceStationPage;
        private System.Windows.Forms.TabPage MarketEntryPage;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PlanNewTradeRouteItem;

    }
}