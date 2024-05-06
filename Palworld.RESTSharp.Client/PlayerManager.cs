using Palworld.RESTSharp.ProxyServer;

namespace Palworld.RESTSharp.Client
{
    public partial class PlayerManager : UserControl
    {
        private readonly PalworldRESTSharpClient palAPIClient;
        private Player[] playerList;
        public PlayerManager()
        {
            InitializeComponent();
        }

        public PlayerManager(PalworldRESTSharpClient client)
        {
            palAPIClient = client;
            InitializeComponent();
        }

        private async void RefreshPlayerList()
        {
            Players players = await palAPIClient.GetPlayersASync();
            playerList = players.players;
            dgUserList.DataSource = playerList;
            dgUserList.Columns["userid"].HeaderText = "SteamID";
            dgUserList.Columns.Remove("playerid");
            if (palAPIClient.UsingProxy && palAPIClient.ProxyServer.ProxyUser.Role == UserAccessLevel.Moderator)
            {
                dgUserList.Columns.Remove("ip");
            }
        }

        private void PlayerManager_Load(object sender, EventArgs e)
        {
            RefreshPlayerList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshPlayerList();
        }

        private void dgUserList_ContentClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip userContextMenu = new ContextMenuStrip();
                userContextMenu.Items.Add("Warn Player", null, WarnPlayer);
                userContextMenu.Items.Add("Kick Player", null, KickPlayer);
                userContextMenu.Items.Add("Ban Player", null, BanPlayer);
                userContextMenu.Items.Add("-");
                userContextMenu.Items.Add("Copy SteamID", null, CopySteamID);
                userContextMenu.Items.Add("Copy TeleportToMe Command", null, CopyTeleportToMe);
                userContextMenu.Items.Add("Copy TeleportToPlayer Command", null, CopyTeleportToPlayer);

                int currMouseRow = dgUserList.HitTest(e.X, e.Y).RowIndex;

                userContextMenu.Show(dgUserList, new Point(e.X, e.Y));
            }
        }

        private void CopyTeleportToMe(object sender, EventArgs e)
        {
            string userID = GetSelectedUserID();
            Clipboard.SetText($"/TeleportToMe {GetSelectedUserID()}");
        }
        private void CopyTeleportToPlayer(object sender, EventArgs e)
        {
            string userID = GetSelectedUserID();
            Clipboard.SetText($"/TeleportToPlayer {GetSelectedUserID()}");
        }

        private void CopySteamID(object sender, EventArgs e)
        {
            Clipboard.SetText(GetSelectedUserID());
        }

        private async void KickPlayer(object sender, EventArgs e)
        {
            string userID = GetSelectedUserID();
            if (string.IsNullOrEmpty(txtBanReason.Text)) txtBanReason.Text = "Unspecified reason.";

            await palAPIClient.BroadcastMessageASync($"{GetSelectedUserName()} has been kicked by {GetExecutingUser()}. Reason: {txtBanReason.Text}");
            await palAPIClient.KickPlayerASync(userID, txtBanReason.Text);
            MessageBox.Show($"Player has been kicked.", "Player Kicked", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtBanReason.Clear();
            RefreshPlayerList();
        }

        private async void BanPlayer(object sender, EventArgs e)
        {
            string userID = GetSelectedUserID();
            if (string.IsNullOrEmpty(txtBanReason.Text)) txtBanReason.Text = "Unspecified reason.";
            await palAPIClient.BroadcastMessageASync($"{GetSelectedUserName()} has been banned by {GetExecutingUser()}. Reason: {txtBanReason.Text}");
            await palAPIClient.BanPlayerASync(userID, txtBanReason.Text);
            MessageBox.Show($"Player has been banned.", "Player Banned", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtBanReason.Clear();
            RefreshPlayerList();
        }

        private async void WarnPlayer(object sender, EventArgs e)
        {
            await palAPIClient.BroadcastMessageASync($"{GetSelectedUserName()} has been warned by {GetExecutingUser()}.");
        }

        private string GetExecutingUser() => palAPIClient.UsingProxy ? palAPIClient.ProxyServer.ProxyUser.Username : "SYSTEM";

        private string GetSelectedUserID() => dgUserList.SelectedRows[0].Cells["userid"].Value.ToString();
        private string GetSelectedUserName() => dgUserList.SelectedRows[0].Cells["PlayerName"].Value.ToString();

        private async void btnKick_Click(object sender, EventArgs e) => KickPlayer(sender, e);

        private async void btnBan_Click(object sender, EventArgs e) => BanPlayer(sender, e);
    }
}
