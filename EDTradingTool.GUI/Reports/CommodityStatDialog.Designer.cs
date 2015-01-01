namespace EDTradingTool.GUI.Reports
{
    partial class CommodityStatDialog
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SellToStationLabel = new System.Windows.Forms.Label();
            this.BuyFromStationLabel = new System.Windows.Forms.Label();
            this.SellToStationPriceList = new System.Windows.Forms.ListView();
            this.BuyFromStationPriceList = new System.Windows.Forms.ListView();
            this.SingleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SingleHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.SellToStationLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BuyFromStationLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.SellToStationPriceList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BuyFromStationPriceList, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 485);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // SellToStationLabel
            // 
            this.SellToStationLabel.AutoSize = true;
            this.SellToStationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SellToStationLabel.Location = new System.Drawing.Point(3, 0);
            this.SellToStationLabel.Name = "SellToStationLabel";
            this.SellToStationLabel.Size = new System.Drawing.Size(694, 13);
            this.SellToStationLabel.TabIndex = 0;
            this.SellToStationLabel.Text = "SellToStationLabel";
            // 
            // BuyFromStationLabel
            // 
            this.BuyFromStationLabel.AutoSize = true;
            this.BuyFromStationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BuyFromStationLabel.Location = new System.Drawing.Point(3, 242);
            this.BuyFromStationLabel.Name = "BuyFromStationLabel";
            this.BuyFromStationLabel.Size = new System.Drawing.Size(694, 13);
            this.BuyFromStationLabel.TabIndex = 1;
            this.BuyFromStationLabel.Text = "BuyFromStationLabel";
            // 
            // SellToStationPriceList
            // 
            this.SellToStationPriceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SingleColumn});
            this.SellToStationPriceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SellToStationPriceList.Location = new System.Drawing.Point(3, 16);
            this.SellToStationPriceList.Name = "SellToStationPriceList";
            this.SellToStationPriceList.Size = new System.Drawing.Size(694, 223);
            this.SellToStationPriceList.TabIndex = 2;
            this.SellToStationPriceList.UseCompatibleStateImageBehavior = false;
            this.SellToStationPriceList.View = System.Windows.Forms.View.Details;
            // 
            // BuyFromStationPriceList
            // 
            this.BuyFromStationPriceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SingleHeader});
            this.BuyFromStationPriceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BuyFromStationPriceList.Location = new System.Drawing.Point(3, 258);
            this.BuyFromStationPriceList.Name = "BuyFromStationPriceList";
            this.BuyFromStationPriceList.Size = new System.Drawing.Size(694, 224);
            this.BuyFromStationPriceList.TabIndex = 3;
            this.BuyFromStationPriceList.UseCompatibleStateImageBehavior = false;
            this.BuyFromStationPriceList.View = System.Windows.Forms.View.Details;
            // 
            // SingleColumn
            // 
            this.SingleColumn.Text = "Stations which buy";
            this.SingleColumn.Width = 1024;
            // 
            // SingleHeader
            // 
            this.SingleHeader.Text = "Stations which sell";
            this.SingleHeader.Width = 1024;
            // 
            // CommodityStatDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 485);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CommodityStatDialog";
            this.Text = "CommodityStatDialog";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label SellToStationLabel;
        private System.Windows.Forms.Label BuyFromStationLabel;
        private System.Windows.Forms.ListView SellToStationPriceList;
        private System.Windows.Forms.ListView BuyFromStationPriceList;
        private System.Windows.Forms.ColumnHeader SingleColumn;
        private System.Windows.Forms.ColumnHeader SingleHeader;

    }
}