using Sources.Frameworks.SignalBuses.Interfaces.Signals;
using UnityEngine;

namespace Sources.Client.Controllers.Signals.Players
{
    public class PlayerRotateSignal : ISignal
    {
        public PlayerRotateSignal(Vector3 lookDirection)
        {
            LookDirection = lookDirection;
        }

        public Vector3 LookDirection { get; }
    }
}