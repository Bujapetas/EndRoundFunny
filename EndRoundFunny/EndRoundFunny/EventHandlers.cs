using Exiled.Events.EventArgs;
using MEC;
using Random = UnityEngine.Random;

namespace EndRoundFunny.Properties
{
    public class EventHandlers
    {
        public void OnEndingRound(EndingRoundEventArgs ev)
        {
            switch (Random.Range(0,10))
            {
                case 1:
                    Manager.AllScp096();
                    break;
                case 2:
                    Manager.AllScp173();
                    break;
                case 3:
                    Manager.TpScp106Portal();
                    break;
                case 4:
                    Manager.GateWithScp018();
                    break;
            }
        }

        public void OnRestartingRound()
        {
            foreach (CoroutineHandle coroutine in Main.Sigleton.Coroutines)
                Timing.KillCoroutines(coroutine);
        }
    }
}