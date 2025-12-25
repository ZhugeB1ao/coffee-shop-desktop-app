namespace CoffeeShop
{
    partial class AccountManagementForm
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
            panel5 = new Panel();
            dataGridViewAccount = new DataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            buttonDeleteAccount = new Button();
            buttonUpdateAccount = new Button();
            buttonAddAccount = new Button();
            panel3 = new Panel();
            textBoxFindAccount = new TextBox();
            buttonFindAccount = new Button();
            panel4 = new Panel();
            buttonDetail = new Button();
            buttonClear = new Button();
            textBoxPassword = new TextBox();
            label3 = new Label();
            textBoxAccountDisplayName = new TextBox();
            label1 = new Label();
            textBoxAccountUserName = new TextBox();
            textBoxAccountID = new TextBox();
            label9 = new Label();
            label10 = new Label();
            comboBoxAccountRole = new ComboBox();
            label2 = new Label();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAccount).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel5
            // 
            panel5.Controls.Add(dataGridViewAccount);
            panel5.Location = new Point(3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(976, 729);
            panel5.TabIndex = 10;
            // 
            // dataGridViewAccount
            // 
            dataGridViewAccount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAccount.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAccount.Location = new Point(3, 3);
            dataGridViewAccount.Name = "dataGridViewAccount";
            dataGridViewAccount.RowHeadersWidth = 82;
            dataGridViewAccount.Size = new Size(970, 723);
            dataGridViewAccount.TabIndex = 0;
            dataGridViewAccount.CellClick += dataGridViewAccount_CellClick;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 163F));
            tableLayoutPanel2.Controls.Add(buttonDeleteAccount, 1, 0);
            tableLayoutPanel2.Controls.Add(buttonUpdateAccount, 2, 0);
            tableLayoutPanel2.Controls.Add(buttonAddAccount, 0, 0);
            tableLayoutPanel2.Location = new Point(1001, 619);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(635, 113);
            tableLayoutPanel2.TabIndex = 11;
            // 
            // buttonDeleteAccount
            // 
            buttonDeleteAccount.Location = new Point(239, 3);
            buttonDeleteAccount.Name = "buttonDeleteAccount";
            buttonDeleteAccount.Size = new Size(152, 105);
            buttonDeleteAccount.TabIndex = 1;
            buttonDeleteAccount.Text = "Delete";
            buttonDeleteAccount.UseVisualStyleBackColor = true;
            buttonDeleteAccount.Click += buttonDeleteAccount_Click;
            // 
            // buttonUpdateAccount
            // 
            buttonUpdateAccount.Location = new Point(475, 3);
            buttonUpdateAccount.Name = "buttonUpdateAccount";
            buttonUpdateAccount.Size = new Size(155, 105);
            buttonUpdateAccount.TabIndex = 2;
            buttonUpdateAccount.Text = "Update";
            buttonUpdateAccount.UseVisualStyleBackColor = true;
            buttonUpdateAccount.Click += buttonUpdateAccount_Click;
            // 
            // buttonAddAccount
            // 
            buttonAddAccount.Location = new Point(3, 3);
            buttonAddAccount.Name = "buttonAddAccount";
            buttonAddAccount.Size = new Size(152, 105);
            buttonAddAccount.TabIndex = 0;
            buttonAddAccount.Text = "Add";
            buttonAddAccount.UseVisualStyleBackColor = true;
            buttonAddAccount.Click += buttonAddAccount_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBoxFindAccount);
            panel3.Controls.Add(buttonFindAccount);
            panel3.Location = new Point(1001, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(635, 72);
            panel3.TabIndex = 12;
            // 
            // textBoxFindAccount
            // 
            textBoxFindAccount.Location = new Point(3, 16);
            textBoxFindAccount.Name = "textBoxFindAccount";
            textBoxFindAccount.Size = new Size(460, 39);
            textBoxFindAccount.TabIndex = 1;
            // 
            // buttonFindAccount
            // 
            buttonFindAccount.Location = new Point(474, 4);
            buttonFindAccount.Name = "buttonFindAccount";
            buttonFindAccount.Size = new Size(158, 63);
            buttonFindAccount.TabIndex = 0;
            buttonFindAccount.Text = "Find";
            buttonFindAccount.UseVisualStyleBackColor = true;
            buttonFindAccount.Click += buttonFindAccount_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(buttonDetail);
            panel4.Controls.Add(buttonClear);
            panel4.Controls.Add(textBoxPassword);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(textBoxAccountDisplayName);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(comboBoxAccountRole);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(textBoxAccountUserName);
            panel4.Controls.Add(textBoxAccountID);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(label10);
            panel4.Location = new Point(1001, 81);
            panel4.Name = "panel4";
            panel4.Size = new Size(635, 532);
            panel4.TabIndex = 13;
            // 
            // buttonDetail
            // 
            buttonDetail.Location = new Point(13, 472);
            buttonDetail.Name = "buttonDetail";
            buttonDetail.Size = new Size(150, 46);
            buttonDetail.TabIndex = 19;
            buttonDetail.Text = "Detail";
            buttonDetail.UseVisualStyleBackColor = true;
            buttonDetail.Click += buttonDetail_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(471, 472);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(150, 46);
            buttonClear.TabIndex = 18;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(206, 213);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(415, 39);
            textBoxPassword.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 220);
            label3.Name = "label3";
            label3.Size = new Size(123, 32);
            label3.TabIndex = 16;
            label3.Text = "Password :";
            // 
            // textBoxAccountDisplayName
            // 
            textBoxAccountDisplayName.Location = new Point(206, 143);
            textBoxAccountDisplayName.Name = "textBoxAccountDisplayName";
            textBoxAccountDisplayName.Size = new Size(415, 39);
            textBoxAccountDisplayName.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 150);
            label1.Name = "label1";
            label1.Size = new Size(170, 32);
            label1.TabIndex = 12;
            label1.Text = "Display name :";
            // 
            // textBoxAccountUserName
            // 
            textBoxAccountUserName.Location = new Point(206, 74);
            textBoxAccountUserName.Name = "textBoxAccountUserName";
            textBoxAccountUserName.Size = new Size(415, 39);
            textBoxAccountUserName.TabIndex = 7;
            // 
            // textBoxAccountID
            // 
            textBoxAccountID.Location = new Point(206, 10);
            textBoxAccountID.Name = "textBoxAccountID";
            textBoxAccountID.Size = new Size(415, 39);
            textBoxAccountID.TabIndex = 6;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(13, 81);
            label9.Name = "label9";
            label9.Size = new Size(133, 32);
            label9.TabIndex = 1;
            label9.Text = "Username :";
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
            // comboBoxAccountRole
            // 
            comboBoxAccountRole.FormattingEnabled = true;
            comboBoxAccountRole.Location = new Point(206, 275);
            comboBoxAccountRole.Name = "comboBoxAccountRole";
            comboBoxAccountRole.Size = new Size(415, 40);
            comboBoxAccountRole.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 283);
            label2.Name = "label2";
            label2.Size = new Size(72, 32);
            label2.TabIndex = 14;
            label2.Text = "Role :";
            // 
            // AccountManagementForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1648, 734);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(panel5);
            Name = "AccountManagementForm";
            Text = "AccountManagementForm";
            Load += AccountManagementForm_Load;
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewAccount).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel5;
        private DataGridView dataGridViewAccount;
        private TableLayoutPanel tableLayoutPanel2;
        private Button buttonDeleteAccount;
        private Button buttonUpdateAccount;
        private Button buttonAddAccount;
        private Panel panel3;
        private TextBox textBoxFindAccount;
        private Button buttonFindAccount;
        private Panel panel4;
        private TextBox textBoxAccountUserName;
        private TextBox textBoxAccountID;
        private Label label9;
        private Label label10;
        private Label label1;
        private TextBox textBoxAccountDisplayName;
        private TextBox textBoxPassword;
        private Label label3;
        private Button buttonClear;
        private Button buttonDetail;
        private Label label2;
        private ComboBox comboBoxAccountRole;
    }
}