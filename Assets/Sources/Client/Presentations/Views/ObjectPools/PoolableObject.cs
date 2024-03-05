using System;
using Sources.Client.InfrastructureInterfaces.Services.ObjectPools;
using UnityEngine;

namespace Sources.Client.Presentations.Views.ObjectPools
{
    public class PoolableObject : MonoBehaviour
    {
        private IObjectPool _pool;

        public PoolableObject SetPool(IObjectPool pool)
        {
            _pool = pool ?? throw new NullReferenceException(nameof(pool));

            return this;
        }

        public void ReturnToPool()
        {
            _pool.Return(this);
        }
    }
}