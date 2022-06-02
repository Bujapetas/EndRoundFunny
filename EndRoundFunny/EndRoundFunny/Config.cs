using System.ComponentModel;
using Exiled.API.Interfaces;

namespace EndRoundFunny
{
    public class Config : IConfig
    {
        [Description("Is enable?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Is FF enable in your server?")]
        public bool FF { get; set; } = false;
    }
}