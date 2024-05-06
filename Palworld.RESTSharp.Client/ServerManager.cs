namespace Palworld.RESTSharp.Client
{
    public partial class ServerManager : UserControl
    {
        PalworldRESTSharpClient palAPIClient;
        ServerInfo palServerInfo;

        public ServerManager()
        {
            InitializeComponent();
        }
        public ServerManager(PalworldRESTSharpClient client)
        {
            InitializeComponent();
            palAPIClient = client;
        }

        private async void ServerManager_Load(object sender, EventArgs e)
        {
            try
            {
                palServerInfo = await palAPIClient.GetServerInfoASync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting server data: {ex.Message}");
                return;
            }
            lblserverName.Text = $"Server Name: {palServerInfo.ServerName}";
            lblserverversion.Text = $"Server Version: {palServerInfo.Version}";
            txtServerDescription.Text = palServerInfo.Description;
        }
    }
}
