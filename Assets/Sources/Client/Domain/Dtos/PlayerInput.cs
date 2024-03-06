using UnityEngine;

namespace Sources.Client.Domain.Dtos
{
    public class PlayerInput
    {
        public PlayerInput(Vector3 direction)
        {
            Direction = direction;
        }

        public Vector3 Direction { get; }
    }
}