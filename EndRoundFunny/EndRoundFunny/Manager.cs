using System;
using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features;
using JetBrains.Annotations;
using MEC;
using UnityEngine;

namespace EndRoundFunny
{
    public static class Manager
    {
        public static HashSet<ItemType> Scp018 = new HashSet<ItemType>(){ItemType.SCP018};
        public static HashSet<ItemType> TeamsItem = new HashSet<ItemType>(){ItemType.GunAK,ItemType.SCP500};

        public static void AllScp096()
            => SpawnAs(RoleType.Scp096);
        public static void AllScp173()
            => SpawnAs(RoleType.Scp173);
        public static void TpScp106Portal()
            => SpawnAndTp(Player.List,RoleType.ClassD, Room.Get(RoomType.Pocket).Position);

        public static void GateWithScp018()
        {
            Door.Get(DoorType.Scp173Gate).IsOpen = false;
            Door.Get(DoorType.Scp173Gate).ChangeLock(DoorLockType.AdminCommand);
            SpawnAndTp(Player.List,RoleType.ClassD, Room.Get(RoomType.Lcz173).transform.TransformPoint(25,16,11));
        }
        
        public static void NtfsVsCaos079(){}
        
        private static void SpawnAs(RoleType roleType)
        {
            foreach (Player p in Player.List)
                p?.SetRole(roleType);
        }
        private static void SpawnAndTp(IEnumerable<Player> players,RoleType roleType, Vector3 position)
        {
            foreach (Player p in players)
            {
                p?.SetRole(roleType);
                p?.ResetInventory(Scp018);
                Main.Sigleton.Coroutines.Add(Timing.RunCoroutine(_tpAferSpawn(p, position)));
            }
        }

        private static IEnumerator<float> _tpAferSpawn([CanBeNull] Player player, Vector3 position)
        {
            yield return Timing.WaitForSeconds(0.5f);
            player?.Teleport(position);
        }
    }
}