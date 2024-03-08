using System;
using ModestTree.Util;
using Sources.InfrastructureInterfaces.Services.Updates;

namespace Sources.Client.InfrastructureInterfaces.Services.UpdateServices
{
    public interface IUpdateService : IUpdatable
    {
        event Action<float> UpdateChanged;
    }
}