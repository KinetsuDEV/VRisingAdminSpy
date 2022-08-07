using AdminSpy.Systems;
using HarmonyLib;
using ProjectM;
using System;
using VRisingUtils.Utils;

namespace AdminSpy.Hooks
{
    [Harmony]
    internal static class ServerBootstrapSystemHook
    {
        [HarmonyPatch(typeof(ServerBootstrapSystem), nameof(ServerBootstrapSystem.NetworkEventLogging))]
        [HarmonyPrefix]
        private static void ServerBootstrapSystem_NetworkEventLogging_Prefix(ServerBootstrapSystem __instance)
        {
            try
            {
                AdminSpySystem.SpyCommand(__instance);
            }
            catch (Exception e)
            {
                LogUtils.Logger.LogError(e);
            }
        }
    }
}
