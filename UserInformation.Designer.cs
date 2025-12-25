namespace CoffeeShop
{
    partial class UserInformation
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            pictureBoxImage = new PictureBox();
            textBoxUsername = new TextBox();
            textBoxDisplayname = new TextBox();
            textBoxCitizenid = new TextBox();
            textBoxPhonenumber = new TextBox();
            buttonUploadImage = new Button();
            buttonUpdate = new Button();
            textBoxRole = new TextBox();
            dateTimePickerBirthday = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(103, 470);
            label1.Name = "label1";
            label1.Size = new Size(117, 32);
            label1.TabIndex = 0;
            label1.Text = "BirthDay :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(103, 543);
            label2.Name = "label2";
            label2.Size = new Size(182, 32);
            label2.TabIndex = 1;
            label2.Text = "PhoneNumber :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(103, 391);
            label3.Name = "label3";
            label3.Size = new Size(119, 32);
            label3.TabIndex = 2;
            label3.Text = "CitizenId :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(103, 80);
            label4.Name = "label4";
            label4.Size = new Size(137, 32);
            label4.TabIndex = 3;
            label4.Text = "UserName :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(103, 158);
            label5.Name = "label5";
            label5.Size = new Size(167, 32);
            label5.TabIndex = 4;
            label5.Text = "DisplayName :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(103, 242);
            label6.Name = "label6";
            label6.Size = new Size(72, 32);
            label6.TabIndex = 5;
            label6.Text = "Role :";
            // 
            // pictureBoxImage
            // 
            pictureBoxImage.Location = new Point(1059, 59);
            pictureBoxImage.Name = "pictureBoxImage";
            pictureBoxImage.Size = new Size(463, 443);
            pictureBoxImage.TabIndex = 6;
            pictureBoxImage.TabStop = false;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(346, 73);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(485, 39);
            textBoxUsername.TabIndex = 7;
            // 
            // textBoxDisplayname
            // 
            textBoxDisplayname.Location = new Point(346, 151);
            textBoxDisplayname.Name = "textBoxDisplayname";
            textBoxDisplayname.Size = new Size(485, 39);
            textBoxDisplayname.TabIndex = 8;
            // 
            // textBoxCitizenid
            // 
            textBoxCitizenid.Location = new Point(346, 391);
            textBoxCitizenid.Name = "textBoxCitizenid";
            textBoxCitizenid.Size = new Size(485, 39);
            textBoxCitizenid.TabIndex = 10;
            // 
            // textBoxPhonenumber
            // 
            textBoxPhonenumber.Location = new Point(346, 543);
            textBoxPhonenumber.Name = "textBoxPhonenumber";
            textBoxPhonenumber.Size = new Size(485, 39);
            textBoxPhonenumber.TabIndex = 12;
            // 
            // buttonUploadImage
            // 
            buttonUploadImage.Location = new Point(1344, 521);
            buttonUploadImage.Name = "buttonUploadImage";
            buttonUploadImage.Size = new Size(178, 77);
            buttonUploadImage.TabIndex = 13;
            buttonUploadImage.Text = "Upload Image";
            buttonUploadImage.UseVisualStyleBackColor = true;
            buttonUploadImage.Click += buttonUploadImage_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(890, 543);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(150, 46);
            buttonUpdate.TabIndex = 16;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // textBoxRole
            // 
            textBoxRole.Enabled = false;
            textBoxRole.Location = new Point(346, 242);
            textBoxRole.Name = "textBoxRole";
            textBoxRole.Size = new Size(485, 39);
            textBoxRole.TabIndex = 9;
            // 
            // dateTimePickerBirthday
            // 
            dateTimePickerBirthday.Location = new Point(349, 470);
            dateTimePickerBirthday.Name = "dateTimePickerBirthday";
            dateTimePickerBirthday.Size = new Size(482, 39);
            dateTimePickerBirthday.TabIndex = 17;
            // 
            // UserInformation
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1664, 644);
            Controls.Add(dateTimePickerBirthday);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonUploadImage);
            Controls.Add(textBoxPhonenumber);
            Controls.Add(textBoxCitizenid);
            Controls.Add(textBoxRole);
            Controls.Add(textBoxDisplayname);
            Controls.Add(textBoxUsername);
            Controls.Add(pictureBoxImage);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UserInformation";
            Text = "UserInformation";
            Load += UserInformation_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private PictureBox pictureBoxImage;
        private TextBox textBoxUsername;
        private TextBox textBoxDisplayname;
        private TextBox textBoxCitizenid;
        private TextBox textBoxPhonenumber;
        private Button buttonUploadImage;
        private Button buttonUpdate;
        private TextBox textBoxRole;
        private DateTimePicker dateTimePickerBirthday;
    }
}