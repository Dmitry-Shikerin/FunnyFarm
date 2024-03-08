using Sources.Client.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;
using UnityEngine;

namespace Sources.Client.Domain.Dtos
{
    public class PlayerInput : IContext
    {
        public PlayerInput(Vector3 direction)
        {
            Direction = direction;
        }

        public Vector3 Direction { get; }
    }
}