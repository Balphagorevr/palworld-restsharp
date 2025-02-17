using Palworld.RESTSharp.ProxyServer;

namespace Palworld.RESTSharp.Client
{
    public partial class ProxyServerManager : UserControl
    {
        PalworldRESTSharpClient palAPIClient;

        public event EventHandler logoutClicked;

        public ProxyServerManager()
        {
            InitializeComponent();
        }

        public ProxyServerManager(PalworldRESTSharpClient client)
        {
            InitializeComponent();
            palAPIClient = client;
        }

        private async void ProxyServerManager_Load(object sender, EventArgs e)
        {
            lblProxyURL.Text = palAPIClient.ProxyServer.ProxyURL;
            lblProxyVersion.Text = $"Version: {palAPIClient.ProxyServer.Version}";
            lblUsername.Text = $"Username: {palAPIClient.ProxyServer.ProxyUser.Username}";
            lblRole.Text = $"Role: {palAPIClient.ProxyServer.ProxyUser.Role}";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (this.logoutClicked != null)
            {
                this.logoutClicked(this, new EventArgs());
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            User proxyUser = palAPIClient.ProxyServer.ProxyUser;
            FormChangePassword formChangePassword = new FormChangePassword();
            formChangePassword.ShowDialog(proxyUser);

            if (formChangePassword.DialogResult == DialogResult.OK)
            {
                proxyUser.Password = formChangePassword.newPassword;
                palAPIClient.ProxyServer.UpdateUserPassword(proxyUser);
                MessageBox.Show("Password updated successfully.", "Password Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
