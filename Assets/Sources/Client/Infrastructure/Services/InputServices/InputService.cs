using Sources.Client.Domain.Dtos;
using Sources.Client.InfrastructureInterfaces.Services.InputServices;
using UnityEngine;

namespace Sources.Client.Infrastructure.Services.InputServices
{
    public class InputService : IInputService
    {
        public PlayerInput PlayerInput { get; private set; } = new PlayerInput(new Vector3());

        public void Update(float deltaTime)
        {
            UpdateMovement();
        }

        private void UpdateMovement()
        {
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),
                0, Input.GetAxis("Vertical"));

            if (direction.magnitude > 0.01f)
            {
                PlayerInput = new PlayerInput(direction);
            }
            else
            {
                PlayerInput = new PlayerInput(new Vector3());
            }
        }
    }
}