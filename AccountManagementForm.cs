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
        UserService userService = new UserService();
        private User loggedInUser;

        public AccountManagementForm(User user)
        {
            InitializeComponent();
            UIHelper.ApplyModernStyle(this);
            this.loggedInUser = user;

            textBoxAccountID.Enabled = false; // Auto-incremented ID, not editable.
            LoadAccount();       // Load account list.
            LoadRoleToComboBox(); // Load roles.
            SetButtonState(false); // Initial state: no row selected.
        }

        // Fetch account data from the database and populate the grid.
        private void LoadAccount()
        {
            var accounts = userService.GetAll();
            dataGridViewAccount.DataSource = accounts;
            HideExtraColumns(); // Hide security-sensitive or unnecessary columns.
        }

        private void AccountManagementForm_Load(object sender, EventArgs e)
        {

        }

        // Handles grid row click to display information in text boxes.
        private void dataGridViewAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewAccount.Rows[e.RowIndex];
            textBoxAccountID.Text = row.Cells["Id"].Value?.ToString();
            textBoxAccountUserName.Text = row.Cells["UserName"].Value?.ToString();
            textBoxAccountDisplayName.Text = row.Cells["DisplayName"].Value?.ToString();
            textBoxPassword.Clear(); // Clear password field for security (don't display directly).
            comboBoxAccountRole.Text = row.Cells["Role"].Value?.ToString();

            SetButtonState(true); // Account selected, enable Edit/Delete buttons.
        }

        // Adds a new account.
        private void buttonAddAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAccountUserName.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống!");
                return;
            }

            if (!Confirm("Bạn có chắc chắn muốn thêm người dùng này?"))
                return;

            var user = new User()
            {
                UserName = textBoxAccountUserName.Text,
                DisplayName = textBoxAccountDisplayName.Text,
                Password = textBoxPassword.Text,
                Role = comboBoxAccountRole.Text,
            };

            userService.Add(user); // Password will be hashed inside the Service.
            LoadAccount();
            MessageBox.Show("Thêm người dùng thành công!");

            ClearForm();
        }

        // Deletes an account.
        private void buttonDeleteAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAccountID.Text))
            {
                MessageBox.Show("Vui lòng chọn người dùng cần xóa!");
                return;
            }

            if (!Confirm("Bạn có chắc chắn muốn xóa người dùng này?"))
                return;

            int id = int.Parse(textBoxAccountID.Text);

            userService.Delete(id);
            LoadAccount();
            MessageBox.Show("Xóa người dùng thành công!");
        }

        // Updates account information.
        private void buttonUpdateAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAccountID.Text))
            {
                MessageBox.Show("Vui lòng chọn người dùng cần cập nhật!");
                return;
            }

            if (!Confirm("Bạn có chắc chắn muốn cập nhật người dùng này?"))
                return;

            var user = new User()
            {
                Id = int.Parse(textBoxAccountID.Text),
                UserName = textBoxAccountUserName.Text,
                DisplayName = textBoxAccountDisplayName.Text,
                Password = textBoxPassword.Text,
                Role = comboBoxAccountRole.Text
            };

            userService.Update(user);
            LoadAccount();
            MessageBox.Show("Cập nhật người dùng thành công!");
            ClearForm();
        }

        // System roles list.
        private void LoadRoleToComboBox()
        {
            comboBoxAccountRole.Items.Clear();
            comboBoxAccountRole.Items.Add("HRManager"); // Personnel Management
            comboBoxAccountRole.Items.Add("IManager");  // Inventory Management
            comboBoxAccountRole.Items.Add("Staff");     // Sales Staff
        }

        private bool Confirm(string message)
        {
            return MessageBox.Show(message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        // Resets input fields.
        private void ClearForm()
        {
            textBoxAccountID.Clear();
            textBoxAccountUserName.Clear();
            textBoxAccountDisplayName.Clear();
            textBoxPassword.Clear();
            comboBoxAccountRole.SelectedIndex = -1;
            SetButtonState(false);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        /// <summary>
        /// Adjusts button enabled states based on whether the user is adding or editing/deleting.
        /// </summary>
        private void SetButtonState(bool accountSelected)
        {
            buttonAddAccount.Enabled = !accountSelected;
            buttonDeleteAccount.Enabled = accountSelected;
            buttonUpdateAccount.Enabled = accountSelected;
            buttonClear.Enabled = accountSelected;
            buttonDetail.Enabled = accountSelected;

            // Disallow editing the UserName (logical primary key).
            textBoxAccountUserName.Enabled = !accountSelected;
        }

        // View detailed information (including profile picture).
        private void buttonDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAccountID.Text))
            {
                MessageBox.Show("Vui lòng chọn người dùng!");
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

        // Search for employee accounts.
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

        // Hide personal/security info from the main grid.
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
    }
}
