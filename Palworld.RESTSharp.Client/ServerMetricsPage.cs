namespace Palworld.RESTSharp.Client
{
    public partial class ServerMetricsPage : UserControl
    {
        PalworldRESTSharpClient palAPIClient;

        public event EventHandler onMetricsRefreshed;

        public ServerMetric metrics { get; private set; }
        public ServerMetricsPage()
        {
            InitializeComponent();
        }

        public ServerMetricsPage(PalworldRESTSharpClient palAPIClient)
        {
            InitializeComponent();
            this.palAPIClient = palAPIClient;
            
        }

        private async void ServerMetricsPage_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            try {
                await RefreshMetrics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Getting Metrics: {ex.Message}");
                return;
            }

        }

        private async Task RefreshMetrics()
        {
            try
            {
                metrics = await palAPIClient.GetServerMetricsASync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error requesting server metrics: {ex.Message}");
                return;
            }

            lbMetricsList.Items.Clear();
            lbMetricsList.Items.Add($"FPS: {metrics.ServerFPS}");
            lbMetricsList.Items.Add($"Total Players: {metrics.CurrentPlayers}");
            lbMetricsList.Items.Add($"Frame Rate: {metrics.ServerFrameTime}");
            lbMetricsList.Items.Add($"Max Players: {metrics.MaxPlayers}");
            lbMetricsList.Items.Add($"Uptime: {metrics.Uptime}");

            if (this.onMetricsRefreshed != null)
            {
                this.onMetricsRefreshed(this, new EventArgs());
            }
        }
    }
}
