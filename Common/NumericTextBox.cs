using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Common
{
    /// <summary>
    /// A TextBox component to display numeric values.
    /// The following operations are supported as input: +, -, *, /, ^
    /// </summary>
    [Serializable()]
    [ToolboxBitmap(typeof(TextBox))]
    public partial class NumericTextBox : TextBox
    {
        private Timer timer;

        #region NumericTextBox Properties
        private decimal value;
        /// <summary>
        /// The current value of the numeric textbox control.
        /// </summary>
        [Description("The current value of the numeric textbox control.")]
        public decimal Value
        {
            get { return this.value; }
            set 
            { 
                this.value = value;
                if (ValueChanged != null)
                    ValueChanged(this, new EventArgs());
            }
        }

        private decimal minimum;
        /// <summary>
        /// Indicates the minimum value for the numeric textbox control.
        /// </summary>
        [Description("Indicates the minimum value for the numeric textbox control.")]
        public decimal Minimum
        {
            get { return minimum; }
            set { minimum = value; }
        }

        private decimal maximum;
        /// <summary>
        /// Indicates the maximum value for the numeric textbox control.
        /// </summary>
        [Description("Indicates the maximum value for the numeric textbox control.")]
        public decimal Maximum
        {
            get { return maximum; }
            set { maximum = value; }
        }

        private int decimalPlaces;
        /// <summary>
        /// Indicates the number of decimal places to display.
        /// </summary>
        [Description("Indicates the number of decimal places to display.")]
        public int DecimalPlaces
        {
            get { return decimalPlaces; }
            set { decimalPlaces = value; }
        }

        private bool enableWarningValue;
        /// <summary>
        /// Indicates whether the background should change if the warning value is exceeded.
        /// </summary>
        [Description("Indicates whether the background should change if the warning value is exceeded.")]
        public bool EnableWarningValue
        {
            get { return enableWarningValue; }
            set { enableWarningValue = value; }
        }

        private bool enableErrorValue;
        /// <summary>
        /// Indicates whether the background should change if the error value is exceeded.
        /// </summary>
        [Description("Indicates whether the background should change if the error value is exceeded.")]
        public bool EnableErrorValue
        {
            get { return enableErrorValue; }
            set { enableErrorValue = value; }
        }

        private decimal warningValue;
        /// <summary>
        /// Indicates the value from which the background of the numeric textbox control
        /// changes to the WarningColor
        /// </summary>
        [Description("Indicates the value from which the background of the numeric textbox control changes to the WarningColor")]
        public decimal WarningValue
        {
            get { return warningValue; }
            set { warningValue = value; }
        }

        private decimal errorValue;
        /// <summary>
        /// Indicates the value from which the background of the numeric textbox control
        /// changes to the ErrorColor
        /// </summary>
        [Description("Indicates the value from which the background of the numeric textbox control changes to the ErrorColor")]
        public decimal ErrorValue
        {
            get { return errorValue; }
            set { errorValue = value; }
        }

        private bool interceptArrowKeys;
        /// <summary>
        /// Indicates whether the numeric textbox control 
        /// will increment and decrement the value 
        /// when the UP ARROW and DOWN ARROW keys are pressed.
        /// </summary>
        [Description("Indicates whether the numeric textbox control will increment and decrement the value when the UP ARROW and DOWN ARROW keys are pressed.")]
        public bool InterceptArrowKeys
        {
            get { return interceptArrowKeys; }
            set { interceptArrowKeys = value; }
        }

        private decimal increment;
        /// <summary>
        /// Indicates the amount to increment or decrement on each UP or DOWN ARROW press.
        /// </summary>
        [Description("Indicates the amount to increment or decrement on each UP or DOWN ARROW press.")]
        public decimal Increment
        {
            get { return increment; }
            set { increment = value; }
        }

        private bool thousandsSeparator;
        /// <summary>
        /// Indicates whether the thousands separator will be inserted between every three decimal digits.
        /// </summary>
        [Description("Indicates whether the thousands separator will be inserted between every three decimal digits.")]
        public bool ThousandsSeparator
        {
            get { return thousandsSeparator; }
            set { thousandsSeparator = value; }
        }

        private Color warningColor;
        /// <summary>
        /// Indicates the background color of the numeric textbox control if the value exceeds the WarningValue.
        /// </summary>
        [Description("Indicates the background color of the numeric textbox control if the value exceeds the WarningValue.")]
        public Color WarningColor
        {
            get { return warningColor; }
            set { warningColor = value; }
        }

        private Color errorColor;
        /// <summary>
        /// Indicates the background color of the numeric textbox control if the value exceeds the ErrorValue.
        /// </summary>
        [Description("Indicates the background color of the numeric textbox control if the value exceeds the ErrorValue.")]
        public Color ErrorColor
        {
            get { return errorColor; }
            set { errorColor = value; }
        }

        /// <summary>
        /// Indicates whether the expression entered should be automatically validated after a time set with the AutoValidationTime property.
        /// </summary>
        [Description("Indicates whether the expression entered should be automatically validated after a time set with the AutoValidationTime property.")]
        public bool AutoValidate
        { get; set; }

        /// <summary>
        /// Gets or sets the time, in milliseconds, before the entered expression will be validated, after the last value change
        /// </summary>
        [Description("Gets or sets the time, in milliseconds, before the entered expression will be validated, after the last value change")]
        public int AutoValidationTime
        { get; set; }

        #endregion

        /// <summary>
        /// Occurs when the value in the numeric textbox control changes.
        /// </summary>
        [Description("Occurs when the value in the numeric textbox control changes.")]
        public event EventHandler ValueChanged;

        #region NumericTextBox Initialization
        /// <summary>
        /// Constructor
        /// </summary>
        public NumericTextBox()
        {
            InitializeComponent();
            InitializeValues();
            TextChanged += new EventHandler(NumericTextBox_TextChanged);
            KeyUp += new KeyEventHandler(NumericTextBox_KeyUp);
            Leave += new EventHandler(NumericTextBox_Leave);
            ValueChanged += new EventHandler(NumericTextBox_ValueChanged);
            timer = new Timer();
            timer.Enabled = false;
            timer.Tick += new EventHandler(timer_Tick);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="container"></param>
        public NumericTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            InitializeValues();
            TextChanged += new EventHandler(NumericTextBox_TextChanged);
            KeyUp += new KeyEventHandler(NumericTextBox_KeyUp);
            Leave += new EventHandler(NumericTextBox_Leave);
            ValueChanged += new EventHandler(NumericTextBox_ValueChanged);
            timer = new Timer();
            timer.Enabled = false;
            timer.Tick += new EventHandler(timer_Tick);
        }

        /// <summary>
        /// Initialize some default values
        /// </summary>
        private void InitializeValues()
        {
            warningColor = System.Drawing.Color.Gold;
            errorColor = System.Drawing.Color.OrangeRed;
            enableErrorValue = false;
            enableWarningValue = false;
            maximum = 100;
            minimum = 0;
            interceptArrowKeys = true;
            increment = 1;
            decimalPlaces = 0;
            AutoValidationTime = 5000;
            AutoValidate = true;
        }
        #endregion

        #region NumericTextBox Event handles
        /// <summary>
        /// Starts a timer to validate the expression if the AutoValidate is set to true.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NumericTextBox_ValueChanged(object sender, EventArgs e)
        {
            if (AutoValidate)
            {
                timer.Interval = AutoValidationTime;
                timer.Start();
            }
        }

        /// <summary>
        /// Validates the expression.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Validate();
            Select(Text.Length, 0);
        }

        /// <summary>
        /// Handles the event when the focus leaves the control, and validates it's value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NumericTextBox_Leave(object sender, EventArgs e)
        {
            Validate();
        }

        /// <summary>
        /// Handles the Up or Down key up events, if InterceptArrowKeys is true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NumericTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (InterceptArrowKeys)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        Value += Increment;
                        Validate();
                        break;

                    case Keys.Down:
                        Value -= Increment;
                        Validate();
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the TextChanged event and tries to parse the text to a decimal value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericTextBox_TextChanged(object sender, EventArgs e)
        {
            timer.Stop();
            decimal v;
            if (MathsEvaluator.TryParse(Text, out v))
            {
                //check if it's between min and max
                if (v > Maximum)
                    v = Maximum;
                else if (v < Minimum)
                    v = Minimum;

                //Change the background color according to the warning and error levels
                Color c = Color.White;
                if (EnableErrorValue && v > ErrorValue)
                    c = ErrorColor;
                else if (EnableWarningValue && v > WarningValue)
                    c = WarningColor;

                BackColor = c;

                //Set the value property
                if (Value.CompareTo(v) != 0)
                    Value = v;
            }
        }
        #endregion

        /// <summary>
        /// Exits editing mode, and replaces the Text to the formatted version of Value
        /// </summary>
        public void Validate()
        {
            string dec = "";
            for (int i = 0; i < DecimalPlaces; i++)
                dec += "#";
            if (dec.Length > 0)
                dec = "." + dec;

            string s;
            if (ThousandsSeparator)
                s = String.Format("{0:0,0" + dec + "}", Value);
            else
                s = String.Format("{0:0" + dec + "}", Value);

            Text = s;
        }

    }
}
