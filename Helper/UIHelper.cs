using System;
using System.Drawing;
using System.Windows.Forms;

namespace CoffeeShop.Helper
{
    public static class UIHelper
    {
        // Colors
        public static readonly Color PrimaryColor = Color.FromArgb(100, 50, 0);       // Dark Coffee
        public static readonly Color SecondaryColor = Color.FromArgb(211, 84, 0);   // Burnt Orange
        public static readonly Color BackColor = Color.FromArgb(250, 245, 240);       // Crema White
        public static readonly Color PanelColor = Color.FromArgb(235, 230, 225);      // Lighter Latte
        public static readonly Color TextHeaderColor = Color.FromArgb(30, 30, 30);   // Near Black
        public static readonly Color TextBodyColor = Color.FromArgb(60, 60, 60);      // Dark Gray
        public static readonly Color GridBackColor = Color.White;

        // Fonts
        public static readonly Font HeaderFont = new Font("Segoe UI Semibold", 18);
        public static readonly Font SubHeaderFont = new Font("Segoe UI Semibold", 14);
        public static readonly Font BodyFont = new Font("Segoe UI", 11);
        public static readonly Font SmallFont = new Font("Segoe UI", 9);

        public static void ApplyModernStyle(Form form)
        {
            form.BackColor = BackColor;
            form.ForeColor = TextBodyColor;
            form.Font = BodyFont;

            foreach (Control control in form.Controls)
            {
                ApplyControlStyle(control);
            }
        }

        private static void ApplyControlStyle(Control control)
        {
            if (control is Button btn)
            {
                btn.BackColor = PrimaryColor;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.UseVisualStyleBackColor = false;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.FromArgb(80, 40, 0); // Darker brown border
                btn.Height = Math.Max(btn.Height, 40);
                btn.Cursor = Cursors.Hand;
            }
            else if (control is TextBox txt)
            {
                txt.BackColor = Color.White;
                txt.ForeColor = TextHeaderColor;
                txt.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (control is Label lbl)
            {
                lbl.ForeColor = TextBodyColor;
                if (lbl.Font.Size > 12) lbl.Font = SubHeaderFont;
            }
            else if (control is DataGridView dgv)
            {
                dgv.BackgroundColor = GridBackColor;
                dgv.ForeColor = TextBodyColor;
                dgv.BorderStyle = BorderStyle.FixedSingle;
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.DefaultCellStyle.SelectionBackColor = SecondaryColor;
            }
            else if (control is MenuStrip ms)
            {
                ms.BackColor = PanelColor;
                ms.ForeColor = TextHeaderColor;
                foreach (ToolStripMenuItem item in ms.Items)
                {
                    item.ForeColor = TextHeaderColor;
                    foreach (ToolStripItem sub in item.DropDownItems)
                    {
                        sub.BackColor = PanelColor;
                        sub.ForeColor = TextHeaderColor;
                    }
                }
            }
            else if (control is StatusStrip ss)
            {
                ss.BackColor = PanelColor;
                ss.ForeColor = TextBodyColor;
            }
            else if (control is ToolStrip ts)
            {
                ts.BackColor = PanelColor;
                ts.ForeColor = TextHeaderColor;
            }

            // Recursive apply for ANY control with children (Panels, TableLayoutPanels, etc.)
            if (control.HasChildren)
            {
                foreach (Control child in control.Controls)
                {
                    ApplyControlStyle(child);
                }
            }
        }
    }
}
