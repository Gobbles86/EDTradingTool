namespace EDTradingTool.GUI.RoutePlanner
{
    partial class TradeRouteDialog
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
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TradeRouteView = new BrightIdeasSoftware.ObjectListView();
            this.AddTradeEntryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddQuestEntryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveEntryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TradeRouteView)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(793, 24);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTradeEntryMenuItem,
            this.AddQuestEntryMenuItem,
            this.RemoveEntryMenuItem});
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.AddToolStripMenuItem.Text = "Route";
            // 
            // TradeRouteView
            // 
            this.TradeRouteView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TradeRouteView.Location = new System.Drawing.Point(12, 27);
            this.TradeRouteView.Name = "TradeRouteView";
            this.TradeRouteView.Size = new System.Drawing.Size(769, 377);
            this.TradeRouteView.TabIndex = 2;
            this.TradeRouteView.UseCompatibleStateImageBehavior = false;
            this.TradeRouteView.View = System.Windows.Forms.View.Details;
            // 
            // AddTradeEntryMenuItem
            // 
            this.AddTradeEntryMenuItem.Name = "AddTradeEntryMenuItem";
            this.AddTradeEntryMenuItem.Size = new System.Drawing.Size(160, 22);
            this.AddTradeEntryMenuItem.Text = "Add Trade Entry";
            this.AddTradeEntryMenuItem.Click += new System.EventHandler(this.AddTradeEntryMenuItem_Click);
            // 
            // AddQuestEntryMenuItem
            // 
            this.AddQuestEntryMenuItem.Name = "AddQuestEntryMenuItem";
            this.AddQuestEntryMenuItem.Size = new System.Drawing.Size(160, 22);
            this.AddQuestEntryMenuItem.Text = "Add Quest Entry";
            this.AddQuestEntryMenuItem.Click += new System.EventHandler(this.AddQuestEntryMenuItem_Click);
            // 
            // RemoveEntryMenuItem
            // 
            this.RemoveEntryMenuItem.Name = "RemoveEntryMenuItem";
            this.RemoveEntryMenuItem.Size = new System.Drawing.Size(160, 22);
            this.RemoveEntryMenuItem.Text = "Remove Entry";
            this.RemoveEntryMenuItem.Click += new System.EventHandler(this.RemoveEntryMenuItem_Click);
            // 
            // TradeRouteDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 416);
            this.Controls.Add(this.TradeRouteView);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "TradeRouteDialog";
            this.Text = "TradeRouteDialog";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TradeRouteView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private BrightIdeasSoftware.ObjectListView TradeRouteView;
        private System.Windows.Forms.ToolStripMenuItem AddTradeEntryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddQuestEntryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveEntryMenuItem;
    }
}