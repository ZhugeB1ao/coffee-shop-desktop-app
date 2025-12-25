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
        // ---------------------------------------------------------
        // Fields and Dependencies
        // ---------------------------------------------------------

        // Data object containing the profile of the user currently logged in.
        private User currentUser = null; 
        
        // Logical role identifier used for Role-Based Access Control (RBAC).
        private String role = null;      

        // ---------------------------------------------------------
        // Initialization
        // ---------------------------------------------------------
        public MainForm(User user)
        {
            InitializeComponent();
            UIHelper.ApplyModernStyle(this);

            currentUser = user;
            MessageBox.Show($"Welcome back, {currentUser.DisplayName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.role = currentUser.Role;

            // Display current user identity and initialize the live clock.
            toolStripStatusLabelName.Text = $"User: {currentUser.DisplayName}";
            timerStatusTime.Start();

            // Permissions implementation: Configure available features based on the user's role.
            switch (role)
            {
                case "Admin":
                    // Administrator: Full access to all modules.
                    break;
                case "HRManager":
                    // Human Resources: Personnel management only. 
                    // Inventory, Sales (POS), and Business Statistics are disabled.
                    ingredientToolStripMenuItem.Enabled = false;
                    pOSToolStripMenuItem.Enabled = false;
                    statisticToolStripMenuItem.Enabled = false;
                    break;
                case "IManager":
                    // Inventory Manager: Product and stock management only.
                    // Personnel records, Sales, and Statistics are disabled.
                    accountToolStripMenuItem.Enabled = false;
                    pOSToolStripMenuItem.Enabled = false;
                    statisticToolStripMenuItem.Enabled = false;
                    break;
                case "Staff":
                    // Front-end Staff: Sales processing only.
                    // Management modules and Statistics are restricted.
                    managementToolStripMenuItem.Enabled = false;
                    accountToolStripMenuItem.Enabled = false;
                    ingredientToolStripMenuItem.Enabled = false;
                    statisticToolStripMenuItem.Enabled = false;
                    break;
                default:
                    // Unknown or unassigned role: Restrict all sensitive modules.
                    accountToolStripMenuItem.Enabled = false;
                    ingredientToolStripMenuItem.Enabled = false;
                    pOSToolStripMenuItem.Enabled = false;
                    statisticToolStripMenuItem.Enabled = false;
                    break;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set initial timestamp display.
            toolStripStatusLabelTime.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
        }

        // ---------------------------------------------------------
        // Navigation (Menu Item Handlers)
        // ---------------------------------------------------------

        // Transitions to the Account Management interface.
        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AccountManagementForm(currentUser));
        }

        // Transitions to the Ingredient and Product Management interface.
        private void ingredientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new IngredientManagementForm());
        }

        // Transitions to the Point of Sale (POS) sales interface.
        private void pOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new POSForm());
        }

        // Transitions to the Business Metrics and Revenue Statistics interface.
        private void statisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RevenueStatisticsForm());
        }

        // Transitions to the current user's profile information page.
        private void userInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserInformation(currentUser, currentUser));
        }

        // ---------------------------------------------------------
        // UI Core Logic
        // ---------------------------------------------------------

        /// <summary>
        /// Embeds a child form into the main dashboard panel, docking it to fill the available space.
        /// Previous form controls in the panel are cleared before displaying the new one.
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

        // Updates the clock in the southern status bar on every timer tick (default 1s).
        private void timerStatusTime_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelTime.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
        }

        // Handles secure termination of the current user session.
        private void toolStripButtonLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
