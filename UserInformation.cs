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
        // ---------------------------------------------------------
        // Fields and Dependencies
        // ---------------------------------------------------------
        
        // User whose information is currently being viewed/edited.
        private User viewUser;    
        
        // The user currently logged into the application (used for permission checks).
        private User currentUser; 
        
        private UserService userService = new UserService();

        // ---------------------------------------------------------
        // Initialization
        // ---------------------------------------------------------
        public UserInformation(User viewUser, User currentUser)
        {
            InitializeComponent();
            UIHelper.ApplyModernStyle(this);
            this.viewUser = viewUser;
            this.currentUser = currentUser;

            // Permission check: Only the owner of the profile or an Admin can modify information.
            bool canEdit = (currentUser != null && (currentUser.UserName == viewUser.UserName || currentUser.Role == "Admin"));
            
            // Enable/Disable editing fields based on permissions.
            textBoxDisplayname.Enabled = canEdit;
            textBoxCitizenid.Enabled = canEdit;
            dateTimePickerBirthday.Enabled = canEdit;
            textBoxPhonenumber.Enabled = canEdit;
            
            // Actions only available to authorized users.
            buttonUpdate.Enabled = canEdit;
            buttonUploadImage.Enabled = canEdit;
            
            // Security/Consistency: Username and Role are non-editable identifiers in this context.
            textBoxUsername.Enabled = false;
            textBoxRole.Enabled = false;
        }

        private void UserInformation_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
        }

        // ---------------------------------------------------------
        // Data Loading and UI Refresh
        // ---------------------------------------------------------

        // Populates the form controls with the data from the 'viewUser' object.
        private void LoadUserInfo()
        {
            if (viewUser == null) return;

            textBoxUsername.Text = viewUser.UserName;
            textBoxDisplayname.Text = viewUser.DisplayName;
            textBoxRole.Text = viewUser.Role;
            textBoxCitizenid.Text = viewUser.CitizenId;
            
            if (viewUser.Birthday != null)
                dateTimePickerBirthday.Value = viewUser.Birthday.Value;
                
            textBoxPhonenumber.Text = viewUser.PhoneNumber;

            // Load and display the profile picture from the database's byte array.
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
                    MessageBox.Show("Failed to load profile image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ---------------------------------------------------------
        // UI Event Handlers
        // ---------------------------------------------------------

        // Opens a file dialog to select and upload a new profile picture.
        private void buttonUploadImage_Click(object sender, EventArgs e)
        {
            // Redundant permission check before launching file dialog.
            if (currentUser == null || (currentUser.UserName != viewUser.UserName && currentUser.Role != "Admin"))
            {
                MessageBox.Show("You do not have permission to change this user's profile picture.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

                        // Immediately show the new image on the UI.
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pictureBoxImage.Image = Image.FromStream(ms);
                            pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
                        }

                        // Persist the change to the database.
                        userService.Update(viewUser);
                        MessageBox.Show("Profile picture updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while uploading the image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Collects updated personal information and requests the service to perform a partial update.
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (viewUser == null) return;

            if (MessageBox.Show("Are you sure you want to update this information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                // Synchronize DTO with form fields.
                viewUser.DisplayName = textBoxDisplayname.Text;
                viewUser.CitizenId = textBoxCitizenid.Text;
                viewUser.Birthday = dateTimePickerBirthday.Value;
                viewUser.PhoneNumber = textBoxPhonenumber.Text;

                // Call the specific partial update method to prevent overwriting Password or Role.
                userService.UpdatePersonalInfo(viewUser);

                MessageBox.Show("Information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserInfo(); // Refresh UI to match persistent state.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
