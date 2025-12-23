using CoffeeShop.DTO;
using CoffeeShop.Helper;

namespace CoffeeShop
{
    /// <summary>
    /// Main Form: The navigation hub of the application.
    /// Uses Role-based Access Control (RBAC) to manage permissions.
    /// </summary>
    public partial class MainForm : Form
    {
        private User currentUser = null; // Currently logged-in user information
        private String role = null;      // User's role

        public MainForm(User user)
        {
            InitializeComponent();
            UIHelper.ApplyModernStyle(this);

            currentUser = user;
            MessageBox.Show($"Chào mừng {currentUser.DisplayName} quay trở lại!");

            this.role = currentUser.Role;

            // Display username and start the status bar clock.
            toolStripStatusLabelName.Text = $"Người dùng: {currentUser.DisplayName}";
            timerStatusTime.Start();

            // Implement permissions: Enable/Disable functions based on Role.
            switch (role)
            {
                case "Admin":
                    // Full access
                    break;
                case "HRManager":
                    // Personnel management only (no inventory, POS, or statistics).
                    ingredientToolStripMenuItem.Enabled = false;
                    pOSToolStripMenuItem.Enabled = false;
                    statisticToolStripMenuItem.Enabled = false;
                    break;
                case "IManager":
                    // Inventory management only (no HR, POS, or statistics).
                    managementToolStripMenuItem.Enabled = false;
                    pOSToolStripMenuItem.Enabled = false;
                    statisticToolStripMenuItem.Enabled = false;
                    break;
                case "Staff":
                    // Staff: POS access only (no management or statistics).
                    managementToolStripMenuItem.Enabled = false;
                    accountToolStripMenuItem.Enabled = false;
                    ingredientToolStripMenuItem.Enabled = false;
                    statisticToolStripMenuItem.Enabled = false;
                    break;
                default:
                    // No permissions by default.
                    accountToolStripMenuItem.Enabled = false;
                    ingredientToolStripMenuItem.Enabled = false;
                    pOSToolStripMenuItem.Enabled = false;
                    statisticToolStripMenuItem.Enabled = false;
                    break;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Display current time when the form is loaded.
            toolStripStatusLabelTime.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
        }

        // Open Account Management screen.
        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AccountManagementForm(currentUser));
        }

        // Open Ingredient/Inventory Management screen.
        private void ingredientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new IngredientManagementForm());
        }

        // Open Sales (POS) screen.
        private void pOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new POSForm());
        }

        // Open Revenue Statistics screen.
        private void statisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RevenueStatisticsForm());
        }

        /// <summary>
        /// Generic function to open child forms within the main panel of MainForm.
        /// </summary>
        private void OpenChildForm(Form childForm)
        {
            panel1.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            childForm.Show();
        }

        // Update the clock every second.
        private void timerStatusTime_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelTime.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
        }

        // Logout processing.
        private void toolStripButtonLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
