using Sources.Frameworks.SignalBuses.Interfaces.Signals;
using UnityEngine;

namespace Sources.Client.Controllers.Signals.Players
{
    public class CreatePlayerSignal : ISignal
    {
        public CreatePlayerSignal(Vector3 spawnPosition)
        {
            SpawnPosition = spawnPosition;
        }

        public Vector3 SpawnPosition { get; }
    }
}