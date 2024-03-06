using Sources.Frameworks.SignalBuses.Interfaces.Signals;

namespace Sources.Client.Controllers.Signals.Players
{
    public class PlayerSpeedSignal : ISignal
    {
        public PlayerSpeedSignal(float speed)
        {
            Speed = speed;
        }

        public float Speed { get; }
    }
}