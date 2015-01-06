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
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addQuestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TradeRouteView = new BrightIdeasSoftware.ObjectListView();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TradeRouteView)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(793, 24);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEntryToolStripMenuItem,
            this.addQuestToolStripMenuItem,
            this.deleteEntryToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.addToolStripMenuItem.Text = "Route";
            // 
            // addEntryToolStripMenuItem
            // 
            this.addEntryToolStripMenuItem.Name = "addEntryToolStripMenuItem";
            this.addEntryToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.addEntryToolStripMenuItem.Text = "Add Entry";
            // 
            // addQuestToolStripMenuItem
            // 
            this.addQuestToolStripMenuItem.Name = "addQuestToolStripMenuItem";
            this.addQuestToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.addQuestToolStripMenuItem.Text = "Add Quest";
            // 
            // deleteEntryToolStripMenuItem
            // 
            this.deleteEntryToolStripMenuItem.Name = "deleteEntryToolStripMenuItem";
            this.deleteEntryToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.deleteEntryToolStripMenuItem.Text = "Delete Entry";
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
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addQuestToolStripMenuItem;
        private BrightIdeasSoftware.ObjectListView TradeRouteView;
    }
}