using System;
using Sources.Client.Domain.Dtos;
using Sources.InfrastructureInterfaces.Services.Updates;

namespace Sources.Client.InfrastructureInterfaces.Services.InputServices
{
    public interface IInputService : IUpdatable
    {
        PlayerInput PlayerInput { get; }
    }
}