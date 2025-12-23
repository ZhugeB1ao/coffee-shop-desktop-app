namespace CoffeeShop
{
    partial class POSForm
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
            components = new System.ComponentModel.Container();
            panel2 = new Panel();
            labelCoffee = new Label();
            labelCoffeeCategory = new Label();
            numericUpDownAdd = new NumericUpDown();
            buttonAddCoffee = new Button();
            comboBoxProduct = new ComboBox();
            comboBoxCategory = new ComboBox();
            panel3 = new Panel();
            listViewBillInfo = new ListView();
            columnProduct = new ColumnHeader();
            columnPrice = new ColumnHeader();
            columnQuantity = new ColumnHeader();
            columnTotal = new ColumnHeader();
            imageListProduct = new ImageList(components);
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel4 = new Panel();
            label3 = new Label();
            textBoxDiscount = new TextBox();
            label2 = new Label();
            textBoxCost = new TextBox();
            label1 = new Label();
            comboBoxCoupon = new ComboBox();
            labelDiscount = new Label();
            textBoxTotal = new TextBox();
            comboBoxSwitchTable = new ComboBox();
            buttonSwitchTable = new Button();
            buttonCheckOut = new Button();
            flowLayoutPanelTable = new FlowLayoutPanel();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAdd).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(labelCoffee);
            panel2.Controls.Add(labelCoffeeCategory);
            panel2.Controls.Add(numericUpDownAdd);
            panel2.Controls.Add(buttonAddCoffee);
            panel2.Controls.Add(comboBoxProduct);
            panel2.Controls.Add(comboBoxCategory);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(808, 118);
            panel2.TabIndex = 1;
            // 
            // labelCoffee
            // 
            labelCoffee.AutoSize = true;
            labelCoffee.Location = new Point(24, 66);
            labelCoffee.Name = "labelCoffee";
            labelCoffee.Size = new Size(108, 32);
            labelCoffee.TabIndex = 5;
            labelCoffee.Text = "Product :";
            // 
            // labelCoffeeCategory
            // 
            labelCoffeeCategory.AutoSize = true;
            labelCoffeeCategory.Location = new Point(24, 12);
            labelCoffeeCategory.Name = "labelCoffeeCategory";
            labelCoffeeCategory.Size = new Size(122, 32);
            labelCoffeeCategory.TabIndex = 4;
            labelCoffeeCategory.Text = "Category :";
            // 
            // numericUpDownAdd
            // 
            numericUpDownAdd.Location = new Point(679, 42);
            numericUpDownAdd.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDownAdd.Name = "numericUpDownAdd";
            numericUpDownAdd.Size = new Size(101, 39);
            numericUpDownAdd.TabIndex = 3;
            numericUpDownAdd.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // buttonAddCoffee
            // 
            buttonAddCoffee.Location = new Point(518, 12);
            buttonAddCoffee.Name = "buttonAddCoffee";
            buttonAddCoffee.Size = new Size(138, 97);
            buttonAddCoffee.TabIndex = 2;
            buttonAddCoffee.Text = "Add";
            buttonAddCoffee.UseVisualStyleBackColor = true;
            buttonAddCoffee.Click += buttonAddCoffee_Click;
            // 
            // comboBoxProduct
            // 
            comboBoxProduct.DropDownWidth = 290;
            comboBoxProduct.FormattingEnabled = true;
            comboBoxProduct.Location = new Point(202, 66);
            comboBoxProduct.Name = "comboBoxProduct";
            comboBoxProduct.Size = new Size(290, 40);
            comboBoxProduct.TabIndex = 1;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.DropDownWidth = 290;
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(202, 12);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(290, 40);
            comboBoxCategory.TabIndex = 0;
            comboBoxCategory.SelectedIndexChanged += comboBoxCategory_SelectedIndexChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(listViewBillInfo);
            panel3.Controls.Add(flowLayoutPanel1);
            panel3.Location = new Point(3, 127);
            panel3.Name = "panel3";
            panel3.Size = new Size(808, 404);
            panel3.TabIndex = 2;
            // 
            // listViewBillInfo
            // 
            listViewBillInfo.Columns.AddRange(new ColumnHeader[] { columnProduct, columnPrice, columnQuantity, columnTotal });
            listViewBillInfo.FullRowSelect = true;
            listViewBillInfo.GridLines = true;
            listViewBillInfo.LargeImageList = imageListProduct;
            listViewBillInfo.Location = new Point(3, 3);
            listViewBillInfo.Name = "listViewBillInfo";
            listViewBillInfo.Size = new Size(802, 396);
            listViewBillInfo.SmallImageList = imageListProduct;
            listViewBillInfo.TabIndex = 1;
            listViewBillInfo.UseCompatibleStateImageBehavior = false;
            listViewBillInfo.View = View.Details;
            // 
            // columnProduct
            // 
            columnProduct.Text = "Product";
            columnProduct.Width = 348;
            // 
            // columnPrice
            // 
            columnPrice.Text = "Price";
            columnPrice.Width = 150;
            // 
            // columnQuantity
            // 
            columnQuantity.Text = "Quantity";
            columnQuantity.Width = 150;
            // 
            // columnTotal
            // 
            columnTotal.Text = "Total";
            columnTotal.Width = 150;
            // 
            // imageListProduct
            // 
            imageListProduct.ColorDepth = ColorDepth.Depth32Bit;
            imageListProduct.ImageSize = new Size(80, 80);
            imageListProduct.TransparentColor = Color.Transparent;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(287, 113);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(0, 0);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(label3);
            panel4.Controls.Add(textBoxDiscount);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(textBoxCost);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(comboBoxCoupon);
            panel4.Controls.Add(labelDiscount);
            panel4.Controls.Add(textBoxTotal);
            panel4.Controls.Add(comboBoxSwitchTable);
            panel4.Controls.Add(buttonSwitchTable);
            panel4.Controls.Add(buttonCheckOut);
            panel4.Location = new Point(3, 537);
            panel4.Name = "panel4";
            panel4.Size = new Size(808, 196);
            panel4.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(342, 145);
            label3.Name = "label3";
            label3.Size = new Size(77, 32);
            label3.TabIndex = 15;
            label3.Text = "Total :";
            // 
            // textBoxDiscount
            // 
            textBoxDiscount.Location = new Point(453, 76);
            textBoxDiscount.Name = "textBoxDiscount";
            textBoxDiscount.ReadOnly = true;
            textBoxDiscount.Size = new Size(120, 39);
            textBoxDiscount.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(299, 79);
            label2.Name = "label2";
            label2.Size = new Size(120, 32);
            label2.TabIndex = 13;
            label2.Text = "Discount :";
            // 
            // textBoxCost
            // 
            textBoxCost.Location = new Point(453, 16);
            textBoxCost.Name = "textBoxCost";
            textBoxCost.ReadOnly = true;
            textBoxCost.Size = new Size(120, 39);
            textBoxCost.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(346, 16);
            label1.Name = "label1";
            label1.Size = new Size(73, 32);
            label1.TabIndex = 11;
            label1.Text = "Cost :";
            // 
            // comboBoxCoupon
            // 
            comboBoxCoupon.FormattingEnabled = true;
            comboBoxCoupon.Location = new Point(9, 57);
            comboBoxCoupon.Name = "comboBoxCoupon";
            comboBoxCoupon.Size = new Size(229, 40);
            comboBoxCoupon.TabIndex = 10;
            comboBoxCoupon.SelectedIndexChanged += comboBoxCoupon_SelectedIndexChanged;
            // 
            // labelDiscount
            // 
            labelDiscount.AutoSize = true;
            labelDiscount.Location = new Point(9, 16);
            labelDiscount.Name = "labelDiscount";
            labelDiscount.Size = new Size(108, 32);
            labelDiscount.TabIndex = 9;
            labelDiscount.Text = "Discount";
            // 
            // textBoxTotal
            // 
            textBoxTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            textBoxTotal.Location = new Point(453, 128);
            textBoxTotal.Name = "textBoxTotal";
            textBoxTotal.ReadOnly = true;
            textBoxTotal.Size = new Size(120, 57);
            textBoxTotal.TabIndex = 8;
            textBoxTotal.Text = "0";
            textBoxTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // comboBoxSwitchTable
            // 
            comboBoxSwitchTable.DropDownWidth = 290;
            comboBoxSwitchTable.FormattingEnabled = true;
            comboBoxSwitchTable.Location = new Point(9, 153);
            comboBoxSwitchTable.Name = "comboBoxSwitchTable";
            comboBoxSwitchTable.Size = new Size(229, 40);
            comboBoxSwitchTable.TabIndex = 6;
            // 
            // buttonSwitchTable
            // 
            buttonSwitchTable.Location = new Point(9, 103);
            buttonSwitchTable.Name = "buttonSwitchTable";
            buttonSwitchTable.Size = new Size(229, 48);
            buttonSwitchTable.TabIndex = 6;
            buttonSwitchTable.Text = "Change Table";
            buttonSwitchTable.UseVisualStyleBackColor = true;
            buttonSwitchTable.Click += buttonSwitchTable_Click;
            // 
            // buttonCheckOut
            // 
            buttonCheckOut.Location = new Point(600, 57);
            buttonCheckOut.Name = "buttonCheckOut";
            buttonCheckOut.Size = new Size(193, 97);
            buttonCheckOut.TabIndex = 4;
            buttonCheckOut.Text = "Check Out";
            buttonCheckOut.UseVisualStyleBackColor = true;
            buttonCheckOut.Click += buttonCheckOut_Click;
            // 
            // flowLayoutPanelTable
            // 
            flowLayoutPanelTable.AutoScroll = true;
            flowLayoutPanelTable.Location = new Point(817, 3);
            flowLayoutPanelTable.Name = "flowLayoutPanelTable";
            flowLayoutPanelTable.Padding = new Padding(10);
            flowLayoutPanelTable.Size = new Size(828, 730);
            flowLayoutPanelTable.TabIndex = 4;
            // 
            // POSForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1648, 734);
            Controls.Add(flowLayoutPanelTable);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Name = "POSForm";
            Text = "POSForm";
            Load += POSForm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAdd).EndInit();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Panel panel3;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel4;
        private ListView listViewBillInfo;
        private NumericUpDown numericUpDownAdd;
        private Button buttonAddCoffee;
        private ComboBox comboBoxProduct;
        private ComboBox comboBoxCategory;
        private Button buttonCheckOut;
        private FlowLayoutPanel flowLayoutPanelTable;
        private Label labelCoffee;
        private Label labelCoffeeCategory;
        private Button buttonSwitchTable;
        private ComboBox comboBoxSwitchTable;
        private TextBox textBoxTotal;
        private ImageList imageListProduct;
        private ColumnHeader columnProduct;
        private ColumnHeader columnPrice;
        private ColumnHeader columnQuantity;
        private Label labelDiscount;
        private ComboBox comboBoxCoupon;
        private Label label3;
        private TextBox textBoxDiscount;
        private Label label2;
        private TextBox textBoxCost;
        private Label label1;
        private ColumnHeader columnTotal;
    }
}