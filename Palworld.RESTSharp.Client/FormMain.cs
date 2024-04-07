namespace Palworld.RESTSharp.Client
{
    public partial class FormMain : Form
    {
        string selectedPage;
        string apiURL;
        string apiPassword;
        bool _connected;
        const string _defaultTitle = "Palworld REST Client";
        PalworldRESTSharpClient palworldRESTAPIClient;
        Players players;

        // Re-used controls
        TextBox txtBroadcastMessage;
        TextBox txtReasonMessage;
        TextBox txtUnbanPlayerID;
        TextBox txtResponse;
        ServerInfo serverInfo;

        ComboBox comboUserList;
        Label lblplayerName;
        Label lblReason;
        NumericUpDown shutdownDelay;
        ContextMenuStrip userContextMenu;
        DataGridViewCell selectedUserCell;
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            btnExecute.Enabled = false;
            SetupNavigationTree();
            txtResponse = new TextBox();
            tAPIOptions.Visible = false;

            ToolStripMenuItem itemKick = new ToolStripMenuItem("Kick Player");
            ToolStripMenuItem itemBan = new ToolStripMenuItem("Ban Player");
            ToolStripMenuItem itemcopyID = new ToolStripMenuItem("Copy Selected Value");

            userContextMenu = new ContextMenuStrip();
            userContextMenu.Items.AddRange(new ToolStripItem[] { itemKick, itemBan, itemcopyID });

            itemcopyID.Click += new EventHandler(CopyIDClick);
            itemBan.Click += new EventHandler(BanPlayerClick);
            itemKick.Click += new EventHandler(KickPlayerClick);
        }

        private void CopyIDClick(object sender, EventArgs e)
        {
            if (selectedUserCell != null)
            {
                string idToCopy = selectedUserCell.Value.ToString();
                Clipboard.SetText(idToCopy);
            }
        }

        private void KickPlayerClick(object sender, EventArgs e)
        {

        }

        private void BanPlayerClick(object sender, EventArgs e)
        {

        }

        private void SetupNavigationTree()
        {
            TreeNode configureNode = new TreeNode("Client Configuration");
            tAPIOptions.Nodes.Add(configureNode);

            TreeNode ServerManagement = new TreeNode("Server Management");
            TreeNode broadcastMessage = new TreeNode("Broadcast Message");
            TreeNode HomeGetInfoNode = new TreeNode("Get Server Info");
            TreeNode getServerMetrics = new TreeNode("Get Server Metrics");
            TreeNode getServerSettings = new TreeNode("Get Server Settings");
            TreeNode saveWorld = new TreeNode("Save World");
            TreeNode Shutdown = new TreeNode("Shutdown Server");
            TreeNode StopServer = new TreeNode("Stop Server");
            tAPIOptions.Nodes.Add(ServerManagement);
            ServerManagement.Nodes.Add(broadcastMessage);
            ServerManagement.Nodes.Add(HomeGetInfoNode);
            ServerManagement.Nodes.Add(getServerSettings);
            ServerManagement.Nodes.Add(getServerMetrics);
            ServerManagement.Nodes.Add(saveWorld);
            ServerManagement.Nodes.Add(Shutdown);
            ServerManagement.Nodes.Add(StopServer);

            TreeNode PlayerManagement = new TreeNode("Player Management");
            TreeNode getPlayers = new TreeNode("Get Players");
            TreeNode kickPlayer = new TreeNode("Kick Player");
            TreeNode banPlayer = new TreeNode("Ban Player");
            TreeNode unBanPlayer = new TreeNode("Unban Player");
            PlayerManagement.Nodes.Add(getPlayers);
            PlayerManagement.Nodes.Add(kickPlayer);
            PlayerManagement.Nodes.Add(banPlayer);
            PlayerManagement.Nodes.Add(unBanPlayer);

            tAPIOptions.Nodes.Add(PlayerManagement);
            tAPIOptions.ExpandAll();
        }

        private void tAPIOptions_AfterSelectAsync(object sender, TreeViewEventArgs e)
        {
            pageConfigure.Visible = false;
            panelRequestParameters.Controls.Clear();
            selectedPage = e.Node.Text;
            lblHeader.Text = selectedPage;

            switch (selectedPage)
            {
                case "Client Configuration":
                    pageConfigure.Visible = true;
                    break;
                case "Get Server Info":
                    break;
                case "Get Players":
                    break;
                case "Broadcast Message":
                    Label lblBroadcastMessage = new Label();
                    lblBroadcastMessage.Text = "Message";
                    lblBroadcastMessage.Dock = DockStyle.Top;
                    txtBroadcastMessage = new TextBox();
                    txtBroadcastMessage.Dock = DockStyle.Fill;
                    txtBroadcastMessage.Multiline = true;
                    txtBroadcastMessage.PlaceholderText = "Enter message to broadcast";

                    panelRequestParameters.Controls.Add(txtBroadcastMessage);
                    panelRequestParameters.Controls.Add(lblBroadcastMessage);
                    break;

                case "Kick Player":

                    if (players == null)
                    {
                        MessageBox.Show("You must get players first.", "Must Select Players");
                        return;
                    }
                    lblplayerName = new Label() { Text = "Reason" };
                    lblReason = new Label() { Text = "Player Name" };
                    txtReasonMessage = new TextBox();
                    txtReasonMessage.PlaceholderText = "Enter reason for kick";

                    comboUserList.DropDownStyle = ComboBoxStyle.DropDownList;

                    txtReasonMessage.Dock = DockStyle.Top;
                    panelRequestParameters.Controls.Add(txtReasonMessage);

                    lblplayerName.Dock = DockStyle.Top;
                    panelRequestParameters.Controls.Add(lblplayerName);

                    comboUserList.Dock = DockStyle.Top;
                    panelRequestParameters.Controls.Add(comboUserList);

                    lblReason.Dock = DockStyle.Top;
                    panelRequestParameters.Controls.Add(lblReason);

                    break;
                case "Ban Player":

                    if (players == null)
                    {
                        MessageBox.Show("You must get players first.", "Must Select Players");
                        return;
                    }

                    lblplayerName = new Label() { Text = "Reason" };
                    lblReason = new Label() { Text = "Player Name" };

                    comboUserList.DropDownStyle = ComboBoxStyle.DropDownList;
                    txtReasonMessage = new TextBox();
                    txtReasonMessage.Dock = DockStyle.Top;
                    txtReasonMessage.PlaceholderText = "Enter reason for ban";
                    panelRequestParameters.Controls.Add(txtReasonMessage);

                    lblplayerName.Dock = DockStyle.Top;
                    panelRequestParameters.Controls.Add(lblplayerName);

                    comboUserList.Dock = DockStyle.Top;
                    panelRequestParameters.Controls.Add(comboUserList);

                    lblReason.Dock = DockStyle.Top;
                    panelRequestParameters.Controls.Add(lblReason);

                    break;

                case "Unban Player":
                    lblplayerName = new Label() { Text = "Player ID" };
                    txtUnbanPlayerID = new TextBox();
                    txtUnbanPlayerID.PlaceholderText = "steam_xxxxxxxxxxxxx";

                    txtUnbanPlayerID.Dock = DockStyle.Top;
                    panelRequestParameters.Controls.Add(txtUnbanPlayerID);

                    lblplayerName.Dock = DockStyle.Top;
                    panelRequestParameters.Controls.Add(lblplayerName);
                    break;
                case "Shutdown Server":
                    txtReasonMessage = new TextBox();
                    lblReason = new Label() { Text = "Shutdown Message" };
                    Label lblDelay = new Label() { Text = "Delay (Seconds)" };
                    
                    txtReasonMessage.Dock = DockStyle.Top;
                    txtReasonMessage.PlaceholderText = "Enter reason for shutdown";
                    panelRequestParameters.Controls.Add(txtReasonMessage);

                    lblReason.Dock = DockStyle.Top;
                    panelRequestParameters.Controls.Add(lblReason);

                    shutdownDelay = new NumericUpDown();
                    shutdownDelay.Dock = DockStyle.Top;
                    shutdownDelay.Minimum = 1;
                    panelRequestParameters.Controls.Add(shutdownDelay);

                    panelRequestParameters.Controls.Add(lblDelay);
                    lblDelay.Dock = DockStyle.Top;

                    break;
            }
        }
        private void pageConfigure_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DataGridview1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) // Check if it's not a header cell
            {
                DataGridView dgv = sender as DataGridView;
                if (dgv != null && dgv.Columns[e.ColumnIndex] is DataGridViewColumn && e.RowIndex >= 0)
                {
                    DataGridViewCell cell = dgv[e.ColumnIndex, e.RowIndex];
                    if (cell != null && cell.ContentBounds.Contains(dgv.PointToClient(Cursor.Position)))
                    {
                        if (MouseButtons.Right == Control.MouseButtons)
                        {
                            userContextMenu.Show(Cursor.Position);
                        }
                    }
                }
            }
        }

        private async void btnSaveConfig_Click(object sender, EventArgs e)
        {
            if (!_connected)
            {
                if (txtconfigURL.Text == "" || txtConfigPassword.Text == "")
                {
                    MessageBox.Show("URL and Password required.");
                    return;
                }
                
                txtconfigURL.ReadOnly = true;
                txtConfigPassword.ReadOnly = true;
                tAPIOptions.Visible = true;
                apiURL = txtconfigURL.Text;
                apiPassword = txtConfigPassword.Text;
                palworldRESTAPIClient = new PalworldRESTSharpClient(apiURL, apiPassword);
                btnExecute.Enabled = true;
                btnSaveConfig.Text = "Disconnect";
                connectionStatus.Text = "Connected.";

                serverInfo = await palworldRESTAPIClient.GetServerInfoASync();

                _connected = true;
                this.Text = _defaultTitle + $" - {serverInfo.serverName}";

            }
            else
            {
                txtconfigURL.ReadOnly = false;
                txtConfigPassword.ReadOnly = false;
                tAPIOptions.Visible = false;
                connectionStatus.Text = "Disconnected.";
                btnSaveConfig.Text = "Connect";
                _connected = false;

                this.Text = _defaultTitle;
            }
            
        }

        private async void Execute()
        {
            try
            {
                panelResponse.Controls.Clear();
                switch (selectedPage)
                {
                    case "Client Configuration":
                        MessageBox.Show("Configuration Applied.");
                        break;
                    case "Get Server Info":
                        if (serverInfo != null)
                        {
                            ListBox lblServerInfo = new ListBox();
                            lblServerInfo.Dock = DockStyle.Fill;
                            lblServerInfo.Items.Add($"Name: {serverInfo.serverName}");
                            lblServerInfo.Items.Add($"Version: {serverInfo.version}");
                            lblServerInfo.Items.Add($"Description: {serverInfo.description}");

                            panelResponse.Controls.Add(lblServerInfo);
                        }

                        break;
                    case "Get Players":
                        players = await palworldRESTAPIClient.GetPlayersASync();

                        if (players != null)
                        {
                            DataGridView dgvPlayers = new DataGridView();
                            dgvPlayers.Dock = DockStyle.Fill;
                            dgvPlayers.ReadOnly = true;
                            dgvPlayers.AutoGenerateColumns = true;
                            dgvPlayers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvPlayers.DataSource = players.players;
                            dgvPlayers.MultiSelect = false;
                            dgvPlayers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dgvPlayers.CellContextMenuStripNeeded += (s, e) =>
                            {
                                if (e.RowIndex != -1 && e.ColumnIndex >= 0)
                                {
                                    selectedUserCell = dgvPlayers[e.ColumnIndex, e.RowIndex];
                                    dgvPlayers.Rows[e.RowIndex].Selected = true;
                                    e.ContextMenuStrip = userContextMenu;
                                }
                            };
                            dgvPlayers.CellContentClick += DataGridview1_CellContentClick;
                            panelResponse.Controls.Add(dgvPlayers);

                            // Create and populate combo box from the user list.
                            comboUserList = new ComboBox();
                            comboUserList.DataSource = players.players;
                            comboUserList.DisplayMember = "name";
                            comboUserList.ValueMember = "steamID";

                        }

                        break;
                    case "Get Server Metrics":
                        ServerMetric serverMetric = await palworldRESTAPIClient.GetServerMetricsASync();

                        if (serverMetric != null)
                        {
                            // Best way to show fields from class in a list box.
                            ListBox lbServerMetrics = new ListBox();
                            lbServerMetrics.Dock = DockStyle.Fill;
                            lbServerMetrics.Items.Add($"FPS: {serverMetric.serverFPS}");
                            lbServerMetrics.Items.Add($"Total Players: {serverMetric.totalPlayers}");
                            lbServerMetrics.Items.Add($"Frame Rate: {serverMetric.serverFrameRate}");
                            lbServerMetrics.Items.Add($"Max Players: {serverMetric.maxPlayers}");
                            lbServerMetrics.Items.Add($"Uptime: {serverMetric.upTime}");
                            panelResponse.Controls.Add(lbServerMetrics);
                        }

                        break;
                    case "Kick Player":

                        await palworldRESTAPIClient.KickPlayerASync(comboUserList.SelectedValue.ToString(), txtReasonMessage.Text);

                        txtResponse.ReadOnly = true;
                        txtResponse.Dock = DockStyle.Fill;
                        txtResponse.Text = "Player kicked.";
                        panelResponse.Controls.Add(txtResponse);

                        break;
                    case "Ban Player":
                        await palworldRESTAPIClient.BanPlayerASync(comboUserList.SelectedValue.ToString(), txtReasonMessage.Text);

                        txtResponse.ReadOnly = true;
                        txtResponse.Dock = DockStyle.Fill;
                        txtResponse.Text = "Player banned.";
                        panelResponse.Controls.Add(txtResponse);

                        break;
                    case "Unban Player":

                        await palworldRESTAPIClient.UnbanPlayerASync(txtUnbanPlayerID.Text);
                        txtResponse.ReadOnly = true;
                        txtResponse.Dock = DockStyle.Fill;
                        txtResponse.Text = "Player unbanned.";
                        panelResponse.Controls.Add(txtResponse);

                        break;
                    case "Get Server Settings":
                        ServerSettings serverSettings = await palworldRESTAPIClient.GetServerSettingsASync();

                        if (serverSettings != null)
                        {
                            ListBox lbServerSettings = new ListBox();

                            lbServerSettings.Dock = DockStyle.Fill;

                            lbServerSettings.Items.Add($"Difficulty: {serverSettings.Difficulty}");
                            lbServerSettings.Items.Add($"Day Time Speed Rate: {serverSettings.DayTimeSpeedRate}");
                            lbServerSettings.Items.Add($"Night Time Speed Rate: {serverSettings.NightTimeSpeedRate}");
                            lbServerSettings.Items.Add($"Exp Rate: {serverSettings.ExpRate}");
                            lbServerSettings.Items.Add($"Pal Capture Rate: {serverSettings.PalCaptureRate}");
                            lbServerSettings.Items.Add($"Pal Spawn Num Rate: {serverSettings.PalSpawnNumRate}");
                            lbServerSettings.Items.Add($"Pal Damage Rate Attack: {serverSettings.PalDamageRateAttack}");
                            lbServerSettings.Items.Add($"Pal Damage Rate Defense: {serverSettings.PalDamageRateDefense}");
                            lbServerSettings.Items.Add($"Player Damage Rate Attack: {serverSettings.PlayerDamageRateAttack}");
                            lbServerSettings.Items.Add($"Player Damage Rate Defense: {serverSettings.PlayerDamageRateDefense}");
                            lbServerSettings.Items.Add($"Player Stomach Decreace Rate: {serverSettings.PlayerStomachDecreaceRate}");
                            lbServerSettings.Items.Add($"Player Stamina Decreace Rate: {serverSettings.PlayerStaminaDecreaceRate}");
                            lbServerSettings.Items.Add($"Player Auto HP Regene Rate: {serverSettings.PlayerAutoHPRegeneRate}");
                            lbServerSettings.Items.Add($"Player Auto Hp Regene Rate In Sleep: {serverSettings.PlayerAutoHpRegeneRateInSleep}");
                            lbServerSettings.Items.Add($"Pal Stomach Decreace Rate: {serverSettings.PalStomachDecreaceRate}");
                            lbServerSettings.Items.Add($"Pal Stamina Decreace Rate: {serverSettings.PalStaminaDecreaceRate}");
                            lbServerSettings.Items.Add($"Pal Auto HP Regene Rate: {serverSettings.PalAutoHPRegeneRate}");
                            lbServerSettings.Items.Add($"Pal Auto Hp Regene Rate In Sleep: {serverSettings.PalAutoHpRegeneRateInSleep}");
                            lbServerSettings.Items.Add($"Build Object Damage Rate: {serverSettings.BuildObjectDamageRate}");
                            lbServerSettings.Items.Add($"Build Object Deterioration Damage Rate: {serverSettings.BuildObjectDeteriorationDamageRate}");
                            lbServerSettings.Items.Add($"Collection Drop Rate: {serverSettings.CollectionDropRate}");
                            lbServerSettings.Items.Add($"Collection Object Hp Rate: {serverSettings.CollectionObjectHpRate}");
                            lbServerSettings.Items.Add($"Collection Object Respawn Speed Rate: {serverSettings.CollectionObjectRespawnSpeedRate}");
                            lbServerSettings.Items.Add($"Enemy Drop Item Rate: {serverSettings.EnemyDropItemRate}");
                            lbServerSettings.Items.Add($"Death Penalty: {serverSettings.DeathPenalty}");
                            lbServerSettings.Items.Add($"bEnablePlayerToPlayerDamage: {serverSettings.bEnablePlayerToPlayerDamage}");
                            lbServerSettings.Items.Add($"bEnableFriendlyFire: {serverSettings.bEnableFriendlyFire}");
                            lbServerSettings.Items.Add($"bEnableInvaderEnemy: {serverSettings.bEnableInvaderEnemy}");
                            lbServerSettings.Items.Add($"bActiveUNKO: {serverSettings.bActiveUNKO}");
                            lbServerSettings.Items.Add($"bEnableAimAssistPad: {serverSettings.bEnableAimAssistPad}");
                            lbServerSettings.Items.Add($"bEnableAimAssistKeyboard: {serverSettings.bEnableAimAssistKeyboard}");
                            lbServerSettings.Items.Add($"Drop Item Max Num: {serverSettings.DropItemMaxNum}");
                            lbServerSettings.Items.Add($"Drop Item Max Num UNKO: {serverSettings.DropItemMaxNum_UNKO}");
                            lbServerSettings.Items.Add($"Base Camp Max Num: {serverSettings.BaseCampMaxNum}");
                            lbServerSettings.Items.Add($"Base Camp Worker Max Num: {serverSettings.BaseCampWorkerMaxNum}");
                            lbServerSettings.Items.Add($"Drop Item Alive Max Hours: {serverSettings.DropItemAliveMaxHours}");
                            lbServerSettings.Items.Add($"bAutoResetGuildNoOnlinePlayers: {serverSettings.bAutoResetGuildNoOnlinePlayers}");
                            lbServerSettings.Items.Add($"Auto Reset Guild Time No Online Players: {serverSettings.AutoResetGuildTimeNoOnlinePlayers}");
                            lbServerSettings.Items.Add($"Guild Player Max Num: {serverSettings.GuildPlayerMaxNum}");
                            lbServerSettings.Items.Add($"Pal Egg Default Hatching Time: {serverSettings.PalEggDefaultHatchingTime}");
                            lbServerSettings.Items.Add($"Work Speed Rate: {serverSettings.WorkSpeedRate}");
                            lbServerSettings.Items.Add($"bIsMultiplay: {serverSettings.bIsMultiplay}");
                            lbServerSettings.Items.Add($"bIsPvP: {serverSettings.bIsPvP}");
                            lbServerSettings.Items.Add($"bCanPickupOtherGuildDeathPenaltyDrop: {serverSettings.bCanPickupOtherGuildDeathPenaltyDrop}");
                            lbServerSettings.Items.Add($"bEnableNonLoginPenalty: {serverSettings.bEnableNonLoginPenalty}");
                            lbServerSettings.Items.Add($"bEnableFastTravel: {serverSettings.bEnableFastTravel}");
                            lbServerSettings.Items.Add($"bIsStartLocationSelectByMap: {serverSettings.bIsStartLocationSelectByMap}");
                            lbServerSettings.Items.Add($"bExistPlayerAfterLogout: {serverSettings.bExistPlayerAfterLogout}");
                            lbServerSettings.Items.Add($"bEnableDefenseOtherGuildPlayer: {serverSettings.bEnableDefenseOtherGuildPlayer}");
                            lbServerSettings.Items.Add($"Coop Player Max Num: {serverSettings.CoopPlayerMaxNum}");
                            lbServerSettings.Items.Add($"Server Player Max Num: {serverSettings.ServerPlayerMaxNum}");
                            lbServerSettings.Items.Add($"Server Name: {serverSettings.ServerName}");
                            lbServerSettings.Items.Add($"Server Description: {serverSettings.ServerDescription}");
                            lbServerSettings.Items.Add($"Public Port: {serverSettings.PublicPort}");
                            lbServerSettings.Items.Add($"Public IP: {serverSettings.PublicIP}");
                            lbServerSettings.Items.Add($"RCON Enabled: {serverSettings.RCONEnabled}");
                            lbServerSettings.Items.Add($"RCON Port: {serverSettings.RCONPort}");
                            panelResponse.Controls.Add(lbServerSettings);

                        }
                        break;
                    case "Save World":

                        await palworldRESTAPIClient.SaveWorldASync();
                        TextBox textBox2 = new TextBox();
                        textBox2.ReadOnly = true;
                        textBox2.Dock = DockStyle.Fill;
                        textBox2.Text = "World Saved.";
                        panelResponse.Controls.Add(textBox2);
                        break;
                    case "Broadcast Message":

                        await palworldRESTAPIClient.BroadcastMessageASync(txtBroadcastMessage.Text);

                        TextBox tbBroadcastMessage = new TextBox();
                        tbBroadcastMessage.ReadOnly = true;
                        tbBroadcastMessage.Dock = DockStyle.Fill;
                        tbBroadcastMessage.Text = "Message Broadcasted.";
                        panelResponse.Controls.Add(tbBroadcastMessage);
                        break;
                    case "Shutdown Server":

                        await palworldRESTAPIClient.ShutdownASync((int)shutdownDelay.Value, txtReasonMessage.Text);

                        txtResponse.ReadOnly = true;
                        txtResponse.Dock = DockStyle.Fill;
                        txtResponse.Text = "Server shutdown sequence initiated.";
                        panelResponse.Controls.Add(txtResponse);
                        break;
                    case "Stop Server":
                        txtResponse.ReadOnly = true;
                        txtResponse.Dock = DockStyle.Fill;
                        txtResponse.Text = "Server Stop acknowledged.";
                        panelResponse.Controls.Add(txtResponse);
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\nException:\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnExecute_Click(object sender, EventArgs e)
        {
            Execute();

            connectionStatus.Text = "Executed";
        }
    }
}
