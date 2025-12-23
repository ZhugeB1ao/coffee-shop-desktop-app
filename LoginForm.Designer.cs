namespace CoffeeShop
{
    partial class LoginForm
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
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            labelUsername = new Label();
            labelPassword = new Label();
            progressBar1 = new ProgressBar();
            buttonLogin = new Button();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(1105, 234);
            textBoxUsername.Multiline = true;
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(469, 50);
            textBoxUsername.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(1105, 373);
            textBoxPassword.Multiline = true;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(469, 50);
            textBoxPassword.TabIndex = 1;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUsername.Location = new Point(901, 234);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(186, 50);
            labelUsername.TabIndex = 2;
            labelUsername.Text = "Username";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 14F);
            labelPassword.Location = new Point(901, 373);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(177, 51);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Password";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(819, 896);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(843, 21);
            progressBar1.TabIndex = 4;
            // 
            // buttonLogin
            // 
            buttonLogin.Font = new Font("Segoe UI", 14F);
            buttonLogin.Location = new Point(1337, 499);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(237, 87);
            buttonLogin.TabIndex = 5;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.placeholder;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(787, 905);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1674, 929);
            Controls.Add(pictureBox1);
            Controls.Add(buttonLogin);
            Controls.Add(progressBar1);
            Controls.Add(labelPassword);
            Controls.Add(labelUsername);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUsername);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            FormClosing += LoginForm_FormClosing;
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Label labelUsername;
        private Label labelPassword;
        private ProgressBar progressBar1;
        private Button buttonLogin;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
}