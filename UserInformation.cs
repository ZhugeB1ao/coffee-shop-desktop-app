using CoffeeShop.BUS;
using CoffeeShop.DTO;
using CoffeeShop.Helper;
using System.IO;

namespace CoffeeShop
{
    /// <summary>
    /// User Information Form: Displays and updates personal information and profile picture.
    /// </summary>
    public partial class UserInformation : Form
    {
        private User viewUser;    // User whose information is being viewed.
        private User currentUser; // User performing the operation (for permission checks).
        private UserService userService = new UserService();

        public UserInformation(User viewUser, User currentUser)
        {
            InitializeComponent();
            UIHelper.ApplyModernStyle(this);
            this.viewUser = viewUser;
            this.currentUser = currentUser;
        }

        private void UserInformation_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
        }

        // Populate user data into input fields.
        private void LoadUserInfo()
        {
            if (viewUser == null) return;

            textBoxUsername.Text = viewUser.UserName;
            textBoxDisplayname.Text = viewUser.DisplayName;
            textBoxRole.Text = viewUser.Role;
            textBoxCitizenid.Text = viewUser.CitizenId;
            textBoxBirthday.Text = viewUser.Birthday?.ToString("dd/MM/yyyy");
            textBoxPhonenumber.Text = viewUser.PhoneNumber;

            // Security: Only the account owner can see their own password.
            if (currentUser != null && currentUser.UserName == viewUser.UserName)
            {
                textBoxPassword.Text = viewUser.Password;
            }
            else
            {
                textBoxPassword.Text = "********";
            }

            // Display profile picture from the byte array (database).
            if (viewUser.Picture != null && viewUser.Picture.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(viewUser.Picture))
                    {
                        pictureBoxImage.Image = Image.FromStream(ms);
                        pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi load ảnh: " + ex.Message);
                }
            }
        }

        // Upload a new profile picture.
        private void buttonUploadImage_Click(object sender, EventArgs e)
        {
            // Permission check: Only the account owner or an Admin can change the picture.
            if (currentUser == null || (currentUser.UserName != viewUser.UserName && currentUser.Role != "Admin"))
            {
                MessageBox.Show("Bạn không có quyền thay đổi ảnh của người dùng này.");
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        byte[] imageBytes = File.ReadAllBytes(ofd.FileName);
                        viewUser.Picture = imageBytes;

                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pictureBoxImage.Image = Image.FromStream(ms);
                            pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
                        }

                        // Update the database immediately.
                        userService.Update(viewUser);
                        MessageBox.Show("Cập nhật ảnh đại diện thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tải ảnh: " + ex.Message);
                    }
                }
            }
        }
    }
}
