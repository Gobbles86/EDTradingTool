namespace EDTradingTool.GUI
{
    partial class SpaceStationCommodityDialog
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
            this.ListViewCaption = new System.Windows.Forms.Label();
            this.ComboBoxCaption = new System.Windows.Forms.Label();
            this.ComboBoxPanel = new System.Windows.Forms.Panel();
            this.ProfitListView = new BrightIdeasSoftware.ObjectListView();
            this.CommodityGroupColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CommodityTypeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.BuyFromMarketPriceColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.SellToMarketPriceColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ProfitColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.LastBuyPriceUpdateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.LastSellPriceUpdateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.ProfitListView)).BeginInit();
            this.SuspendLayout();
            // 
            // ListViewCaption
            // 
            this.ListViewCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewCaption.Location = new System.Drawing.Point(12, 51);
            this.ListViewCaption.Name = "ListViewCaption";
            this.ListViewCaption.Size = new System.Drawing.Size(919, 13);
            this.ListViewCaption.TabIndex = 0;
            this.ListViewCaption.Text = "Label";
            // 
            // ComboBoxCaption
            // 
            this.ComboBoxCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxCaption.Location = new System.Drawing.Point(12, 9);
            this.ComboBoxCaption.Name = "ComboBoxCaption";
            this.ComboBoxCaption.Size = new System.Drawing.Size(919, 13);
            this.ComboBoxCaption.TabIndex = 0;
            this.ComboBoxCaption.Text = "Select a station to compare against";
            // 
            // ComboBoxPanel
            // 
            this.ComboBoxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxPanel.Location = new System.Drawing.Point(15, 26);
            this.ComboBoxPanel.Name = "ComboBoxPanel";
            this.ComboBoxPanel.Size = new System.Drawing.Size(916, 22);
            this.ComboBoxPanel.TabIndex = 2;
            // 
            // ProfitListView
            // 
            this.ProfitListView.AllColumns.Add(this.CommodityGroupColumn);
            this.ProfitListView.AllColumns.Add(this.CommodityTypeColumn);
            this.ProfitListView.AllColumns.Add(this.BuyFromMarketPriceColumn);
            this.ProfitListView.AllColumns.Add(this.LastBuyPriceUpdateColumn);
            this.ProfitListView.AllColumns.Add(this.SellToMarketPriceColumn);
            this.ProfitListView.AllColumns.Add(this.LastSellPriceUpdateColumn);
            this.ProfitListView.AllColumns.Add(this.ProfitColumn);
            this.ProfitListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProfitListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CommodityGroupColumn,
            this.CommodityTypeColumn,
            this.BuyFromMarketPriceColumn,
            this.LastBuyPriceUpdateColumn,
            this.SellToMarketPriceColumn,
            this.LastSellPriceUpdateColumn,
            this.ProfitColumn});
            this.ProfitListView.Location = new System.Drawing.Point(15, 68);
            this.ProfitListView.Name = "ProfitListView";
            this.ProfitListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.ProfitListView.ShowCommandMenuOnRightClick = true;
            this.ProfitListView.ShowGroups = false;
            this.ProfitListView.Size = new System.Drawing.Size(916, 462);
            this.ProfitListView.TabIndex = 3;
            this.ProfitListView.UseCompatibleStateImageBehavior = false;
            this.ProfitListView.View = System.Windows.Forms.View.Details;
            // 
            // CommodityGroupColumn
            // 
            this.CommodityGroupColumn.AspectName = "GroupName";
            this.CommodityGroupColumn.Text = "Commodity Group";
            this.CommodityGroupColumn.Width = 97;
            // 
            // CommodityTypeColumn
            // 
            this.CommodityTypeColumn.AspectName = "TypeName";
            this.CommodityTypeColumn.Text = "Commodity Type";
            this.CommodityTypeColumn.Width = 93;
            // 
            // BuyFromMarketPriceColumn
            // 
            this.BuyFromMarketPriceColumn.AspectName = "BuyFromMarketPrice";
            this.BuyFromMarketPriceColumn.Text = "Local Price";
            this.BuyFromMarketPriceColumn.Width = 72;
            // 
            // SellToMarketPriceColumn
            // 
            this.SellToMarketPriceColumn.AspectName = "SellToMarketPrice";
            this.SellToMarketPriceColumn.Text = "Remote Price";
            this.SellToMarketPriceColumn.Width = 79;
            // 
            // ProfitColumn
            // 
            this.ProfitColumn.AspectName = "Profit";
            this.ProfitColumn.Text = "Profit Per Unit";
            this.ProfitColumn.Width = 88;
            // 
            // LastBuyPriceUpdateColumn
            // 
            this.LastBuyPriceUpdateColumn.AspectName = "LastBuyPriceUpdate";
            this.LastBuyPriceUpdateColumn.Text = "Last Update (Local Price)";
            this.LastBuyPriceUpdateColumn.Width = 135;
            // 
            // LastSellPriceUpdateColumn
            // 
            this.LastSellPriceUpdateColumn.AspectName = "LastSellPriceUpdate";
            this.LastSellPriceUpdateColumn.Text = "Last Update (Remote Price)";
            this.LastSellPriceUpdateColumn.Width = 146;
            // 
            // SpaceStationCommodityDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 542);
            this.Controls.Add(this.ProfitListView);
            this.Controls.Add(this.ComboBoxPanel);
            this.Controls.Add(this.ComboBoxCaption);
            this.Controls.Add(this.ListViewCaption);
            this.Name = "SpaceStationCommodityDialog";
            this.Text = "SpaceStationCommodityDialog";
            ((System.ComponentModel.ISupportInitialize)(this.ProfitListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ListViewCaption;
        private System.Windows.Forms.Label ComboBoxCaption;
        private System.Windows.Forms.Panel ComboBoxPanel;
        private BrightIdeasSoftware.ObjectListView ProfitListView;
        private BrightIdeasSoftware.OLVColumn CommodityGroupColumn;
        private BrightIdeasSoftware.OLVColumn CommodityTypeColumn;
        private BrightIdeasSoftware.OLVColumn BuyFromMarketPriceColumn;
        private BrightIdeasSoftware.OLVColumn LastBuyPriceUpdateColumn;
        private BrightIdeasSoftware.OLVColumn SellToMarketPriceColumn;
        private BrightIdeasSoftware.OLVColumn LastSellPriceUpdateColumn;
        private BrightIdeasSoftware.OLVColumn ProfitColumn;
    }
}