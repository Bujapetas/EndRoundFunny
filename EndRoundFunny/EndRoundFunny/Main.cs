using System;
using Exiled.API.Features;

namespace EndRoundFunny
{
    public class Main : Plugin<Config>
    {
        public override string Name => typeof(Plugin<>).Namespace;
        public override string Prefix => Name.ToLower();
        public override string Author => "Buja";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(5, 2, 1);

        public override void OnEnabled()
        {
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
        }
    }
}