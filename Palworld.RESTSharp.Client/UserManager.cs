using Palworld.RESTSharp.ProxyServer;
using System.Data;

namespace Palworld.RESTSharp.Client
{
    public partial class UserManager : UserControl
    {
        private readonly PalworldRESTSharpClient palAPIClient;
        private User[] userList;
        private User selectedUser;

        public UserManager()
        {
            InitializeComponent();
        }

        public UserManager(PalworldRESTSharpClient client)
        {
            InitializeComponent();
            palAPIClient = client;
        }

        private async void UserManager_Load(object sender, EventArgs e)
        {
            // Load grid with players from the client.
            combUserLevel.DataSource = Enum.GetValues(typeof(UserAccessLevel));
            combUserLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            RefreshUsers();
        }

        private void ClearControls()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            combUserLevel.SelectedIndex = 0;
        }

        private async void RefreshUsers()
        {
            try
            {
                userList = await palAPIClient.ProxyServer.GetUsersASync();
                gridUserList.DataSource = userList;
                gridUserList.Columns["Password"].Visible = false;
                ClearControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Refreshing Users: {ex.Message}");
                return;
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            ClearControls();

            // Write the code to Get the value under the ID column of the selected row..
            int selectedUserID = (int)gridUserList.SelectedRows[0].Cells[0].Value;

            selectedUser = userList.SingleOrDefault(u => u.ID == selectedUserID);

            txtUsername.Text = selectedUser.Username;
            txtPassword.Text = selectedUser.Password;
            combUserLevel.SelectedIndex = (int)selectedUser.Role;
            cbEnabled.Checked = selectedUser.Enabled;
            btnSaveUser.Show();
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            int selectedUserID = (int)gridUserList.SelectedRows[0].Cells[0].Value;

            if (palAPIClient.ProxyServer.ProxyUser.ID == selectedUserID)
            {
                MessageBox.Show("You cannot delete yourself.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this user?", $"Delete User {selectedUserID}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await palAPIClient.ProxyServer.DeleteUserASync(selectedUserID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error Deleting User: {ex.Message}");
                    return;
                }

                RefreshUsers();
                MessageBox.Show("User Deleted.", "User Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill in all fields.", "Error adding User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            User newUser = new User();

            newUser.Username = txtUsername.Text;
            newUser.Password = txtPassword.Text;
            newUser.Role = (UserAccessLevel)combUserLevel.SelectedIndex;
            newUser.Enabled = cbEnabled.Checked;

            try
            {
                await palAPIClient.ProxyServer.AddUserASync(newUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating User: {ex.Message}");
                return;
            }

            ClearControls();
            RefreshUsers();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearControls();
            RefreshUsers();
        }

        private async void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (selectedUser == null)
            {
                MessageBox.Show("No user selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Fields cannot be left blank.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            selectedUser.Username = txtUsername.Text;
            selectedUser.Password = txtPassword.Text;
            selectedUser.Role = (UserAccessLevel)combUserLevel.SelectedIndex;
            selectedUser.Enabled = cbEnabled.Checked;

            try
            {
                await palAPIClient.ProxyServer.UpdateUserASync(selectedUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating User: {ex.Message}");
                return;
            }

            ClearControls();
            RefreshUsers();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
    }
}
