using Newtonsoft.Json;

namespace Palworld.RESTSharp
{
    /// <summary>
    /// Represents the server settings object returned from API.
    /// </summary>
    public class ServerSettings
    {
        [JsonProperty("Difficulty")]
        /// <summary>
        /// Represents the difficulty level of the server.
        /// </summary>
        public string Difficulty { get; set; }

        [JsonProperty("DayTimeSpeedRate")]
        /// <summary>
        /// Represents the rate at which the daytime progresses.
        /// </summary>
        public float DayTimeSpeedRate { get; set; }

        [JsonProperty("NightTimeSpeedRate")]
        /// <summary>
        /// Represents the rate at which the nighttime progresses.
        /// </summary>
        public float NightTimeSpeedRate { get; set; }

        [JsonProperty("ExpRate")]
        /// <summary>
        /// Represents the rate at which players gain experience.
        /// </summary>
        public float ExpRate { get; set; }

        [JsonProperty("PalCaptureRate")]
        /// <summary>
        /// Represents the rate at which players can capture Pals.
        /// </summary>
        public float PalCaptureRate { get; set; }

        [JsonProperty("PalSpawnNumRate")]
        /// <summary>
        /// Represents the rate at which Pals spawn in the world.
        /// </summary>
        public float PalSpawnNumRate { get; set; }

        [JsonProperty("PalDamageRateAttack")]
        /// <summary>
        /// Represents the rate at which Pals deal damage when attacking.
        /// </summary>
        public float PalDamageRateAttack { get; set; }

        [JsonProperty("PalDamageRateDefense")]
        /// <summary>
        /// Represents the rate at which Pals receive damage when defending.
        /// </summary>
        public float PalDamageRateDefense { get; set; }

        [JsonProperty("PlayerDamageRateAttack")]
        /// <summary>
        /// Represents the rate at which players deal damage when attacking.
        /// </summary>
        public float PlayerDamageRateAttack { get; set; }

        [JsonProperty("PlayerDamageRateDefense")]
        /// <summary>
        /// Represents the rate at which players receive damage when defending.
        /// </summary>
        public float PlayerDamageRateDefense { get; set; }

        [JsonProperty("PlayerStomachDecreaceRate")]
        /// <summary>
        /// Represents the rate at which players' stomach decreases.
        /// </summary>
        public float PlayerStomachDecreaceRate { get; set; }

        [JsonProperty("PlayerStaminaDecreaceRate")]
        /// <summary>
        /// Represents the rate at which players' stamina decreases.
        /// </summary>
        public float PlayerStaminaDecreaceRate { get; set; }

        [JsonProperty("PlayerAutoHPRegeneRate")]
        /// <summary>
        /// Represents the rate at which players' HP regenerates automatically.
        /// </summary>
        public float PlayerAutoHPRegeneRate { get; set; }

        [JsonProperty("PlayerAutoHpRegeneRateInSleep")]
        /// <summary>
        /// Represents the rate at which players' HP regenerates automatically while sleeping.
        /// </summary>
        public float PlayerAutoHpRegeneRateInSleep { get; set; }

        [JsonProperty("PalStomachDecreaceRate")]
        /// <summary>
        /// Represents the rate at which Pals' stomach decreases.
        /// </summary>
        public float PalStomachDecreaceRate { get; set; }

        [JsonProperty("PalStaminaDecreaceRate")]
        /// <summary>
        /// Represents the rate at which Pals' stamina decreases.
        /// </summary>
        public float PalStaminaDecreaceRate { get; set; }

        [JsonProperty("PalAutoHPRegeneRate")]
        /// <summary>
        /// Represents the rate at which Pals' HP regenerates automatically.
        /// </summary>
        public float PalAutoHPRegeneRate { get; set; }

        [JsonProperty("PalAutoHpRegeneRateInSleep")]
        /// <summary>
        /// Represents the rate at which Pals' HP regenerates automatically while sleeping.
        /// </summary>
        public float PalAutoHpRegeneRateInSleep { get; set; }

        [JsonProperty("BuildObjectDamageRate")]
        /// <summary>
        /// Represents the rate at which build objects receive damage.
        /// </summary>
        public float BuildObjectDamageRate { get; set; }

        [JsonProperty("BuildObjectDeteriorationDamageRate")]
        /// <summary>
        /// Represents the rate at which build objects deteriorate.
        /// </summary>
        public float BuildObjectDeteriorationDamageRate { get; set; }

        [JsonProperty("CollectionDropRate")]
        /// <summary>
        /// Represents the rate at which collection items drop.
        /// </summary>
        public float CollectionDropRate { get; set; }

        [JsonProperty("CollectionObjectHpRate")]
        /// <summary>
        /// Represents the rate at which collection objects' HP decreases.
        /// </summary>
        public float CollectionObjectHpRate { get; set; }

        [JsonProperty("CollectionObjectRespawnSpeedRate")]
        /// <summary>
        /// Represents the rate at which collection objects respawn.
        /// </summary>
        public float CollectionObjectRespawnSpeedRate { get; set; }

        [JsonProperty("EnemyDropItemRate")]
        /// <summary>
        /// Represents the rate at which enemies drop items.
        /// </summary>
        public float EnemyDropItemRate { get; set; }

        [JsonProperty("DeathPenalty")]
        //[JsonConverter(typeof(Json))]
        /// <summary>
        /// Represents the death penalty options.
        /// </summary>
        public DeathPenalty DeathPenalty { get; set; }

        [JsonProperty("bEnablePlayerToPlayerDamage")]
        /// <summary>
        /// Represents whether player-to-player damage is enabled.
        /// </summary>
        public bool bEnablePlayerToPlayerDamage { get; set; }

        [JsonProperty("bEnableFriendlyFire")]
        /// <summary>
        /// Represents whether friendly fire is enabled.
        /// </summary>
        public bool bEnableFriendlyFire { get; set; }

        [JsonProperty("bEnableInvaderEnemy")]
        /// <summary>
        /// Represents whether invader enemies are enabled.
        /// </summary>
        public bool bEnableInvaderEnemy { get; set; }

        [JsonProperty("bActiveUNKO")]
        /// <summary>
        /// Represents whether UNKO is active.
        /// </summary>
        public bool bActiveUNKO { get; set; }

        [JsonProperty("bEnableAimAssistPad")]
        /// <summary>
        /// Represents whether aim assist is enabled for gamepad.
        /// </summary>
        public bool bEnableAimAssistPad { get; set; }

        [JsonProperty("bEnableAimAssistKeyboard")]
        /// <summary>
        /// Represents whether aim assist is enabled for keyboard.
        /// </summary>
        public bool bEnableAimAssistKeyboard { get; set; }

        [JsonProperty("DropItemMaxNum")]
        /// <summary>
        /// Represents the maximum number of drop items.
        /// </summary>
        public float DropItemMaxNum { get; set; }

        [JsonProperty("DropItemMaxNum_UNKO")]
        /// <summary>
        /// Represents the maximum number of UNKO drop items.
        /// </summary>
        public float DropItemMaxNum_UNKO { get; set; }

        [JsonProperty("BaseCampMaxNum")]
        /// <summary>
        /// Represents the maximum number of base camps.
        /// </summary>
        public float BaseCampMaxNum { get; set; }

        [JsonProperty("BaseCampWorkerMaxNum")]
        /// <summary>
        /// Represents the maximum number of workers in base camps.
        /// </summary>
        public float BaseCampWorkerMaxNum { get; set; }

        [JsonProperty("DropItemAliveMaxHours")]
        /// <summary>
        /// Represents the maximum number of hours drop items remain alive.
        /// </summary>
        public float DropItemAliveMaxHours { get; set; }

        [JsonProperty("bAutoResetGuildNoOnlinePlayers")]
        /// <summary>
        /// Represents whether guilds are automatically reset when no online players are present.
        /// </summary>
        public bool bAutoResetGuildNoOnlinePlayers { get; set; }

        [JsonProperty("AutoResetGuildTimeNoOnlinePlayers")]
        /// <summary>
        /// Represents the time in hours after which guilds are automatically reset when no online players are present.
        /// </summary>
        public float AutoResetGuildTimeNoOnlinePlayers { get; set; }

        [JsonProperty("GuildPlayerMaxNum")]
        /// <summary>
        /// Represents the maximum number of players in a guild.
        /// </summary>
        public float GuildPlayerMaxNum { get; set; }

        [JsonProperty("PalEggDefaultHatchingTime")]
        /// <summary>
        /// Represents the default hatching time for Pal eggs.
        /// </summary>
        public float PalEggDefaultHatchingTime { get; set; }

        [JsonProperty("WorkSpeedRate")]
        /// <summary>
        /// Represents the rate at which work speed is increased.
        /// </summary>
        public float WorkSpeedRate { get; set; }

        [JsonProperty("bIsMultiplay")]
        /// <summary>
        /// Represents whether the server is in multiplayer mode.
        /// </summary>
        public bool bIsMultiplay { get; set; }

        [JsonProperty("bIsPvP")]
        /// <summary>
        /// Represents whether the server is in PvP mode.
        /// </summary>
        public bool bIsPvP { get; set; }

        [JsonProperty("bCanPickupOtherGuildDeathPenaltyDrop")]
        /// <summary>
        /// Represents whether players can pick up death penalty drops from other guilds.
        /// </summary>
        public bool bCanPickupOtherGuildDeathPenaltyDrop { get; set; }

        [JsonProperty("bEnableNonLoginPenalty")]
        /// <summary>
        /// Represents whether non-login penalty is enabled.
        /// </summary>
        public bool bEnableNonLoginPenalty { get; set; }

        [JsonProperty("bEnableFastTravel")]
        /// <summary>
        /// Represents whether fast travel is enabled.
        /// </summary>
        public bool bEnableFastTravel { get; set; }

        [JsonProperty("bIsStartLocationSelectByMap")]
        /// <summary>
        /// Represents whether the start location is selected by map.
        /// </summary>
        public bool bIsStartLocationSelectByMap { get; set; }

        [JsonProperty("bExistPlayerAfterLogout")]
        /// <summary>
        /// Represents whether players continue to exist after logout.
        /// </summary>
        public bool bExistPlayerAfterLogout { get; set; }

        [JsonProperty("bEnableDefenseOtherGuildPlayer")]
        /// <summary>
        /// Represents whether defense against players from other guilds is enabled.
        /// </summary>
        public bool bEnableDefenseOtherGuildPlayer { get; set; }

        [JsonProperty("CoopPlayerMaxNum")]
        /// <summary>
        /// Represents the maximum number of players in cooperative play.
        /// </summary>
        public float CoopPlayerMaxNum { get; set; }

        [JsonProperty("ServerPlayerMaxNum")]
        /// <summary>
        /// Represents the maximum number of players on the server.
        /// </summary>
        public float ServerPlayerMaxNum { get; set; }

        [JsonProperty("ServerName")]
        /// <summary>
        /// Represents the name of the server.
        /// </summary>
        public string ServerName { get; set; }

        [JsonProperty("ServerDescription")]
        /// <summary>
        /// Represents the description of the server.
        /// </summary>
        public string ServerDescription { get; set; }

        [JsonProperty("PublicPort")]
        /// <summary>
        /// Represents the public port of the server.
        /// </summary>
        public float PublicPort { get; set; }

        [JsonProperty("PublicIP")]
        /// <summary>
        /// Represents the public IP address of the server.
        /// </summary>
        public string PublicIP { get; set; }

        [JsonProperty("RCONEnabled")]
        /// <summary>
        /// Represents whether RCON is enabled.
        /// </summary>
        public bool RCONEnabled { get; set; }

        [JsonProperty("RCONPort")]
        /// <summary>
        /// Represents the RCON port of the server.
        /// </summary>
        public float RCONPort { get; set; }

        [JsonProperty("Region")]
        /// <summary>
        /// Represents the region of the server.
        /// </summary>
        public string Region { get; set; }

        [JsonProperty("bUseAuth")]
        /// <summary>
        /// Represents whether authentication is used.
        /// </summary>
        public bool bUseAuth { get; set; }

        [JsonProperty("BanListURL")]
        /// <summary>
        /// Represents the URL of the ban list.
        /// </summary>
        public string BanListURL { get; set; }

        [JsonProperty("RESTAPIEnabled")]
        /// <summary>
        /// Represents whether the REST API is enabled.
        /// </summary>
        public bool RESTAPIEnabled { get; set; }

        [JsonProperty("RESTAPIPort")]
        /// <summary>
        /// Represents the REST API port of the server.
        /// </summary>
        public float RESTAPIPort { get; set; }

        [JsonProperty("bShowPlayerList")]
        /// <summary>
        /// Represents whether the player list is shown.
        /// </summary>
        public bool bShowPlayerList { get; set; }

        [JsonProperty("AllowConnectPlatform")]
        /// <summary>
        /// Represents the platform allowed for connection.
        /// </summary>
        public string AllowConnectPlatform { get; set; }

        [JsonProperty("bIsUseBackupSaveData")]
        /// <summary>
        /// Represents whether backup save data is used.
        /// </summary>
        public bool bIsUseBackupSaveData { get; set; }

        [JsonProperty("LogFormatType")]
        /// <summary>
        /// Represents the type of log format.
        /// </summary>
        public string LogFormatType { get; set; }
    }

    /// <summary>
    /// Death penalty options
    /// </summary>
    public enum DeathPenalty
    {
        /// <summary>
        /// All items, equipment, and Pals are dropped.
        /// </summary>
        All,
        /// <summary>
        /// Only items and equipment are dropped.
        /// </summary>
        ItemAndEquipment,
        /// <summary>
        /// Only items are dropped.
        /// </summary>
        Item,
        /// <summary>
        /// No items or pals are dropped.
        /// </summary>
        None
    }
}
