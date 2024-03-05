using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Client.Infrastructure.Factories.PrefabFactories
{
    //TODO сделать интерфей для этой фабрики
    public class PrefabFactory
    {
        private readonly Dictionary<string, Object> _resources = new Dictionary<string, Object>();
        
        public T Create<T>(string prefabPath = "") where T : MonoBehaviour => 
            Object.Instantiate((T)GetResource(prefabPath, typeof(T)));

        public T Create<T>(Type viewType, string prefabPath = "") where T : Object => 
            Object.Instantiate((T)GetResource(prefabPath, viewType));

        private Object GetResource(string prefabPath, Type type)
        {
            if (_resources.ContainsKey(prefabPath) == false)
            {
                Object resource = Resources.Load(prefabPath, type);
                _resources[prefabPath] = resource;
            }

            return _resources[prefabPath];
        }
    }
}