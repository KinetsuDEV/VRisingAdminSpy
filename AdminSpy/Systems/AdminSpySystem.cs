using AdminSpy.Configs;
using AdminSpy.Utils;
using ProjectM;
using ProjectM.Network;
using Unity.Collections;
using Unity.Entities;
using VRisingUtils.Extensions;
using VRisingUtils.Utils;

namespace AdminSpy.Systems
{
    internal static class AdminSpySystem
    {
        internal static void SpyCommand(ServerBootstrapSystem system)
        {
            if (system.__NetworkEventLogging_entityQuery.IsEmpty)
                return;

            var entities = system.__NetworkEventLogging_entityQuery.ToEntityArray(Allocator.Temp);

            foreach (var entity in entities)
            {
                if (AdminSpyConfig.AnnounceAuth.Value)
                {
                    if (WetstoneUtils.EntityManager.HasComponent(entity, nameof(AdminAuthEvent)))
                        AnnounceAdminAuthCommand(entity);

                    if (WetstoneUtils.EntityManager.HasComponent(entity, nameof(DeauthAdminEvent)))
                        AnnounceAdminDeauthCommand(entity);
                }

                if (AdminSpyConfig.AnnounceGive.Value && WetstoneUtils.EntityManager.HasComponent<GiveDebugEvent>(entity))
                    AnnounceGiveCommand(entity);

                if (AdminSpyConfig.AnnounceDurability.Value && WetstoneUtils.EntityManager.HasComponent(entity, nameof(ChangeDurabilityDebugEvent)))
                    AnnounceChangeDurabilityCommand(entity);

                if (AdminSpyConfig.AnnounceHealth.Value && WetstoneUtils.EntityManager.HasComponent(entity, nameof(ChangeHealthOfClosestToPositionDebugEvent)))
                    AnnounceChangeHealthCommand(entity);

                if (AdminSpyConfig.AnnounceTeleport.Value)
                {
                    if (WetstoneUtils.EntityManager.HasComponent(entity, nameof(PlayerTeleportDebugEvent)))
                        AnnounceTeleportCommand(entity);

                    if (WetstoneUtils.EntityManager.HasComponent(entity, nameof(TeleportToPlayerLocationDebugEvent)))
                        AnnounceTeleportToPlayerCommand(entity);

                    if (WetstoneUtils.EntityManager.HasComponent(entity, nameof(TeleportPlayerToLocationDebugEvent)))
                        AnnounceTeleportPlayerToCommand(entity);

                    if (WetstoneUtils.EntityManager.HasComponent(entity, "DebugTeleportToNetherEvent"))
                        AnnounceTeleportToNetherCommand(entity);

                    if (WetstoneUtils.EntityManager.HasComponent(entity, "DebugTeleportToEntityEvent"))
                        AnnounceTeleportToWaypointCommand(entity);
                }

                if (AdminSpyConfig.AnnounceAdminLevel.Value && WetstoneUtils.EntityManager.HasComponent(entity, nameof(SetUserAdminLevelAdminEvent)))
                    AnnounceSetAdminLevelCommand(entity);
            }
        }

        private static void AnnounceAdminAuthCommand(Entity entity) =>
            AdminSpyUtils.NotifyUsers($"Character {AdminSpyUtils.GetUserName(entity)} becomes administrator");

        private static void AnnounceAdminDeauthCommand(Entity entity) =>
            AdminSpyUtils.NotifyUsers($"Character {AdminSpyUtils.GetUserName(entity)} is no longer administrator");

        private static void AnnounceTeleportToNetherCommand(Entity entity) =>
            AdminSpyUtils.NotifyUsers($"Admin {AdminSpyUtils.GetUserName(entity)} teleported to Nether");

        private static void AnnounceTeleportToWaypointCommand(Entity entity) =>
            AdminSpyUtils.NotifyUsers($"Admin {AdminSpyUtils.GetUserName(entity)} teleported to some waypoint");

        private static void AnnounceGiveCommand(Entity entity)
        {
            var eventData = WetstoneUtils.EntityManager.GetComponentData<GiveDebugEvent>(entity);
            AdminSpyUtils.NotifyUsers($"Admin {AdminSpyUtils.GetUserName(entity)} created {eventData.Amount}x {ItemUtils.GetItemName(new PrefabGUID(eventData.PrefabGuidHash))}");
        }

        private static void AnnounceChangeDurabilityCommand(Entity entity)
        {
            var eventData = WetstoneUtils.EntityManager.GetComponentData<ChangeDurabilityDebugEvent>(entity);
            AdminSpyUtils.NotifyUsers($"Admin {AdminSpyUtils.GetUserName(entity)} changed durability of {eventData.EquipmentType} on {eventData.Amount}");
        }

        private static void AnnounceChangeHealthCommand(Entity entity)
        {
            var eventData = WetstoneUtils.EntityManager.GetComponentData<ChangeHealthOfClosestToPositionDebugEvent>(entity);
            var valueSignal = eventData.Amount > 0 ? "+" : string.Empty;
            AdminSpyUtils.NotifyUsers($"Admin {AdminSpyUtils.GetUserName(entity)} changed health of something on {valueSignal}{eventData.Amount}");
        }

        private static void AnnounceTeleportCommand(Entity entity)
        {
            var eventData = WetstoneUtils.EntityManager.GetComponentData<PlayerTeleportDebugEvent>(entity);
            AdminSpyUtils.NotifyUsers($"Admin {AdminSpyUtils.GetUserName(entity)} teleported {eventData.Target}");
        }

        private static void AnnounceTeleportToPlayerCommand(Entity entity)
        {
            var eventData = WetstoneUtils.EntityManager.GetComponentData<TeleportToPlayerLocationDebugEvent>(entity);

            if (eventData.TeleportType == TeleportToPlayerLocationType.PlayerToCaller)
                AdminSpyUtils.NotifyUsers($"Admin {AdminSpyUtils.GetUserName(entity)} teleported {AdminSpyUtils.GetUserName(eventData.PlayerNetworkId)} to his position");
            else
                AdminSpyUtils.NotifyUsers($"Admin {AdminSpyUtils.GetUserName(entity)} teleported to {AdminSpyUtils.GetUserName(eventData.PlayerNetworkId)} position");
        }

        private static void AnnounceTeleportPlayerToCommand(Entity entity)
        {
            var eventData = WetstoneUtils.EntityManager.GetComponentData<TeleportPlayerToLocationDebugEvent>(entity);
            AdminSpyUtils.NotifyUsers($"Admin {AdminSpyUtils.GetUserName(entity)} teleported {AdminSpyUtils.GetUserName(eventData.PlayerNetworkId)} to his cursor position");
        }

        private static void AnnounceSetAdminLevelCommand(Entity entity)
        {
            var eventData = WetstoneUtils.EntityManager.GetComponentData<SetUserAdminLevelAdminEvent>(entity);
            AdminSpyUtils.NotifyUsers($"Admin {AdminSpyUtils.GetUserName(entity)} set admin level [{eventData.AdminLevel}] to {AdminSpyUtils.GetUserName(eventData.UserNetworkId)}");
        }
    }
}
