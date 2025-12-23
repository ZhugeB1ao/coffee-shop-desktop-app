namespace CoffeeShop
{
    partial class IngredientManagementForm
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
            splitContainer1 = new SplitContainer();
            treeViewCategory = new TreeView();
            listViewProduct = new ListView();
            imageListProduct = new ImageList(components);
            buttonUpdateProduct = new Button();
            buttonDeleteProduct = new Button();
            buttonAddProduct = new Button();
            panel1 = new Panel();
            textBoxFindProduct = new TextBox();
            buttonFindProduct = new Button();
            panel2 = new Panel();
            buttonClearProductInfo = new Button();
            textBoxProductImagePath = new TextBox();
            numericUpDownProductPrice = new NumericUpDown();
            comboBoxCategoryName = new ComboBox();
            buttonProductUpLoad = new Button();
            textBoxProductName = new TextBox();
            textBoxProductID = new TextBox();
            label5 = new Label();
            pictureBoxProductImage = new PictureBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tabControlIngredient = new TabControl();
            tabPageCategory = new TabPage();
            panel5 = new Panel();
            dataGridViewCategory = new DataGridView();
            panel4 = new Panel();
            buttonClearCategoryInfo = new Button();
            textBoxCategoryName = new TextBox();
            textBoxCategoryID = new TextBox();
            label9 = new Label();
            label10 = new Label();
            panel3 = new Panel();
            textBoxFindCategory = new TextBox();
            buttonFindCategory = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            buttonDeleteCategory = new Button();
            buttonUpdateCategory = new Button();
            buttonAddCategory = new Button();
            tabPageProduct = new TabPage();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownProductPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProductImage).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tabControlIngredient.SuspendLayout();
            tabPageCategory.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategory).BeginInit();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tabPageProduct.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(2, 6);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeViewCategory);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(listViewProduct);
            splitContainer1.Size = new Size(980, 662);
            splitContainer1.SplitterDistance = 267;
            splitContainer1.TabIndex = 1;
            // 
            // treeViewCategory
            // 
            treeViewCategory.Location = new Point(3, 5);
            treeViewCategory.Name = "treeViewCategory";
            treeViewCategory.Size = new Size(261, 654);
            treeViewCategory.TabIndex = 0;
            treeViewCategory.AfterSelect += treeViewCategory_AfterSelect;
            // 
            // listViewProduct
            // 
            listViewProduct.LargeImageList = imageListProduct;
            listViewProduct.Location = new Point(3, 5);
            listViewProduct.Name = "listViewProduct";
            listViewProduct.Size = new Size(703, 654);
            listViewProduct.TabIndex = 0;
            listViewProduct.UseCompatibleStateImageBehavior = false;
            listViewProduct.SelectedIndexChanged += listViewProduct_SelectedIndexChanged;
            // 
            // imageListProduct
            // 
            imageListProduct.ColorDepth = ColorDepth.Depth32Bit;
            imageListProduct.ImageSize = new Size(70, 70);
            imageListProduct.TransparentColor = Color.Transparent;
            // 
            // buttonUpdateProduct
            // 
            buttonUpdateProduct.Location = new Point(475, 3);
            buttonUpdateProduct.Name = "buttonUpdateProduct";
            buttonUpdateProduct.Size = new Size(155, 105);
            buttonUpdateProduct.TabIndex = 2;
            buttonUpdateProduct.Text = "Update";
            buttonUpdateProduct.UseVisualStyleBackColor = true;
            buttonUpdateProduct.Click += buttonUpdateProduct_Click;
            // 
            // buttonDeleteProduct
            // 
            buttonDeleteProduct.Location = new Point(239, 3);
            buttonDeleteProduct.Name = "buttonDeleteProduct";
            buttonDeleteProduct.Size = new Size(152, 105);
            buttonDeleteProduct.TabIndex = 1;
            buttonDeleteProduct.Text = "Delete";
            buttonDeleteProduct.UseVisualStyleBackColor = true;
            buttonDeleteProduct.Click += buttonDeleteProduct_Click;
            // 
            // buttonAddProduct
            // 
            buttonAddProduct.Location = new Point(3, 3);
            buttonAddProduct.Name = "buttonAddProduct";
            buttonAddProduct.Size = new Size(152, 105);
            buttonAddProduct.TabIndex = 0;
            buttonAddProduct.Text = "Add";
            buttonAddProduct.UseVisualStyleBackColor = true;
            buttonAddProduct.Click += buttonAddProduct_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBoxFindProduct);
            panel1.Controls.Add(buttonFindProduct);
            panel1.Location = new Point(988, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(635, 72);
            panel1.TabIndex = 3;
            // 
            // textBoxFindProduct
            // 
            textBoxFindProduct.Location = new Point(3, 16);
            textBoxFindProduct.Name = "textBoxFindProduct";
            textBoxFindProduct.Size = new Size(460, 39);
            textBoxFindProduct.TabIndex = 1;
            // 
            // buttonFindProduct
            // 
            buttonFindProduct.Location = new Point(474, 4);
            buttonFindProduct.Name = "buttonFindProduct";
            buttonFindProduct.Size = new Size(158, 63);
            buttonFindProduct.TabIndex = 0;
            buttonFindProduct.Text = "Find";
            buttonFindProduct.UseVisualStyleBackColor = true;
            buttonFindProduct.Click += buttonFindProduct_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonClearProductInfo);
            panel2.Controls.Add(textBoxProductImagePath);
            panel2.Controls.Add(numericUpDownProductPrice);
            panel2.Controls.Add(comboBoxCategoryName);
            panel2.Controls.Add(buttonProductUpLoad);
            panel2.Controls.Add(textBoxProductName);
            panel2.Controls.Add(textBoxProductID);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(pictureBoxProductImage);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(988, 84);
            panel2.Name = "panel2";
            panel2.Size = new Size(635, 465);
            panel2.TabIndex = 4;
            // 
            // buttonClearProductInfo
            // 
            buttonClearProductInfo.Location = new Point(3, 351);
            buttonClearProductInfo.Name = "buttonClearProductInfo";
            buttonClearProductInfo.Size = new Size(150, 46);
            buttonClearProductInfo.TabIndex = 14;
            buttonClearProductInfo.Text = "Clear";
            buttonClearProductInfo.UseVisualStyleBackColor = true;
            buttonClearProductInfo.Click += buttonClearProductInfo_Click;
            // 
            // textBoxProductImagePath
            // 
            textBoxProductImagePath.Location = new Point(250, 232);
            textBoxProductImagePath.Name = "textBoxProductImagePath";
            textBoxProductImagePath.Size = new Size(371, 39);
            textBoxProductImagePath.TabIndex = 13;
            // 
            // numericUpDownProductPrice
            // 
            numericUpDownProductPrice.Location = new Point(250, 114);
            numericUpDownProductPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numericUpDownProductPrice.Name = "numericUpDownProductPrice";
            numericUpDownProductPrice.Size = new Size(371, 39);
            numericUpDownProductPrice.TabIndex = 12;
            // 
            // comboBoxCategoryName
            // 
            comboBoxCategoryName.FormattingEnabled = true;
            comboBoxCategoryName.Location = new Point(250, 170);
            comboBoxCategoryName.Name = "comboBoxCategoryName";
            comboBoxCategoryName.Size = new Size(371, 40);
            comboBoxCategoryName.TabIndex = 11;
            // 
            // buttonProductUpLoad
            // 
            buttonProductUpLoad.Location = new Point(5, 403);
            buttonProductUpLoad.Name = "buttonProductUpLoad";
            buttonProductUpLoad.Size = new Size(150, 59);
            buttonProductUpLoad.TabIndex = 10;
            buttonProductUpLoad.Text = "Up Load";
            buttonProductUpLoad.UseVisualStyleBackColor = true;
            buttonProductUpLoad.Click += buttonProductUpLoad_Click;
            // 
            // textBoxProductName
            // 
            textBoxProductName.Location = new Point(250, 60);
            textBoxProductName.Name = "textBoxProductName";
            textBoxProductName.Size = new Size(371, 39);
            textBoxProductName.TabIndex = 7;
            // 
            // textBoxProductID
            // 
            textBoxProductID.Location = new Point(250, 10);
            textBoxProductID.Name = "textBoxProductID";
            textBoxProductID.Size = new Size(371, 39);
            textBoxProductID.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 232);
            label5.Name = "label5";
            label5.Size = new Size(99, 32);
            label5.TabIndex = 5;
            label5.Text = "Picture :";
            // 
            // pictureBoxProductImage
            // 
            pictureBoxProductImage.Location = new Point(250, 291);
            pictureBoxProductImage.Name = "pictureBoxProductImage";
            pictureBoxProductImage.Size = new Size(371, 171);
            pictureBoxProductImage.TabIndex = 4;
            pictureBoxProductImage.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 170);
            label4.Name = "label4";
            label4.Size = new Size(193, 32);
            label4.TabIndex = 3;
            label4.Text = "Category Name :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 116);
            label3.Name = "label3";
            label3.Size = new Size(77, 32);
            label3.TabIndex = 2;
            label3.Text = "Price :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 67);
            label2.Name = "label2";
            label2.Size = new Size(90, 32);
            label2.TabIndex = 1;
            label2.Text = "Name :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 17);
            label1.Name = "label1";
            label1.Size = new Size(49, 32);
            label1.TabIndex = 0;
            label1.Text = "ID :";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 163F));
            tableLayoutPanel1.Controls.Add(buttonDeleteProduct, 1, 0);
            tableLayoutPanel1.Controls.Add(buttonUpdateProduct, 2, 0);
            tableLayoutPanel1.Controls.Add(buttonAddProduct, 0, 0);
            tableLayoutPanel1.Location = new Point(988, 555);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(635, 113);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // tabControlIngredient
            // 
            tabControlIngredient.Controls.Add(tabPageCategory);
            tabControlIngredient.Controls.Add(tabPageProduct);
            tabControlIngredient.Location = new Point(3, 4);
            tabControlIngredient.Name = "tabControlIngredient";
            tabControlIngredient.SelectedIndex = 0;
            tabControlIngredient.Size = new Size(1645, 728);
            tabControlIngredient.TabIndex = 1;
            tabControlIngredient.SelectedIndexChanged += tabControlIngredient_SelectedIndexChanged;
            // 
            // tabPageCategory
            // 
            tabPageCategory.Controls.Add(panel5);
            tabPageCategory.Controls.Add(panel4);
            tabPageCategory.Controls.Add(panel3);
            tabPageCategory.Controls.Add(tableLayoutPanel2);
            tabPageCategory.Location = new Point(8, 46);
            tabPageCategory.Name = "tabPageCategory";
            tabPageCategory.Padding = new Padding(3);
            tabPageCategory.Size = new Size(1629, 674);
            tabPageCategory.TabIndex = 0;
            tabPageCategory.Text = "Category Management";
            tabPageCategory.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.Controls.Add(dataGridViewCategory);
            panel5.Location = new Point(647, 6);
            panel5.Name = "panel5";
            panel5.Size = new Size(976, 665);
            panel5.TabIndex = 9;
            // 
            // dataGridViewCategory
            // 
            dataGridViewCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCategory.Dock = DockStyle.Fill;
            dataGridViewCategory.Location = new Point(0, 0);
            dataGridViewCategory.Name = "dataGridViewCategory";
            dataGridViewCategory.RowHeadersWidth = 82;
            dataGridViewCategory.Size = new Size(976, 665);
            dataGridViewCategory.TabIndex = 0;
            dataGridViewCategory.CellClick += dataGridViewCategory_CellClick;
            // 
            // panel4
            // 
            panel4.Controls.Add(buttonClearCategoryInfo);
            panel4.Controls.Add(textBoxCategoryName);
            panel4.Controls.Add(textBoxCategoryID);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(label10);
            panel4.Location = new Point(6, 84);
            panel4.Name = "panel4";
            panel4.Size = new Size(635, 465);
            panel4.TabIndex = 8;
            // 
            // buttonClearCategoryInfo
            // 
            buttonClearCategoryInfo.Location = new Point(475, 407);
            buttonClearCategoryInfo.Name = "buttonClearCategoryInfo";
            buttonClearCategoryInfo.Size = new Size(150, 46);
            buttonClearCategoryInfo.TabIndex = 8;
            buttonClearCategoryInfo.Text = "Clear";
            buttonClearCategoryInfo.UseVisualStyleBackColor = true;
            buttonClearCategoryInfo.Click += buttonClearCategoryInfo_Click;
            // 
            // textBoxCategoryName
            // 
            textBoxCategoryName.Location = new Point(206, 60);
            textBoxCategoryName.Name = "textBoxCategoryName";
            textBoxCategoryName.Size = new Size(415, 39);
            textBoxCategoryName.TabIndex = 7;
            // 
            // textBoxCategoryID
            // 
            textBoxCategoryID.Location = new Point(206, 10);
            textBoxCategoryID.Name = "textBoxCategoryID";
            textBoxCategoryID.Size = new Size(415, 39);
            textBoxCategoryID.TabIndex = 6;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(13, 67);
            label9.Name = "label9";
            label9.Size = new Size(90, 32);
            label9.TabIndex = 1;
            label9.Text = "Name :";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(13, 17);
            label10.Name = "label10";
            label10.Size = new Size(49, 32);
            label10.TabIndex = 0;
            label10.Text = "ID :";
            // 
            // panel3
            // 
            panel3.Controls.Add(textBoxFindCategory);
            panel3.Controls.Add(buttonFindCategory);
            panel3.Location = new Point(6, 6);
            panel3.Name = "panel3";
            panel3.Size = new Size(635, 72);
            panel3.TabIndex = 7;
            // 
            // textBoxFindCategory
            // 
            textBoxFindCategory.Location = new Point(3, 16);
            textBoxFindCategory.Name = "textBoxFindCategory";
            textBoxFindCategory.Size = new Size(460, 39);
            textBoxFindCategory.TabIndex = 1;
            // 
            // buttonFindCategory
            // 
            buttonFindCategory.Location = new Point(474, 4);
            buttonFindCategory.Name = "buttonFindCategory";
            buttonFindCategory.Size = new Size(158, 63);
            buttonFindCategory.TabIndex = 0;
            buttonFindCategory.Text = "Find";
            buttonFindCategory.UseVisualStyleBackColor = true;
            buttonFindCategory.Click += buttonFindCategory_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 163F));
            tableLayoutPanel2.Controls.Add(buttonDeleteCategory, 1, 0);
            tableLayoutPanel2.Controls.Add(buttonUpdateCategory, 2, 0);
            tableLayoutPanel2.Controls.Add(buttonAddCategory, 0, 0);
            tableLayoutPanel2.Location = new Point(6, 555);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(635, 113);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // buttonDeleteCategory
            // 
            buttonDeleteCategory.Location = new Point(239, 3);
            buttonDeleteCategory.Name = "buttonDeleteCategory";
            buttonDeleteCategory.Size = new Size(152, 105);
            buttonDeleteCategory.TabIndex = 1;
            buttonDeleteCategory.Text = "Delete";
            buttonDeleteCategory.UseVisualStyleBackColor = true;
            buttonDeleteCategory.Click += buttonDeleteCategory_Click;
            // 
            // buttonUpdateCategory
            // 
            buttonUpdateCategory.Location = new Point(475, 3);
            buttonUpdateCategory.Name = "buttonUpdateCategory";
            buttonUpdateCategory.Size = new Size(155, 105);
            buttonUpdateCategory.TabIndex = 2;
            buttonUpdateCategory.Text = "Update";
            buttonUpdateCategory.UseVisualStyleBackColor = true;
            buttonUpdateCategory.Click += buttonUpdateCategory_Click;
            // 
            // buttonAddCategory
            // 
            buttonAddCategory.Location = new Point(3, 3);
            buttonAddCategory.Name = "buttonAddCategory";
            buttonAddCategory.Size = new Size(152, 105);
            buttonAddCategory.TabIndex = 0;
            buttonAddCategory.Text = "Add";
            buttonAddCategory.UseVisualStyleBackColor = true;
            buttonAddCategory.Click += buttonAddCategory_Click;
            // 
            // tabPageProduct
            // 
            tabPageProduct.Controls.Add(splitContainer1);
            tabPageProduct.Controls.Add(tableLayoutPanel1);
            tabPageProduct.Controls.Add(panel2);
            tabPageProduct.Controls.Add(panel1);
            tabPageProduct.Location = new Point(8, 46);
            tabPageProduct.Name = "tabPageProduct";
            tabPageProduct.Padding = new Padding(3);
            tabPageProduct.Size = new Size(1629, 674);
            tabPageProduct.TabIndex = 1;
            tabPageProduct.Text = "Product Management";
            tabPageProduct.UseVisualStyleBackColor = true;
            // 
            // IngredientManagementForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1647, 734);
            Controls.Add(tabControlIngredient);
            Name = "IngredientManagementForm";
            Text = "IngredientForm";
            Load += IngredientManagementForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownProductPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProductImage).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tabControlIngredient.ResumeLayout(false);
            tabPageCategory.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategory).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tabPageProduct.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private SplitContainer splitContainer1;
        private TreeView treeViewCategory;
        private ListView listViewProduct;
        private Panel panel1;
        private Panel panel2;
        private Button buttonUpdateProduct;
        private Button buttonDeleteProduct;
        private Button buttonAddProduct;
        private Button buttonFindProduct;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBoxFindProduct;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TabControl tabControlIngredient;
        private TabPage tabPageCategory;
        private TabPage tabPageProduct;
        private ImageList imageListProduct;
        private PictureBox pictureBoxProductImage;
        private Label label5;
        private TextBox textBoxProductID;
        private TextBox textBoxProductName;
        private Button buttonProductUpLoad;
        private TableLayoutPanel tableLayoutPanel2;
        private Button buttonDeleteCategory;
        private Button buttonUpdateCategory;
        private Button buttonAddCategory;
        private Panel panel3;
        private TextBox textBoxFindCategory;
        private Button buttonFindCategory;
        private Panel panel4;
        private TextBox textBoxCategoryName;
        private TextBox textBoxCategoryID;
        private Label label9;
        private Label label10;
        private Panel panel5;
        private DataGridView dataGridViewCategory;
        private ComboBox comboBoxCategoryName;
        private NumericUpDown numericUpDownProductPrice;
        private TextBox textBoxProductImagePath;
        private Button buttonClearCategoryInfo;
        private Button buttonClearProductInfo;
    }
}