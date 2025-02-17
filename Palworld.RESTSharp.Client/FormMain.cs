using Microsoft.Win32;
using Palworld.RESTSharp.ProxyServer;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Palworld.RESTSharp.Client
{
    public partial class FormMain : Form
    {
        private PalworldRESTSharpClient palAPIClient;
        private User localProxyUser;

        private ProxyServerManager proxyServerPage;
        private UserManager userManagerPage;
        private PlayerManager playerManagerPage;
        private ServerManager serverManagerPage;
        private BroadcastManager broadcastManagerPage;
        private ServerMetricsPage serverMetricsPage;
        private ServerSettingsPage serverSettingsPage;
        private UnbanUserPage unbanUserPage;
        private StopServerPage stopServerPage;
        private ShutdownServerPage shutdownServerPage;
        private SaveWorldPage saveWorldPage;
        private AuditPage auditPage;

        public FormMain()
        {
            InitializeComponent();

            txtAPIEndpoint.Text = LoadSetting("apiURL") == null ? "" : LoadSetting("apiURL");
            txtPasswordToken.Text = LoadSetting("passwordToken") == null ? "" : LoadSetting("passwordToken");
            cbUseProxy.Checked = bool.Parse(LoadSetting("useProxy") == null ? "false" : LoadSetting("useProxy"));
        }

        public delegate void ProgressDelegate(int progress);

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Text = "Palworld REST Client";
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            menuTree.Visible = false;

        }

        #region Utility

        private string LoadSetting(string key)
        {
            RegistryKey userKey = Registry.CurrentUser.OpenSubKey(@"Software\PalRestSharp");
            return userKey?.GetValue(key)?.ToString();

            //return Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Machine);
        }

        private void UpdateSetting(string key, string data)
        {
            if (string.IsNullOrEmpty(data) || string.IsNullOrEmpty(key)) return;

            RegistryKey userKey = Registry.CurrentUser.CreateSubKey(@"Software\PalRestSharp");
            userKey.SetValue(key, data);
            userKey.Close();
         
        }

        #endregion

        #region Events
        protected void ProxyServerPage_LogoutClicked(object sender, EventArgs e)
        {
            panelConfig.Controls.Clear();
            panelConfig.Controls.Add(connectPanel);
            menuTree.Visible = false;
            connectPanel.Show();
            SetStatusText("Logged out.");
            this.Text = $"Palworld REST Client";
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtAPIEndpoint.Text) || String.IsNullOrEmpty(txtPasswordToken.Text))
                {
                    MessageBox.Show("Please enter API Endpoint and Password Token.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SetStatusText("Connecting...");
                UpdateSetting("apiURL", txtAPIEndpoint.Text);
                UpdateSetting("passwordToken", txtPasswordToken.Text);
                UpdateSetting("useProxy", cbUseProxy.Checked.ToString());

                palAPIClient = new PalworldRESTSharpClient(txtAPIEndpoint.Text, txtPasswordToken.Text, cbUseProxy.Checked);

                SetStatusText("Connected to Palworld server REST API.");

                if (palAPIClient.UsingProxy)
                {
                    localProxyUser = palAPIClient.ProxyServer.ProxyUser;

                    SetStatusText("Connected to proxy server.");
                }

                connectPanel.Hide();
                userManagerPage = new UserManager(palAPIClient);
                proxyServerPage = new ProxyServerManager(palAPIClient);
                proxyServerPage.logoutClicked += ProxyServerPage_LogoutClicked;

                playerManagerPage = new PlayerManager(palAPIClient);
                serverManagerPage = new ServerManager(palAPIClient);
                broadcastManagerPage = new BroadcastManager(palAPIClient);
                serverMetricsPage = new ServerMetricsPage(palAPIClient);
                serverSettingsPage = new ServerSettingsPage(palAPIClient);
                unbanUserPage = new UnbanUserPage(palAPIClient);
                stopServerPage = new StopServerPage(palAPIClient);
                shutdownServerPage = new ShutdownServerPage(palAPIClient);
                saveWorldPage = new SaveWorldPage(palAPIClient);
                auditPage = new AuditPage(palAPIClient);

                CreateNavItems();

                //this.Text = $"Palworld REST Client | {palAPIClient.PalServerInfo.ServerName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStatusText("An error has occured.");
            }
        }

        #endregion

        private void CreateNavItems()
        {
            menuTree.Visible = true;

            if (palAPIClient.UsingProxy)
            {
                UserAccessLevel accessLevel = localProxyUser.Role;
                if (accessLevel > UserAccessLevel.Owner)
                {
                    menuTree.Nodes["nProxyServer"].Nodes.RemoveByKey("nProxyUserManagement");
                    menuTree.Nodes["nProxyServer"].Nodes.RemoveByKey("nUserAuditLog");
                }

                if (accessLevel > UserAccessLevel.Admin)
                {
                    menuTree.Nodes["nServerManagement"].Nodes.RemoveByKey("nSaveWorld");
                    menuTree.Nodes["nServerManagement"].Nodes.RemoveByKey("nStopServer");
                    menuTree.Nodes["nServerManagement"].Nodes.RemoveByKey("nShutdownServer");
                    menuTree.Nodes["nServerManagement"].Nodes.RemoveByKey("nBroadcastMessage");
                    menuTree.Nodes["nServerManagement"].Nodes.RemoveByKey("nServerSettings");
                    menuTree.Nodes["nPlayerManagement"].Nodes.RemoveByKey("nUnbanPlayer");
                }

                if (accessLevel > UserAccessLevel.Moderator)
                {
                    menuTree.Nodes.RemoveByKey("nPlayerManagement");
                }
            }
            else
            {
                menuTree.Nodes.RemoveByKey("nProxyServer");
            }

            //menuTree.Nodes["nProxyServer"].Remove();
            menuTree.SelectedNode = menuTree.Nodes[0];
            menuTree.ExpandAll();
        }


        private void menuTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowPage(e.Node.Text);
        }

        private void ShowPage(string pageName)
        {
            panelConfig.Controls.Clear();

            switch (pageName)
            {
                case "Proxy Server":
                    proxyServerPage.Dock = DockStyle.Fill;
                    panelConfig.Controls.Add(proxyServerPage);
                    break;
                case "User Management":
                    userManagerPage.Dock = DockStyle.Fill;
                    panelConfig.Controls.Add(userManagerPage);
                    break;
                case "Player Management":
                    playerManagerPage.Dock = DockStyle.Fill;
                    panelConfig.Controls.Add(playerManagerPage);
                    break;
                case "Server Management":
                    serverManagerPage.Dock = DockStyle.Fill;
                    panelConfig.Controls.Add(serverManagerPage);
                    break;
                case "Broadcast Message":
                    broadcastManagerPage.Dock = DockStyle.Fill;
                    panelConfig.Controls.Add(broadcastManagerPage);
                    break;
                case "Server Metrics":
                    serverMetricsPage.Dock = DockStyle.Fill;
                    panelConfig.Controls.Add(serverMetricsPage);
                    break;
                case "Server Settings":
                    serverSettingsPage.Dock = DockStyle.Fill;
                    panelConfig.Controls.Add(serverSettingsPage);
                    break;
                case "Unban Player":
                    unbanUserPage.Dock = DockStyle.Fill;
                    panelConfig.Controls.Add(unbanUserPage);
                    break;
                case "Stop Server":
                    stopServerPage.Dock = DockStyle.Fill;
                    panelConfig.Controls.Add(stopServerPage);
                    break;
                case "Shutdown Server":
                    shutdownServerPage.Dock = DockStyle.Fill;
                    panelConfig.Controls.Add(shutdownServerPage);
                    break;
                case "Save World":
                    saveWorldPage.Dock = DockStyle.Fill;
                    panelConfig.Controls.Add(saveWorldPage);
                    break;
                case "User Audit Log":
                    auditPage.Dock = DockStyle.Fill;
                    panelConfig.Controls.Add(auditPage);
                    break;
            }
        }

        // Set status strip status
        private void SetStatusText(string status)
        {
            tsLastAction.Text = status;
        }

        public void DisplayError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
