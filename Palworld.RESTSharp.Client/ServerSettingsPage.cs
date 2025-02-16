using System.ComponentModel;

namespace Palworld.RESTSharp.Client
{
    public partial class ServerSettingsPage : UserControl
    {
        PalworldRESTSharpClient palAPIClient;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ServerSettings serverSettings { get; private set; }
        public ServerSettingsPage()
        {
            InitializeComponent();
        }

        public ServerSettingsPage(PalworldRESTSharpClient palAPIClient)
        {
            InitializeComponent();
            this.palAPIClient = palAPIClient;
        }

        private async void ServerSettingsPage_Load(object sender, EventArgs e)
        {
            await RefreshSettings();
        }

        private async Task RefreshSettings()
        {
            try
            {
                serverSettings = await palAPIClient.GetServerSettingsASync();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error getting server settings: {ex.Message}");
                return;
            }
            

            lbServerSettingsList.Items.Clear();

            lbServerSettingsList.Items.Add($"Difficulty:{serverSettings.Difficulty}");
            lbServerSettingsList.Items.Add($"Day Time Speed Rate:{serverSettings.DayTimeSpeedRate}");
            lbServerSettingsList.Items.Add($"Night Time Speed Rate:{serverSettings.NightTimeSpeedRate}");
            lbServerSettingsList.Items.Add($"Exp Rate:{serverSettings.ExpRate}");
            lbServerSettingsList.Items.Add($"Pal Capture Rate:{serverSettings.PalCaptureRate}");
            lbServerSettingsList.Items.Add($"Pal Spawn Num Rate:{serverSettings.PalSpawnNumRate}");
            lbServerSettingsList.Items.Add($"Pal Damage Rate Attack:{serverSettings.PalDamageRateAttack}");
            lbServerSettingsList.Items.Add($"Pal Damage Rate Defense:{serverSettings.PalDamageRateDefense}");
            lbServerSettingsList.Items.Add($"Player Damage Rate Attack:{serverSettings.PlayerDamageRateAttack}");
            lbServerSettingsList.Items.Add($"Player Damage Rate Defense:{serverSettings.PlayerDamageRateDefense}");
            lbServerSettingsList.Items.Add($"Player Stomach Decreace Rate:{serverSettings.PlayerStomachDecreaceRate}");
            lbServerSettingsList.Items.Add($"Player Stamina Decreace Rate:{serverSettings.PlayerStaminaDecreaceRate}");
            lbServerSettingsList.Items.Add($"Player Auto HP Regene Rate:{serverSettings.PlayerAutoHPRegeneRate}");
            lbServerSettingsList.Items.Add($"Player Auto Hp Regene Rate In Sleep:{serverSettings.PlayerAutoHpRegeneRateInSleep}");
            lbServerSettingsList.Items.Add($"Pal Stomach Decreace Rate:{serverSettings.PalStomachDecreaceRate}");
            lbServerSettingsList.Items.Add($"Pal Stamina Decreace Rate:{serverSettings.PalStaminaDecreaceRate}");
            lbServerSettingsList.Items.Add($"Pal Auto HP Regene Rate:{serverSettings.PalAutoHPRegeneRate}");
            lbServerSettingsList.Items.Add($"Pal Auto Hp Regene Rate In Sleep:{serverSettings.PalAutoHpRegeneRateInSleep}");
            lbServerSettingsList.Items.Add($"Build Object Damage Rate:{serverSettings.BuildObjectDamageRate}");
            lbServerSettingsList.Items.Add($"Build Object Deterioration Damage Rate:{serverSettings.BuildObjectDeteriorationDamageRate}");
            lbServerSettingsList.Items.Add($"Collection Drop Rate:{serverSettings.CollectionDropRate}");
            lbServerSettingsList.Items.Add($"Collection Object Hp Rate:{serverSettings.CollectionObjectHpRate}");
            lbServerSettingsList.Items.Add($"Collection Object Respawn Speed Rate:{serverSettings.CollectionObjectRespawnSpeedRate}");
            lbServerSettingsList.Items.Add($"Enemy Drop Item Rate:{serverSettings.EnemyDropItemRate}");
            lbServerSettingsList.Items.Add($"Death Penalty:{serverSettings.DeathPenalty}");
            lbServerSettingsList.Items.Add($"bEnablePlayerToPlayerDamage:{serverSettings.bEnablePlayerToPlayerDamage}");
            lbServerSettingsList.Items.Add($"bEnableFriendlyFire:{serverSettings.bEnableFriendlyFire}");
            lbServerSettingsList.Items.Add($"bEnableInvaderEnemy:{serverSettings.bEnableInvaderEnemy}");
            lbServerSettingsList.Items.Add($"bActiveUNKO:{serverSettings.bActiveUNKO}");
            lbServerSettingsList.Items.Add($"bEnableAimAssistPad:{serverSettings.bEnableAimAssistPad}");
            lbServerSettingsList.Items.Add($"bEnableAimAssistKeyboard:{serverSettings.bEnableAimAssistKeyboard}");
            lbServerSettingsList.Items.Add($"Drop Item Max Num:{serverSettings.DropItemMaxNum}");
            lbServerSettingsList.Items.Add($"Drop Item Max Num UNKO:{serverSettings.DropItemMaxNum_UNKO}");
            lbServerSettingsList.Items.Add($"Base Camp Max Num:{serverSettings.BaseCampMaxNum}");
            lbServerSettingsList.Items.Add($"Base Camp Worker Max Num:{serverSettings.BaseCampWorkerMaxNum}");
            lbServerSettingsList.Items.Add($"Drop Item Alive Max Hours:{serverSettings.DropItemAliveMaxHours}");
            lbServerSettingsList.Items.Add($"bAutoResetGuildNoOnlinePlayers:{serverSettings.bAutoResetGuildNoOnlinePlayers}");
            lbServerSettingsList.Items.Add($"Auto Reset Guild Time No Online Players:{serverSettings.AutoResetGuildTimeNoOnlinePlayers}");
            lbServerSettingsList.Items.Add($"Guild Player Max Num:{serverSettings.GuildPlayerMaxNum}");
            lbServerSettingsList.Items.Add($"Pal Egg Default Hatching Time:{serverSettings.PalEggDefaultHatchingTime}");
            lbServerSettingsList.Items.Add($"Work Speed Rate:{serverSettings.WorkSpeedRate}");
            lbServerSettingsList.Items.Add($"bIsMultiplay:{serverSettings.bIsMultiplay}");
            lbServerSettingsList.Items.Add($"bIsPvP:{serverSettings.bIsPvP}");
            lbServerSettingsList.Items.Add($"bCanPickupOtherGuildDeathPenaltyDrop:{serverSettings.bCanPickupOtherGuildDeathPenaltyDrop}");
            lbServerSettingsList.Items.Add($"bEnableNonLoginPenalty:{serverSettings.bEnableNonLoginPenalty}");
            lbServerSettingsList.Items.Add($"bEnableFastTravel:{serverSettings.bEnableFastTravel}");
            lbServerSettingsList.Items.Add($"bIsStartLocationSelectByMap:{serverSettings.bIsStartLocationSelectByMap}");
            lbServerSettingsList.Items.Add($"bExistPlayerAfterLogout:{serverSettings.bExistPlayerAfterLogout}");
            lbServerSettingsList.Items.Add($"bEnableDefenseOtherGuildPlayer:{serverSettings.bEnableDefenseOtherGuildPlayer}");
            lbServerSettingsList.Items.Add($"Coop Player Max Num:{serverSettings.CoopPlayerMaxNum}");
            lbServerSettingsList.Items.Add($"Server Player Max Num:{serverSettings.ServerPlayerMaxNum}");
            lbServerSettingsList.Items.Add($"Server Name:{serverSettings.ServerName}");
            lbServerSettingsList.Items.Add($"Server Description:{serverSettings.ServerDescription}");
            lbServerSettingsList.Items.Add($"Public Port:{serverSettings.PublicPort}");
            lbServerSettingsList.Items.Add($"Public IP:{serverSettings.PublicIP}");
            lbServerSettingsList.Items.Add($"RCON Enabled:{serverSettings.RCONEnabled}");
            lbServerSettingsList.Items.Add($"RCON Port:{serverSettings.RCONPort}");
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshSettings();
        }

        private void btnExportToCSV_Click(object sender, EventArgs e)
        {
            // Export items in the lisrbox to a CSV file
            string csv = "SettingName,SettingValue";

            foreach (var item in lbServerSettingsList.Items)
            {
                string[] lineItems = item.ToString().Split(':');
                //string lineItem = $"{lineItem[0]},{lineItem[1]}";
                csv += $"{lineItems[0]},{lineItems[1]}\n";
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            saveFileDialog.Title = "Save Server Settings to CSV";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, csv);
            }

        }
    }
}
