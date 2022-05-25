using System;
using System.Collections.Generic;
using EndRoundFunny.Properties;
using Exiled.API.Features;
using MEC;

namespace EndRoundFunny
{
    public class Main : Plugin<Config>
    {
        public override string Name => typeof(Plugin<>).Namespace;
        public override string Prefix => Name.ToLower();
        public override string Author => "Buja";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(5, 2, 1);

        public static Main Sigleton;
        private EventHandlers _eventHandler;
        public HashSet<CoroutineHandle> Coroutines;

        public override void OnEnabled()
        {
            Sigleton = this;
            _eventHandler = new EventHandlers();
            Coroutines = new HashSet<CoroutineHandle>();
            Exiled.Events.Handlers.Server.EndingRound += _eventHandler.OnEndingRound;
            Exiled.Events.Handlers.Server.RestartingRound += _eventHandler.OnRestartingRound;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.EndingRound -= _eventHandler.OnEndingRound;
            Exiled.Events.Handlers.Server.RestartingRound -= _eventHandler.OnRestartingRound;
            Coroutines = null;
            _eventHandler = null;
            Sigleton = null;
            base.OnDisabled();
        }
    }
}