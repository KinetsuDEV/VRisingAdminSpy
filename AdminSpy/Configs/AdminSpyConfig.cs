using BepInEx.Configuration;

namespace AdminSpy.Configs
{
    internal static class AdminSpyConfig
    {
        internal static ConfigEntry<bool> AnnounceAuth { get; private set; }
        internal static ConfigEntry<bool> AnnounceGive { get; private set; }
        internal static ConfigEntry<bool> AnnounceTeleport { get; private set; }
        internal static ConfigEntry<bool> AnnounceDurability { get; private set; }
        internal static ConfigEntry<bool> AnnounceHealth { get; private set; }
        internal static ConfigEntry<bool> AnnounceAdminLevel { get; private set; }

        internal static void Initialize(ConfigFile config)
        {
            AnnounceAuth = config.Bind(nameof(AdminSpyConfig), nameof(AnnounceAuth), false, "Announce following commands execution: Adminauth, AdminDeauth");
            AnnounceGive = config.Bind(nameof(AdminSpyConfig), nameof(AnnounceGive), true, "Announce following commands execution: Give, GiveSet");
            AnnounceTeleport = config.Bind(nameof(AdminSpyConfig), nameof(AnnounceTeleport), false, "Announce following commands execution: All kind of teleport command");
            AnnounceDurability = config.Bind(nameof(AdminSpyConfig), nameof(AnnounceDurability), false, "Announce following command execution: ChangeDurability");
            AnnounceHealth = config.Bind(nameof(AdminSpyConfig), nameof(AnnounceHealth), true, "Announce following commands execution: ChangeHealthOfClosestToMouse");
            AnnounceAdminLevel = config.Bind(nameof(AdminSpyConfig), nameof(AnnounceAdminLevel), false, "Announce following command execution: SetAdminLevel");
        }
    }
}
