using AdminSpy.Configs;
using AdminSpy.Systems;
using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using System.Reflection;
using VRisingUtils.Utils;
using Wetstone.API;
using Wetstone.Hooks;

namespace AdminSpy
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("xyz.molenzwiebel.wetstone")]
    [Reloadable]
    public class Plugin : BasePlugin
    {
        private Harmony harmony;

        public override void Load()
        {
            if (!VWorld.IsServer)
            {
                Log.LogWarning($"Plugin {PluginInfo.PLUGIN_NAME} is server side only");
                return;
            }

            LogUtils.Initialize(Log);
            AdminSpyConfig.Initialize(Config);

            harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            Chat.OnChatMessage += ChatSystem.OnChatMessage;

            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_NAME} {PluginInfo.PLUGIN_VERSION} loaded successfully!");
        }

        public override bool Unload()
        {
            if (!VWorld.IsServer)
                return true;

            Chat.OnChatMessage -= ChatSystem.OnChatMessage;

            Config.Clear();
            harmony.UnpatchSelf();

            return true;
        }
    }
}
