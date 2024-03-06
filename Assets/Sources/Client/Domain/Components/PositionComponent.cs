using Sources.Client.DomainInterfaces.Composite.Components;
using Sources.Frameworks.LiveData;
using UnityEngine;

namespace Sources.Client.Domain.Components
{
    public class PositionComponent : IComponent
    {
        private readonly MutableLiveData<Vector3> _position;

        public PositionComponent(Vector3 value)
        {
            _position = new MutableLiveData<Vector3>(value);
        }

        public LiveData<Vector3> Position => _position;

        public void Set(Vector3 position) => 
            _position.Value = position;

        public void Move(Vector3 signalMoveDelta) => 
            _position.Value += signalMoveDelta;
    }
}