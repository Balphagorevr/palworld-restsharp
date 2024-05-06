namespace Palworld.RESTSharp.Client
{
    public partial class ShutdownServerPage : UserControl
    {
        private PalworldRESTSharpClient palAPIClient;
        public ShutdownServerPage()
        {
            InitializeComponent();
        }

        public ShutdownServerPage(PalworldRESTSharpClient palAPIClient)
        {
            InitializeComponent();
            this.palAPIClient = palAPIClient;
        }

        private async void btnShutdownServer_Click(object sender, EventArgs e)
        {
            int delaySeconds = (int)numSeconds.Value;
            string message = txtShutdownMessage.Text;

            // Get confirmation user wants to stop the server.
            if (delaySeconds > 0 && !String.IsNullOrEmpty(message))
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to shutdown the server in {delaySeconds} seconds?", "Shutdown Server", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        pbRequestProgress.Style = ProgressBarStyle.Marquee;
                        await palAPIClient.ShutdownASync(delaySeconds, message);
                        pbRequestProgress.Style = ProgressBarStyle.Blocks;
                        pbRequestProgress.Value = 100;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error requesting server shutdown: {ex.Message}");
                        pbRequestProgress.Value = 0;
                        return;
                    }

                    MessageBox.Show("Server shutdown request acknowledged successfully.", "Shutdown Server Result");
                    txtShutdownMessage.Clear();
                    numSeconds.Value = 0;
                }
            }
            else
            {
                MessageBox.Show("Please enter delay in seconds and a message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
