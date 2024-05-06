namespace Palworld.RESTSharp.Client
{
    public partial class BroadcastManager : UserControl
    {
        private readonly PalworldRESTSharpClient palAPIClient;

        public BroadcastManager()
        {
            InitializeComponent();

            SetupEvents();
        }

        public BroadcastManager(PalworldRESTSharpClient palAPIClient)
        {
            InitializeComponent();
            this.palAPIClient = palAPIClient;

            SetupEvents();
        }

        private void SetupEvents()
        {
            txtBroadcastMessage.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSendMessage.PerformClick();
                }
            };
        }

        private async void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                pbRequestProgress.Style = ProgressBarStyle.Marquee;

                if (txtBroadcastMessage.Text.Length > 0)
                {
                    await palAPIClient.BroadcastMessageASync(txtBroadcastMessage.Text);
                    txtBroadcastMessage.Clear();
                }

                pbRequestProgress.Style = ProgressBarStyle.Blocks;
                pbRequestProgress.Value = 100;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error broadcasting message: {ex.Message}");
                pbRequestProgress.Value = 0;
                return;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
