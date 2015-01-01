namespace EDTradingTool.GUI.Reports
{
    partial class ProfitView
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
            this.ProfitListView = new BrightIdeasSoftware.ObjectListView();
            this.CommodityGroupColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CommodityTypeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.BuyFromMarketPriceColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.LastBuyPriceUpdateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.SellToMarketPriceColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.LastSellPriceUpdateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ProfitColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.SupplyColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DemandColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.LocalStationColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.RemoteStationColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ProfitPerInvestmentColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.ProfitListView)).BeginInit();
            this.SuspendLayout();
            // 
            // ProfitListView
            // 
            this.ProfitListView.AllColumns.Add(this.CommodityGroupColumn);
            this.ProfitListView.AllColumns.Add(this.CommodityTypeColumn);
            this.ProfitListView.AllColumns.Add(this.LocalStationColumn);
            this.ProfitListView.AllColumns.Add(this.BuyFromMarketPriceColumn);
            this.ProfitListView.AllColumns.Add(this.SupplyColumn);
            this.ProfitListView.AllColumns.Add(this.LastBuyPriceUpdateColumn);
            this.ProfitListView.AllColumns.Add(this.RemoteStationColumn);
            this.ProfitListView.AllColumns.Add(this.SellToMarketPriceColumn);
            this.ProfitListView.AllColumns.Add(this.DemandColumn);
            this.ProfitListView.AllColumns.Add(this.LastSellPriceUpdateColumn);
            this.ProfitListView.AllColumns.Add(this.ProfitColumn);
            this.ProfitListView.AllColumns.Add(this.ProfitPerInvestmentColumn);
            this.ProfitListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CommodityGroupColumn,
            this.CommodityTypeColumn,
            this.LocalStationColumn,
            this.BuyFromMarketPriceColumn,
            this.SupplyColumn,
            this.LastBuyPriceUpdateColumn,
            this.RemoteStationColumn,
            this.SellToMarketPriceColumn,
            this.DemandColumn,
            this.LastSellPriceUpdateColumn,
            this.ProfitColumn,
            this.ProfitPerInvestmentColumn});
            this.ProfitListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProfitListView.FullRowSelect = true;
            this.ProfitListView.Location = new System.Drawing.Point(0, 0);
            this.ProfitListView.Name = "ProfitListView";
            this.ProfitListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.ProfitListView.ShowCommandMenuOnRightClick = true;
            this.ProfitListView.ShowGroups = false;
            this.ProfitListView.Size = new System.Drawing.Size(1123, 629);
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
            // LastBuyPriceUpdateColumn
            // 
            this.LastBuyPriceUpdateColumn.AspectName = "LastBuyPriceUpdate";
            this.LastBuyPriceUpdateColumn.Text = "Last Update (Local Price)";
            this.LastBuyPriceUpdateColumn.Width = 135;
            // 
            // SellToMarketPriceColumn
            // 
            this.SellToMarketPriceColumn.AspectName = "SellToMarketPrice";
            this.SellToMarketPriceColumn.Text = "Remote Price";
            this.SellToMarketPriceColumn.Width = 79;
            // 
            // LastSellPriceUpdateColumn
            // 
            this.LastSellPriceUpdateColumn.AspectName = "LastSellPriceUpdate";
            this.LastSellPriceUpdateColumn.Text = "Last Update (Remote Price)";
            this.LastSellPriceUpdateColumn.Width = 146;
            // 
            // ProfitColumn
            // 
            this.ProfitColumn.AspectName = "Profit";
            this.ProfitColumn.Text = "Profit Per Unit";
            this.ProfitColumn.Width = 88;
            // 
            // SupplyColumn
            // 
            this.SupplyColumn.AspectName = "Supply";
            this.SupplyColumn.Text = "Supply";
            // 
            // DemandColumn
            // 
            this.DemandColumn.AspectName = "Demand";
            this.DemandColumn.Text = "Demand";
            // 
            // LocalStationColumn
            // 
            this.LocalStationColumn.AspectName = "LocalStation";
            this.LocalStationColumn.Text = "Local Station";
            this.LocalStationColumn.Width = 82;
            // 
            // RemoteStationColumn
            // 
            this.RemoteStationColumn.AspectName = "RemoteStation";
            this.RemoteStationColumn.Text = "Remote Station";
            this.RemoteStationColumn.Width = 97;
            // 
            // ProfitPerInvestmentColumn
            // 
            this.ProfitPerInvestmentColumn.AspectName = "ProfitPerInvestment";
            this.ProfitPerInvestmentColumn.Text = "Profit Per Investment (%)";
            // 
            // ProfitView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProfitListView);
            this.Name = "ProfitView";
            this.Size = new System.Drawing.Size(1123, 629);
            ((System.ComponentModel.ISupportInitialize)(this.ProfitListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.OLVColumn CommodityGroupColumn;
        private BrightIdeasSoftware.OLVColumn CommodityTypeColumn;
        private BrightIdeasSoftware.OLVColumn BuyFromMarketPriceColumn;
        private BrightIdeasSoftware.OLVColumn LastBuyPriceUpdateColumn;
        private BrightIdeasSoftware.OLVColumn SellToMarketPriceColumn;
        private BrightIdeasSoftware.OLVColumn LastSellPriceUpdateColumn;
        private BrightIdeasSoftware.OLVColumn ProfitColumn;
        private BrightIdeasSoftware.OLVColumn SupplyColumn;
        private BrightIdeasSoftware.OLVColumn DemandColumn;
        public BrightIdeasSoftware.ObjectListView ProfitListView;
        public BrightIdeasSoftware.OLVColumn LocalStationColumn;
        public BrightIdeasSoftware.OLVColumn RemoteStationColumn;
        private BrightIdeasSoftware.OLVColumn ProfitPerInvestmentColumn;
    }
}
