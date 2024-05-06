namespace Palworld.RESTSharp.Client
{
    public partial class SaveWorldPage : UserControl
    {
        private PalworldRESTSharpClient palAPIClient;

        public SaveWorldPage()
        {
            InitializeComponent();
        }

        public SaveWorldPage(PalworldRESTSharpClient palAPIClient)
        {
            InitializeComponent();
            this.palAPIClient = palAPIClient;
        }

        private async void btnSaveWorld_Click(object sender, EventArgs e)
        {
            try
            {
                pbRequestProgress.Style = ProgressBarStyle.Marquee;
                await palAPIClient.SaveWorldASync();
                pbRequestProgress.Style = ProgressBarStyle.Blocks;
                pbRequestProgress.Value = 100;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error requesting world save: {ex.Message}");
                pbRequestProgress.Value = 0;
                return;
            }

            MessageBox.Show("World saved successfully", "Save Result");
        }

        private void SaveWorldPage_Load(object sender, EventArgs e)
        {

        }

        private void pbSaveProgress_Click(object sender, EventArgs e)
        {

        }
    }
}
