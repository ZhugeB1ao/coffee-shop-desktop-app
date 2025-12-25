using CoffeeShop.BUS;
using CoffeeShop.DAO;
using CoffeeShop.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CoffeeShop.Helper;

namespace CoffeeShop
{
    /// <summary>
    /// Account Management Form: Allows Admin/HRManager to manage the employee list.
    /// </summa
    /// ry>
    public partial class AccountManagementForm : Form
    {
        // ---------------------------------------------------------
        // Fields and Dependencies
        // ---------------------------------------------------------
        private UserService userService = new UserService();
        private User loggedInUser;

        // ---------------------------------------------------------
        // Initialization
        // ---------------------------------------------------------
        public AccountManagementForm(User user)
        {
            InitializeComponent();
            UIHelper.ApplyModernStyle(this);
            this.loggedInUser = user;

            // Setup initial UI state
            textBoxAccountID.Enabled = false; // Auto-incremented ID, not editable.
            LoadAccount();                    // Load employee list into the grid.
            LoadRoleToComboBox();             // Populate role selection.
            SetButtonState(false);            // Disable Edit/Delete until a row is selected.
        }

        private void AccountManagementForm_Load(object sender, EventArgs e)
        {
        }

        // ---------------------------------------------------------
        // Data Loading and UI Refresh
        // ---------------------------------------------------------

        // Fetches all accounts from the service and displays them in the DataGridView.
        private void LoadAccount()
        {
            var accounts = userService.GetAll();
            dataGridViewAccount.DataSource = accounts;
            HideExtraColumns(); // Ensure sensitive data is not shown in the grid.
        }

        // Configures the DataGridView by hiding columns that shouldn't be publicly visible.
        private void HideExtraColumns()
        {
            string[] columnsToHide = { "Password", "CitizenId", "Birthday", "PhoneNumber", "Picture" };
            foreach (string colName in columnsToHide)
            {
                if (dataGridViewAccount.Columns.Contains(colName))
                {
                    dataGridViewAccount.Columns[colName].Visible = false;
                }
            }
        }

        // Populates the role selection ComboBox with predefined system roles.
        private void LoadRoleToComboBox()
        {
            comboBoxAccountRole.Items.Clear();
            comboBoxAccountRole.Items.Add("HRManager"); // Human Resources Management
            comboBoxAccountRole.Items.Add("IManager");  // Inventory Management
            comboBoxAccountRole.Items.Add("Staff");     // Front-end Sales Staff
        }

        // Resets all input fields to their default empty state and updates button availability.
        private void ClearForm()
        {
            textBoxAccountID.Clear();
            textBoxAccountUserName.Clear();
            textBoxAccountDisplayName.Clear();
            textBoxPassword.Clear();
            comboBoxAccountRole.SelectedIndex = -1;
            SetButtonState(false);
        }

        // ---------------------------------------------------------
        // UI Event Handlers
        // ---------------------------------------------------------

        // Populates the form fields with data from the selected row in the grid.
        private void dataGridViewAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewAccount.Rows[e.RowIndex];
            textBoxAccountID.Text = row.Cells["Id"].Value?.ToString();
            textBoxAccountUserName.Text = row.Cells["UserName"].Value?.ToString();
            textBoxAccountDisplayName.Text = row.Cells["DisplayName"].Value?.ToString();
            textBoxPassword.Clear(); // For security, do not display existing hashed password.
            comboBoxAccountRole.Text = row.Cells["Role"].Value?.ToString();

            SetButtonState(true); // Enable Edit/Delete/Detail buttons for the selected account.
        }

        // Collects form data and commands the service to create a new user account.
        private void buttonAddAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAccountUserName.Text))
            {
                MessageBox.Show("Username cannot be empty!", "Input Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Password cannot be empty!", "Input Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = new User()
            {
                UserName = textBoxAccountUserName.Text,
                DisplayName = textBoxAccountDisplayName.Text,
                Password = textBoxPassword.Text,
                Role = comboBoxAccountRole.Text,
            };

            userService.Add(user); // Password hashing is handled by the Business Logic layer.
            LoadAccount();
            ClearForm();
        }

        // Commands the service to remove the selected account based on its ID.
        private void buttonDeleteAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAccountID.Text))
            {
                MessageBox.Show("Please select a user to delete!", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Confirm("Are you sure you want to delete this user?"))
                return;

            int id = int.Parse(textBoxAccountID.Text);

            userService.Delete(id);
            LoadAccount();
            ClearForm();
        }

        // Updates specific fields (Role and Password) of the selected account.
        private void buttonUpdateAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAccountID.Text))
            {
                MessageBox.Show("Please select a user to update!", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(textBoxAccountID.Text);
            string role = comboBoxAccountRole.Text;
            string password = textBoxPassword.Text;

            userService.UpdateAccount(id, role, password);
            LoadAccount();
            ClearForm();
        }

        // Clears current input fields and selection.
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // Opens the UserInformation dialog to show full details including profile picture.
        private void buttonDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAccountID.Text))
            {
                MessageBox.Show("Please select a user first!", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(textBoxAccountID.Text);
            User viewUser = userService.GetAll().FirstOrDefault(u => u.Id == id);

            if (viewUser != null)
            {
                UserInformation detailForm = new UserInformation(viewUser, loggedInUser);
                detailForm.ShowDialog();
            }
        }

        // Filters the grid based on the search keyword provided in the search box.
        private void buttonFindAccount_Click(object sender, EventArgs e)
        {
            string keyword = textBoxFindAccount.Text.Trim();

            List<User> results;
            if (string.IsNullOrEmpty(keyword))
            {
                results = userService.GetAll();
            }
            else
            {
                results = userService.Search(keyword);
            }

            dataGridViewAccount.DataSource = results;
            HideExtraColumns();
            ClearForm();
        }

        // ---------------------------------------------------------
        // Helper Methods
        // ---------------------------------------------------------

        // Shows a confirmation dialog with the given message.
        private bool Confirm(string message)
        {
            return MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>
        /// Adjusts button and textbox enabled states based on whether a row is currently selected.
        /// </summary>
        private void SetButtonState(bool accountSelected)
        {
            buttonAddAccount.Enabled = !accountSelected;
            buttonDeleteAccount.Enabled = accountSelected;
            buttonUpdateAccount.Enabled = accountSelected;
            buttonClear.Enabled = accountSelected;
            buttonDetail.Enabled = accountSelected;

            // Disallow editing the UserName (logical unique identifier) once created.
            textBoxAccountUserName.Enabled = !accountSelected;
        }
    }
}
