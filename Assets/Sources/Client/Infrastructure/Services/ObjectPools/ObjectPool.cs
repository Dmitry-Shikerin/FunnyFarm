using System;
using System.Collections.Generic;
using Sources.Client.InfrastructureInterfaces.Services.ObjectPools;
using Sources.Client.Presentations.Views;
using Sources.Client.Presentations.Views.ObjectPools;
using UnityEngine;

namespace Sources.Client.Infrastructure.Services.ObjectPools
{
    public class ObjectPool<T> : IObjectPool where T : View
    {
        private readonly Queue<T> _objects = new Queue<T>();
        private readonly Transform _parent;

        public event Action<int> ObjectCountChanged;

        public int Count => _objects.Count;

        public ObjectPool(Transform parent)
        {
            _parent = parent ? parent : throw new ArgumentNullException(nameof(parent));
        }
        
        public ObjectPool()
        {
            _parent = new GameObject($"Pool of {typeof(T).Name}").transform;
        }
        
        public TType Get<TType>() where TType : View
        {
            if (_objects.Count == 0)
                return null;

            if (_objects.Dequeue() is not TType @object)
                return null;

            if (@object == null)
                return null;
            
            @object.SetParent(null);
            ObjectCountChanged?.Invoke(_objects.Count);
            
            @object.Show();
            
            return @object;
        }

        public void Return(PoolableObject poolableObject)
        {
            if(poolableObject.TryGetComponent(out T @object) == false)
                return;
            
            poolableObject.transform.SetParent(_parent);
            _objects.Enqueue(@object);
            ObjectCountChanged?.Invoke(_objects.Count);
        }
    }
}