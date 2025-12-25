using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShop.DTO;
using CoffeeShop.BUS;
using CoffeeShop.Helper;

namespace CoffeeShop
{
    /// <summary>
    /// Login Form: The entry point of the application.
    /// </summary>
    public partial class LoginForm : Form
    {
        UserService userService = new UserService();
        User loggedInUser = null;

        public LoginForm()
        {
            InitializeComponent();
            // Apply modern styling from UIHelper
            UIHelper.ApplyModernStyle(this);
        }

        // Handles the Login button click event.
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text; // Passwords should not be trimmed.
            
            // Call the Service to verify login credentials.
            loggedInUser = userService.Login(username, password);

            if (loggedInUser == null)
            {
                MessageBox.Show("Incorrect username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If successful, start the progress bar effect.
            progressBar1.Value = 0;
            timer1.Start();
        }

        // Confirm when the user wants to close the application.
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit the application?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        // Progress bar effect and transition to the Main Form.
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 10;
            }
            else
            {
                timer1.Stop();

                // Open the Main Form and pass the logged-in user's information.
                MainForm mainForm = new MainForm(loggedInUser);
                this.Hide(); // Hide the login form

                mainForm.ShowDialog(); // Show the main form

                // After closing the main form, return to the login form.
                progressBar1.Value = 0;
                this.Show();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
