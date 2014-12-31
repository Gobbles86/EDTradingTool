namespace EDTradingTool.GUI
{
    partial class MarketEntryLine
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
            this.components = new System.ComponentModel.Container();
            this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SellToStationPrice = new Common.NumericTextBox(this.components);
            this.BuyFromStationPrice = new Common.NumericTextBox(this.components);
            this.Demand = new Common.NumericTextBox(this.components);
            this.Supply = new Common.NumericTextBox(this.components);
            this.GalacticAverage = new Common.NumericTextBox(this.components);
            this.LastUpdateLabel = new System.Windows.Forms.Label();
            this.TableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayout
            // 
            this.TableLayout.ColumnCount = 6;
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayout.Controls.Add(this.SellToStationPrice, 0, 0);
            this.TableLayout.Controls.Add(this.BuyFromStationPrice, 1, 0);
            this.TableLayout.Controls.Add(this.Demand, 2, 0);
            this.TableLayout.Controls.Add(this.Supply, 3, 0);
            this.TableLayout.Controls.Add(this.GalacticAverage, 4, 0);
            this.TableLayout.Controls.Add(this.LastUpdateLabel, 5, 0);
            this.TableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout.Location = new System.Drawing.Point(0, 0);
            this.TableLayout.Name = "TableLayout";
            this.TableLayout.RowCount = 1;
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout.Size = new System.Drawing.Size(343, 25);
            this.TableLayout.TabIndex = 0;
            // 
            // SellToStationPrice
            // 
            this.SellToStationPrice.AutoValidate = false;
            this.SellToStationPrice.AutoValidationTime = 0;
            this.SellToStationPrice.DecimalPlaces = 0;
            this.SellToStationPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SellToStationPrice.EnableErrorValue = false;
            this.SellToStationPrice.EnableWarningValue = false;
            this.SellToStationPrice.ErrorColor = System.Drawing.Color.OrangeRed;
            this.SellToStationPrice.ErrorValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SellToStationPrice.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SellToStationPrice.InterceptArrowKeys = true;
            this.SellToStationPrice.Location = new System.Drawing.Point(3, 3);
            this.SellToStationPrice.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.SellToStationPrice.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SellToStationPrice.MinimumSize = new System.Drawing.Size(50, 20);
            this.SellToStationPrice.Name = "SellToStationPrice";
            this.SellToStationPrice.Size = new System.Drawing.Size(50, 20);
            this.SellToStationPrice.TabIndex = 0;
            this.SellToStationPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SellToStationPrice.ThousandsSeparator = true;
            this.SellToStationPrice.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SellToStationPrice.WarningColor = System.Drawing.Color.Gold;
            this.SellToStationPrice.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // BuyFromStationPrice
            // 
            this.BuyFromStationPrice.AutoValidate = false;
            this.BuyFromStationPrice.AutoValidationTime = 0;
            this.BuyFromStationPrice.DecimalPlaces = 0;
            this.BuyFromStationPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BuyFromStationPrice.EnableErrorValue = false;
            this.BuyFromStationPrice.EnableWarningValue = false;
            this.BuyFromStationPrice.ErrorColor = System.Drawing.Color.OrangeRed;
            this.BuyFromStationPrice.ErrorValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BuyFromStationPrice.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BuyFromStationPrice.InterceptArrowKeys = true;
            this.BuyFromStationPrice.Location = new System.Drawing.Point(59, 3);
            this.BuyFromStationPrice.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.BuyFromStationPrice.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BuyFromStationPrice.MinimumSize = new System.Drawing.Size(50, 20);
            this.BuyFromStationPrice.Name = "BuyFromStationPrice";
            this.BuyFromStationPrice.Size = new System.Drawing.Size(50, 20);
            this.BuyFromStationPrice.TabIndex = 1;
            this.BuyFromStationPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BuyFromStationPrice.ThousandsSeparator = true;
            this.BuyFromStationPrice.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BuyFromStationPrice.WarningColor = System.Drawing.Color.Gold;
            this.BuyFromStationPrice.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // Demand
            // 
            this.Demand.AutoValidate = false;
            this.Demand.AutoValidationTime = 0;
            this.Demand.DecimalPlaces = 0;
            this.Demand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Demand.EnableErrorValue = false;
            this.Demand.EnableWarningValue = false;
            this.Demand.ErrorColor = System.Drawing.Color.OrangeRed;
            this.Demand.ErrorValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Demand.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Demand.InterceptArrowKeys = true;
            this.Demand.Location = new System.Drawing.Point(115, 3);
            this.Demand.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.Demand.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Demand.MinimumSize = new System.Drawing.Size(70, 20);
            this.Demand.Name = "Demand";
            this.Demand.Size = new System.Drawing.Size(70, 20);
            this.Demand.TabIndex = 2;
            this.Demand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Demand.ThousandsSeparator = true;
            this.Demand.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Demand.WarningColor = System.Drawing.Color.Gold;
            this.Demand.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // Supply
            // 
            this.Supply.AutoValidate = false;
            this.Supply.AutoValidationTime = 0;
            this.Supply.DecimalPlaces = 0;
            this.Supply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Supply.EnableErrorValue = false;
            this.Supply.EnableWarningValue = false;
            this.Supply.ErrorColor = System.Drawing.Color.OrangeRed;
            this.Supply.ErrorValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Supply.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Supply.InterceptArrowKeys = true;
            this.Supply.Location = new System.Drawing.Point(191, 3);
            this.Supply.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.Supply.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Supply.MinimumSize = new System.Drawing.Size(70, 20);
            this.Supply.Name = "Supply";
            this.Supply.Size = new System.Drawing.Size(70, 20);
            this.Supply.TabIndex = 3;
            this.Supply.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Supply.ThousandsSeparator = true;
            this.Supply.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Supply.WarningColor = System.Drawing.Color.Gold;
            this.Supply.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // GalacticAverage
            // 
            this.GalacticAverage.AutoValidate = false;
            this.GalacticAverage.AutoValidationTime = 0;
            this.GalacticAverage.DecimalPlaces = 0;
            this.GalacticAverage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GalacticAverage.EnableErrorValue = false;
            this.GalacticAverage.EnableWarningValue = false;
            this.GalacticAverage.ErrorColor = System.Drawing.Color.OrangeRed;
            this.GalacticAverage.ErrorValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.GalacticAverage.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GalacticAverage.InterceptArrowKeys = true;
            this.GalacticAverage.Location = new System.Drawing.Point(267, 3);
            this.GalacticAverage.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.GalacticAverage.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.GalacticAverage.MinimumSize = new System.Drawing.Size(50, 20);
            this.GalacticAverage.Name = "GalacticAverage";
            this.GalacticAverage.Size = new System.Drawing.Size(50, 20);
            this.GalacticAverage.TabIndex = 4;
            this.GalacticAverage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.GalacticAverage.ThousandsSeparator = true;
            this.GalacticAverage.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.GalacticAverage.WarningColor = System.Drawing.Color.Gold;
            this.GalacticAverage.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // LastUpdateLabel
            // 
            this.LastUpdateLabel.AutoSize = true;
            this.LastUpdateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LastUpdateLabel.Location = new System.Drawing.Point(323, 0);
            this.LastUpdateLabel.Name = "LastUpdateLabel";
            this.LastUpdateLabel.Size = new System.Drawing.Size(17, 25);
            this.LastUpdateLabel.TabIndex = 5;
            // 
            // MarketEntryLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayout);
            this.MaximumSize = new System.Drawing.Size(16777215, 25);
            this.MinimumSize = new System.Drawing.Size(0, 25);
            this.Name = "MarketEntryLine";
            this.Size = new System.Drawing.Size(343, 25);
            this.TableLayout.ResumeLayout(false);
            this.TableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayout;
        private System.Windows.Forms.Label LastUpdateLabel;
        public Common.NumericTextBox SellToStationPrice;
        public Common.NumericTextBox Supply;
        public Common.NumericTextBox Demand;
        public Common.NumericTextBox BuyFromStationPrice;
        public Common.NumericTextBox GalacticAverage;
    }
}
