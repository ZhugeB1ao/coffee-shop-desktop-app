namespace CoffeeShop
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStrip1 = new ToolStrip();
            toolStripButtonLogout = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelName = new ToolStripStatusLabel();
            toolStripStatusLabelTime = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            systemToolStripMenuItem = new ToolStripMenuItem();
            managementToolStripMenuItem = new ToolStripMenuItem();
            accountToolStripMenuItem = new ToolStripMenuItem();
            ingredientToolStripMenuItem = new ToolStripMenuItem();
            pOSToolStripMenuItem = new ToolStripMenuItem();
            statisticToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            timerStatusTime = new System.Windows.Forms.Timer(components);
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonLogout });
            toolStrip1.Location = new Point(0, 40);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1674, 42);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonLogout
            // 
            toolStripButtonLogout.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonLogout.Image = (Image)resources.GetObject("toolStripButtonLogout.Image");
            toolStripButtonLogout.ImageTransparentColor = Color.Magenta;
            toolStripButtonLogout.Name = "toolStripButtonLogout";
            toolStripButtonLogout.Size = new Size(104, 36);
            toolStripButtonLogout.Text = "Log Out";
            toolStripButtonLogout.TextImageRelation = TextImageRelation.TextAboveImage;
            toolStripButtonLogout.Click += toolStripButtonLogout_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(32, 32);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelName, toolStripStatusLabelTime });
            statusStrip1.Location = new Point(0, 887);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1674, 42);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelName
            // 
            toolStripStatusLabelName.Name = "toolStripStatusLabelName";
            toolStripStatusLabelName.Size = new Size(78, 32);
            toolStripStatusLabelName.Text = "Name";
            // 
            // toolStripStatusLabelTime
            // 
            toolStripStatusLabelTime.Name = "toolStripStatusLabelTime";
            toolStripStatusLabelTime.Size = new Size(67, 32);
            toolStripStatusLabelTime.Text = "Time";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { systemToolStripMenuItem, managementToolStripMenuItem, pOSToolStripMenuItem, statisticToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1674, 40);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // systemToolStripMenuItem
            // 
            systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            systemToolStripMenuItem.Size = new Size(110, 36);
            systemToolStripMenuItem.Text = "System";
            systemToolStripMenuItem.Click += systemToolStripMenuItem_Click;
            // 
            // managementToolStripMenuItem
            // 
            managementToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { accountToolStripMenuItem, ingredientToolStripMenuItem });
            managementToolStripMenuItem.Name = "managementToolStripMenuItem";
            managementToolStripMenuItem.Size = new Size(177, 36);
            managementToolStripMenuItem.Text = "Management";
            // 
            // accountToolStripMenuItem
            // 
            accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            accountToolStripMenuItem.Size = new Size(257, 44);
            accountToolStripMenuItem.Text = "Account";
            accountToolStripMenuItem.Click += accountToolStripMenuItem_Click;
            // 
            // ingredientToolStripMenuItem
            // 
            ingredientToolStripMenuItem.Name = "ingredientToolStripMenuItem";
            ingredientToolStripMenuItem.Size = new Size(257, 44);
            ingredientToolStripMenuItem.Text = "Ingredient";
            ingredientToolStripMenuItem.Click += ingredientToolStripMenuItem_Click;
            // 
            // pOSToolStripMenuItem
            // 
            pOSToolStripMenuItem.Name = "pOSToolStripMenuItem";
            pOSToolStripMenuItem.Size = new Size(78, 36);
            pOSToolStripMenuItem.Text = "POS";
            pOSToolStripMenuItem.Click += pOSToolStripMenuItem_Click;
            // 
            // statisticToolStripMenuItem
            // 
            statisticToolStripMenuItem.Name = "statisticToolStripMenuItem";
            statisticToolStripMenuItem.Size = new Size(115, 36);
            statisticToolStripMenuItem.Text = "Statistic";
            statisticToolStripMenuItem.Click += statisticToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 82);
            panel1.Name = "panel1";
            panel1.Size = new Size(1674, 805);
            panel1.TabIndex = 4;
            // 
            // timerStatusTime
            // 
            timerStatusTime.Enabled = true;
            timerStatusTime.Interval = 1000;
            timerStatusTime.Tick += timerStatusTime_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1674, 929);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            Load += MainForm_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonLogout;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelName;
        private ToolStripStatusLabel toolStripStatusLabelTime;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem systemToolStripMenuItem;
        private ToolStripMenuItem managementToolStripMenuItem;
        private ToolStripMenuItem accountToolStripMenuItem;
        private ToolStripMenuItem ingredientToolStripMenuItem;
        private ToolStripMenuItem pOSToolStripMenuItem;
        private ToolStripMenuItem statisticToolStripMenuItem;
        private Panel panel1;
        private System.Windows.Forms.Timer timerStatusTime;
    }
}
