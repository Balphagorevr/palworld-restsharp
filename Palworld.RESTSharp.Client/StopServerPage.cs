using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palworld.RESTSharp.Client
{
    public partial class StopServerPage : UserControl
    {
        public PalworldRESTSharpClient palAPIClient;
        public StopServerPage()
        {
            InitializeComponent();
        }

        public StopServerPage(PalworldRESTSharpClient palAPIClient)
        {
            InitializeComponent();
            this.palAPIClient = palAPIClient;
        }

        private async void btnStopServer_Click(object sender, EventArgs e)
        {
            // Get confirmation user wants to stop the server.
            DialogResult result = MessageBox.Show("Are you sure you want to stop the server?", "Stop Server", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    pbRequestProgress.Style = ProgressBarStyle.Marquee;
                    await palAPIClient.StopServerASync();
                    pbRequestProgress.Style = ProgressBarStyle.Blocks;
                    pbRequestProgress.Value = 100;
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Error Stopping Server: {ex.Message}");
                    pbRequestProgress.Value = 0;
                    return;
                }
            MessageBox.Show("Server stop request acknowledged successfully.", "Stop Server Result");
            }
        }

        private void StopServerPage_Load(object sender, EventArgs e)
        {

        }
    }
}
