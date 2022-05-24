using System.ComponentModel;
using Exiled.API.Interfaces;

namespace EndRoundFunny
{
    public class Config : IConfig
    {
        [Description("Is enable?")]
        public bool IsEnabled { get; set; } = true;
    }
}