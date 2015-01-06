namespace EDTradingTool.GUI.RoutePlanner
{
    partial class ParameterWindow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RebuyCostTextBox = new Common.NumericTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BalanceTextBox = new Common.NumericTextBox(this.components);
            this.SecurityBufferBar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CargoSpaceTextBox = new Common.NumericTextBox(this.components);
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecurityBufferBar)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.RebuyCostTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BalanceTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.SecurityBufferBar, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.OkButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.CargoSpaceTextBox, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(661, 151);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // RebuyCostTextBox
            // 
            this.RebuyCostTextBox.AutoValidate = false;
            this.RebuyCostTextBox.AutoValidationTime = 0;
            this.RebuyCostTextBox.BackColor = System.Drawing.Color.White;
            this.RebuyCostTextBox.DecimalPlaces = 0;
            this.RebuyCostTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RebuyCostTextBox.EnableErrorValue = false;
            this.RebuyCostTextBox.EnableWarningValue = false;
            this.RebuyCostTextBox.ErrorColor = System.Drawing.Color.OrangeRed;
            this.RebuyCostTextBox.ErrorValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.RebuyCostTextBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RebuyCostTextBox.InterceptArrowKeys = true;
            this.RebuyCostTextBox.Location = new System.Drawing.Point(85, 28);
            this.RebuyCostTextBox.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.RebuyCostTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RebuyCostTextBox.Name = "RebuyCostTextBox";
            this.RebuyCostTextBox.Size = new System.Drawing.Size(573, 20);
            this.RebuyCostTextBox.TabIndex = 2;
            this.RebuyCostTextBox.Text = "1";
            this.RebuyCostTextBox.ThousandsSeparator = true;
            this.ToolTip.SetToolTip(this.RebuyCostTextBox, "The amount of money required to buy your ship back");
            this.RebuyCostTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RebuyCostTextBox.WarningColor = System.Drawing.Color.Gold;
            this.RebuyCostTextBox.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rebuy Cost";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Balance";
            // 
            // BalanceTextBox
            // 
            this.BalanceTextBox.AutoValidate = false;
            this.BalanceTextBox.AutoValidationTime = 0;
            this.BalanceTextBox.BackColor = System.Drawing.Color.White;
            this.BalanceTextBox.DecimalPlaces = 0;
            this.BalanceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BalanceTextBox.EnableErrorValue = false;
            this.BalanceTextBox.EnableWarningValue = false;
            this.BalanceTextBox.ErrorColor = System.Drawing.Color.OrangeRed;
            this.BalanceTextBox.ErrorValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BalanceTextBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BalanceTextBox.InterceptArrowKeys = true;
            this.BalanceTextBox.Location = new System.Drawing.Point(85, 3);
            this.BalanceTextBox.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.BalanceTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BalanceTextBox.Name = "BalanceTextBox";
            this.BalanceTextBox.Size = new System.Drawing.Size(573, 20);
            this.BalanceTextBox.TabIndex = 1;
            this.BalanceTextBox.Text = "1";
            this.BalanceTextBox.ThousandsSeparator = true;
            this.ToolTip.SetToolTip(this.BalanceTextBox, "Your current balance");
            this.BalanceTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BalanceTextBox.WarningColor = System.Drawing.Color.Gold;
            this.BalanceTextBox.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // SecurityBufferBar
            // 
            this.SecurityBufferBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SecurityBufferBar.Location = new System.Drawing.Point(85, 78);
            this.SecurityBufferBar.Maximum = 99;
            this.SecurityBufferBar.MaximumSize = new System.Drawing.Size(0, 30);
            this.SecurityBufferBar.MinimumSize = new System.Drawing.Size(0, 30);
            this.SecurityBufferBar.Name = "SecurityBufferBar";
            this.SecurityBufferBar.Size = new System.Drawing.Size(573, 30);
            this.SecurityBufferBar.TabIndex = 5;
            this.SecurityBufferBar.TickFrequency = 5;
            this.ToolTip.SetToolTip(this.SecurityBufferBar, "The percentage of money which shall be kept as a security buffer");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 35);
            this.label4.TabIndex = 5;
            this.label4.Text = "Security Buffer";
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Location = new System.Drawing.Point(583, 125);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 5;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Cargo Space";
            // 
            // CargoSpaceTextBox
            // 
            this.CargoSpaceTextBox.AutoValidate = false;
            this.CargoSpaceTextBox.AutoValidationTime = 0;
            this.CargoSpaceTextBox.BackColor = System.Drawing.Color.White;
            this.CargoSpaceTextBox.DecimalPlaces = 0;
            this.CargoSpaceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CargoSpaceTextBox.EnableErrorValue = false;
            this.CargoSpaceTextBox.EnableWarningValue = false;
            this.CargoSpaceTextBox.ErrorColor = System.Drawing.Color.OrangeRed;
            this.CargoSpaceTextBox.ErrorValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CargoSpaceTextBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CargoSpaceTextBox.InterceptArrowKeys = true;
            this.CargoSpaceTextBox.Location = new System.Drawing.Point(85, 53);
            this.CargoSpaceTextBox.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.CargoSpaceTextBox.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.CargoSpaceTextBox.Name = "CargoSpaceTextBox";
            this.CargoSpaceTextBox.Size = new System.Drawing.Size(573, 20);
            this.CargoSpaceTextBox.TabIndex = 3;
            this.CargoSpaceTextBox.Text = "20";
            this.CargoSpaceTextBox.ThousandsSeparator = false;
            this.CargoSpaceTextBox.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.CargoSpaceTextBox.WarningColor = System.Drawing.Color.Gold;
            this.CargoSpaceTextBox.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ParameterWindow
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 151);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ParameterWindow";
            this.Text = "ParameterWindow";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecurityBufferBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Common.NumericTextBox BalanceTextBox;
        private System.Windows.Forms.TrackBar SecurityBufferBar;
        private Common.NumericTextBox RebuyCostTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label label5;
        private Common.NumericTextBox CargoSpaceTextBox;
    }
}