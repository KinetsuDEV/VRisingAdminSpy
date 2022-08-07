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
                chatEvent.User.SendSystemMessage($"Hello {chatEvent.User.CharacterName}. AdminSpy is running!");
                chatEvent.Cancel();
            }
        }
    }
}
