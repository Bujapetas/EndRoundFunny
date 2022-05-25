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
        public static void AllScp096()
            => SpawnAs(RoleType.Scp096);
        public static void AllScp173()
            => SpawnAs(RoleType.Scp173);
        public static void TpScp106Portal()
            => SpawnAndTp(Player.List,RoleType.ClassD, Room.Get(RoomType.Pocket).Position, null);
        private static void SpawnAs(RoleType roleType)
        {
            foreach (Player p in Player.List)
                p?.SetRole(roleType);
        }

        private static void SpawnAndTp(IEnumerable<Player> players,RoleType roleType, Vector3 position, EffectType ?effectType)
        {
            foreach (Player p in players)
            {
                p?.SetRole(roleType);
                if(effectType != null)
                    p?.EnableEffect((EffectType) effectType,10f);
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