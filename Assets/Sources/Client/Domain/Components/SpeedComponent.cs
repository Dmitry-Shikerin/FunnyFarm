using Sources.Client.DomainInterfaces.Composite.Components;
using Sources.Frameworks.LiveData;

namespace Sources.Client.Domain.Components
{
    public class SpeedComponent : IComponent
    {
        private readonly float _multiplier;
        
        //TODO задать вопросы про ливДату
        private readonly MutableLiveData<float> _speed = new MutableLiveData<float>();

        public SpeedComponent(float multiplier)
        {
            _multiplier = multiplier;
        }

        public LiveData<float> Speed => _speed;

        public void Set(float speed) => 
            _speed.Value = speed * _multiplier;
    }
}