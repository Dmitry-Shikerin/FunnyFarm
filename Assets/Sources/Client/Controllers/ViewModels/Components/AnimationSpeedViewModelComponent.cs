using Sources.Client.PresentationsInterfaces.Binds.Animators;
using Sources.Client.UseCases.Common.Components.Speeds.Queries;
using Sources.Frameworks.LiveData;
using Sources.Frameworks.MVVM.ControllersInterfaces.Components;
using Sources.Frameworks.MVVM.Domain.Attributes;
using Sources.Frameworks.MVVM.DomainInterfaces.Properties;
using Sources.Frameworks.MVVM.DomainInterfaces.Properties.Generic;

namespace Sources.Client.Controllers.ViewModels.Components
{
    public class AnimationSpeedViewModelComponent : IViewModelComponent
    {
        private readonly LiveData<float> _speed;

        [PropertyBinding(typeof(IAnimatorFloatPropertyBind), "Speed")]
        private IBindableProperty<float> _animationSpeed;

        public AnimationSpeedViewModelComponent(int id, GetSpeedQuery getSpeedQuery)
        {
            _speed = getSpeedQuery.Handle(id);
        }

        public void Enable() => 
            _speed.Observe(OnSpeedChanged);

        public void Disable() => 
            _speed.UnObserve(OnSpeedChanged);

        private void OnSpeedChanged(float speed) => 
            _animationSpeed.Value = speed;
    }
}