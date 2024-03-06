using Sources.Frameworks.SignalBuses.Interfaces.Signals;
using UnityEngine;

namespace Sources.Client.Controllers.Signals.Players
{
    public class PlayerMoveSignal : ISignal
    {
        public PlayerMoveSignal(Vector3 moveDelta)
        {
            MoveDelta = moveDelta;
        }
        
        public Vector3 MoveDelta { get; }
    }
}