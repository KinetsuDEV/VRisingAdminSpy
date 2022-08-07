using ProjectM;
using ProjectM.Network;
using Unity.Entities;
using VRisingUtils.Utils;

namespace AdminSpy.Utils
{
    internal static class AdminSpyUtils
    {
        internal static string GetUserName(Entity entity)
        {
            var playerCharacter = WetstoneUtils.EntityManager.GetComponentData<FromCharacter>(entity);
            return WetstoneUtils.EntityManager.GetComponentData<User>(playerCharacter.User).CharacterName.ToString();
        }

        internal static string GetUserName(NetworkId entity)
        {
            var userEntity = entity.GetNetworkedEntity(WetstoneUtils.NetworkIdSystem._NetworkIdToEntityMap)._Entity;
            return WetstoneUtils.EntityManager.GetComponentData<User>(userEntity).CharacterName.ToString();
        }

        internal static void NotifyUsers(string message)
            => ServerChatUtils.SendSystemMessageToAllClients(WetstoneUtils.EntityManager, $"<color=#E74C3C>AdminSpy: {message}</color>");
    }
}
