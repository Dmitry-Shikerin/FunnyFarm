using Sources.Client.DomainInterfaces.Composite.Components;
using Sources.Frameworks.LiveData;
using UnityEngine;

namespace Sources.Client.Domain.Components
{
    public class LookDirectionComponent : IComponent
    {
        private readonly MutableLiveData<Vector3> _direction;

        public LookDirectionComponent(Vector3 direction)
        {
            _direction = new MutableLiveData<Vector3>(direction);
        }

        public LiveData<Vector3> Direction => _direction;

        public void Set(Vector3 direction) => 
            _direction.Value = direction;
    }
}