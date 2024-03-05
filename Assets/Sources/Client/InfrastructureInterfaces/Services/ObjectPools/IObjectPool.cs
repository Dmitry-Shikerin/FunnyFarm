using System;
using Sources.Client.Presentations.Views;
using Sources.Client.Presentations.Views.ObjectPools;
using UnityEngine;

namespace Sources.Client.InfrastructureInterfaces.Services.ObjectPools
{
    public interface IObjectPool
    {
        event Action<int> ObjectCountChanged;

        T Get<T>() where T : View;
        void Return(PoolableObject poolableObject);
    }
}