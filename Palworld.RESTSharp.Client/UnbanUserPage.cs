namespace Palworld.RESTSharp.Client
{
    public partial class UnbanUserPage : UserControl
    {
        private PalworldRESTSharpClient palAPIClient;

        public UnbanUserPage()
        {
            InitializeComponent();
        }
        public UnbanUserPage(PalworldRESTSharpClient palAPIClient)
        {
            InitializeComponent();
            this.palAPIClient = palAPIClient;
        }
        private void UnbanUserPage_Load(object sender, EventArgs e)
        {

        }

        private async void btnUnban_Click(object sender, EventArgs e)
        {
            //await palAPIClient.UnbanPlayerASync(txtUnbanSteamID.Text);
            try
            {
                await palAPIClient.UnbanPlayerASync(txtUnbanSteamID.Text);
                txtUnbanSteamID.Clear();

                MessageBox.Show($"Player ID {txtUnbanSteamID.Text} has been unbanned.", "Player unbanned", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Failed to unban ID {txtUnbanSteamID.Text}.", $"Failed to unban player ID: {ex.Message}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
