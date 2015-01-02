using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    /// <summary>
    /// This class can be used for calculating the size of a subcontrol recursively.
    /// </summary>
    public class SubcontrolSizeCalculator
    {
        public static Size GetMinimumControlSize(Control control)
        {
            if (control is TableLayoutPanel) return GetTableLayoutSize(control as TableLayoutPanel);

            var bounds = new Rectangle();

            foreach (Control subControl in control.Controls)
            {
                var subControlSize = GetMinimumControlSize(subControl);
                subControlSize.Width += subControl.Margin.Horizontal;
                subControlSize.Height += subControl.Margin.Vertical;

                bounds = Rectangle.Union(
                    bounds,
                    new Rectangle(subControl.Left, subControl.Top, subControlSize.Width, subControlSize.Height)
                    );
            }

            var minimumSize = control.MinimumSize;

            if (control is ComboBox && minimumSize.Height == 0)
            {
                minimumSize.Height = (control as ComboBox).Font.Height;
            }

            OverrideMinimumSizeIfNecessary(control, ref bounds, ref minimumSize);

            if (minimumSize.Width == 0) minimumSize.Width = control.Size.Width;
            if (minimumSize.Height == 0) minimumSize.Height = control.Size.Height;

            return new Size(
                Math.Max(bounds.Width, minimumSize.Width),
                Math.Max(bounds.Height, minimumSize.Height)
                );
        }

        private static void OverrideMinimumSizeIfNecessary(Control control, ref Rectangle bounds, ref Size minimumSize)
        {
            // No need to have a size for empty placeholder labels
            if (control is Label && (control as Label).Text.Equals(String.Empty)) return;

            // For some reason, setting a minimum size on Tab Pages removes the scrolling functionality.
            if (control is TabPage) return;

            // Show an assertion if the minimum or maximum size is still zero and the control has no children
            if ((minimumSize.Height == 0 || minimumSize.Width == 0) && control.Controls.Count == 0)
            {
                Debug.Assert(
                   false,
                    "Control \"" + control.Name + "\"(" + control.ToString() + ") has no children and no (complete) minimum size defined"
                    );
            }

            bool overrideMinimumSize = false;
            if (minimumSize.Width == 0 && bounds.Width != 0)
            {
                minimumSize.Width = bounds.Width;
                overrideMinimumSize = true;
            }
            if (minimumSize.Height == 0 && bounds.Height != 0)
            {
                minimumSize.Height = bounds.Height;
                overrideMinimumSize = true;
            }            
            if (overrideMinimumSize)
            {
                control.MinimumSize = new Size(minimumSize.Width, minimumSize.Height);
            }
        }

        public static Size GetTableLayoutSize(TableLayoutPanel layoutPanel)
        {
            int[] rowHeights = new int[100];//this.RowCount];
            int[] columnWidths = new int[100];//this.ColumnCount];
            foreach (Control subControl in layoutPanel.Controls)
            {
                var cell = layoutPanel.GetPositionFromControl(subControl);
                var subControlSize = GetMinimumControlSize(subControl);

                Padding subControlMargin = subControl.Margin;
                int width = subControlSize.Width + subControlMargin.Horizontal;
                int height = subControlSize.Height + subControlMargin.Vertical;

                if (width > columnWidths[cell.Column])
                    columnWidths[cell.Column] = width;
                if (height > rowHeights[cell.Row])
                    rowHeights[cell.Row] = height;
            }

            // Note: Include System.Linq to get the Sum() function
            int totalWidth = columnWidths.Sum();
            int totalHeight = rowHeights.Sum();

            var clientSize = new Size(totalWidth, totalHeight);

            // Add the padding to the client size
            clientSize = Size.Add(clientSize, new Size(layoutPanel.Padding.Horizontal, layoutPanel.Padding.Vertical));

            return new Size(
                Math.Max(clientSize.Width, layoutPanel.MinimumSize.Width),
                Math.Max(clientSize.Height, layoutPanel.MinimumSize.Height)
                );
        }
    }
}
