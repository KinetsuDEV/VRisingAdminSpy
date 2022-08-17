using AdminSpy.Configs;
using Wetstone.API;
using Wetstone.Hooks;

namespace AdminSpy.Systems
{
    internal static class ChatSystem
    {
        internal static void OnChatMessage(VChatEvent chatEvent)
        {
            if (chatEvent.Message.ToLower() == "!AdminSpy".ToLower())
            {
                chatEvent.User.SendSystemMessage($"Hello {chatEvent.User.CharacterName}. AdminSpy is running with following configs:");
                chatEvent.User.SendSystemMessage($"AnnounceAuth: {AdminSpyConfig.AnnounceAuth.Value}");
                chatEvent.User.SendSystemMessage($"AnnounceGive: {AdminSpyConfig.AnnounceGive.Value}");
                chatEvent.User.SendSystemMessage($"AnnounceTeleport: {AdminSpyConfig.AnnounceTeleport.Value}");
                chatEvent.User.SendSystemMessage($"AnnounceDurability: {AdminSpyConfig.AnnounceDurability.Value}");
                chatEvent.User.SendSystemMessage($"AnnounceHealth: {AdminSpyConfig.AnnounceHealth.Value}");
                chatEvent.User.SendSystemMessage($"AnnounceAdminLevel: {AdminSpyConfig.AnnounceAdminLevel.Value}");
                chatEvent.Cancel();
            }
        }
    }
}
