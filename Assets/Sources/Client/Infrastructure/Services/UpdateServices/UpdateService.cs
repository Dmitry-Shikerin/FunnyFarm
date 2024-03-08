using System;
using Sources.Client.InfrastructureInterfaces.Services.UpdateServices;

namespace Sources.Client.Infrastructure.Services.UpdateServices
{
    public class UpdateService : IUpdateService
    {
        public event Action<float> UpdateChanged;
        
        public void Update(float deltaTime) => 
            UpdateChanged?.Invoke(deltaTime);
    }
}