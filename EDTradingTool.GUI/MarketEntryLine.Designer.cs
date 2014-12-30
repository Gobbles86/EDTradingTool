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
            this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SellToStationPrice = new System.Windows.Forms.MaskedTextBox();
            this.BuyFromStationPrice = new System.Windows.Forms.MaskedTextBox();
            this.Demand = new System.Windows.Forms.MaskedTextBox();
            this.Supply = new System.Windows.Forms.MaskedTextBox();
            this.PlaceHolderLabel = new System.Windows.Forms.Label();
            this.GalacticAverage = new System.Windows.Forms.MaskedTextBox();
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
            this.TableLayout.Controls.Add(this.GalacticAverage, 0, 0);
            this.TableLayout.Controls.Add(this.Supply, 4, 0);
            this.TableLayout.Controls.Add(this.Demand, 3, 0);
            this.TableLayout.Controls.Add(this.BuyFromStationPrice, 2, 0);
            this.TableLayout.Controls.Add(this.SellToStationPrice, 1, 0);
            this.TableLayout.Controls.Add(this.PlaceHolderLabel, 5, 0);
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
            this.SellToStationPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SellToStationPrice.Location = new System.Drawing.Point(59, 3);
            this.SellToStationPrice.Mask = "99999";
            this.SellToStationPrice.MinimumSize = new System.Drawing.Size(50, 4);
            this.SellToStationPrice.Name = "SellToStationPrice";
            this.SellToStationPrice.Size = new System.Drawing.Size(50, 20);
            this.SellToStationPrice.TabIndex = 1;
            this.SellToStationPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BuyFromStationPrice
            // 
            this.BuyFromStationPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BuyFromStationPrice.Location = new System.Drawing.Point(115, 3);
            this.BuyFromStationPrice.Mask = "99999";
            this.BuyFromStationPrice.MinimumSize = new System.Drawing.Size(70, 4);
            this.BuyFromStationPrice.Name = "BuyFromStationPrice";
            this.BuyFromStationPrice.Size = new System.Drawing.Size(70, 20);
            this.BuyFromStationPrice.TabIndex = 2;
            this.BuyFromStationPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Demand
            // 
            this.Demand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Demand.Location = new System.Drawing.Point(191, 3);
            this.Demand.Mask = "9999999";
            this.Demand.MinimumSize = new System.Drawing.Size(70, 4);
            this.Demand.Name = "Demand";
            this.Demand.Size = new System.Drawing.Size(70, 20);
            this.Demand.TabIndex = 3;
            this.Demand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Supply
            // 
            this.Supply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Supply.Location = new System.Drawing.Point(267, 3);
            this.Supply.Mask = "9999999";
            this.Supply.MinimumSize = new System.Drawing.Size(50, 4);
            this.Supply.Name = "Supply";
            this.Supply.Size = new System.Drawing.Size(50, 20);
            this.Supply.TabIndex = 4;
            this.Supply.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PlaceHolderLabel
            // 
            this.PlaceHolderLabel.AutoSize = true;
            this.PlaceHolderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlaceHolderLabel.Location = new System.Drawing.Point(323, 0);
            this.PlaceHolderLabel.Name = "PlaceHolderLabel";
            this.PlaceHolderLabel.Size = new System.Drawing.Size(17, 25);
            this.PlaceHolderLabel.TabIndex = 6;
            // 
            // GalacticAverage
            // 
            this.GalacticAverage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GalacticAverage.Location = new System.Drawing.Point(3, 3);
            this.GalacticAverage.Mask = "99999";
            this.GalacticAverage.MinimumSize = new System.Drawing.Size(50, 4);
            this.GalacticAverage.Name = "GalacticAverage";
            this.GalacticAverage.Size = new System.Drawing.Size(50, 20);
            this.GalacticAverage.TabIndex = 5;
            this.GalacticAverage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
        private System.Windows.Forms.Label PlaceHolderLabel;
        public System.Windows.Forms.MaskedTextBox SellToStationPrice;
        public System.Windows.Forms.MaskedTextBox Supply;
        public System.Windows.Forms.MaskedTextBox Demand;
        public System.Windows.Forms.MaskedTextBox BuyFromStationPrice;
        public System.Windows.Forms.MaskedTextBox GalacticAverage;
    }
}
