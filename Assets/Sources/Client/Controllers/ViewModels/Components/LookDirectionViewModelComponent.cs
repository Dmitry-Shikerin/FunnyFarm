using Sources.Client.PresentationsInterfaces.Binds.Rotations;
using Sources.Client.UseCases.Common.Components.LookDirection.Queries;
using Sources.Frameworks.LiveData;
using Sources.Frameworks.MVVM.ControllersInterfaces.Components;
using Sources.Frameworks.MVVM.Domain.Attributes;
using Sources.Frameworks.MVVM.DomainInterfaces.Properties;
using UnityEngine;

namespace Sources.Client.Controllers.ViewModels.Components
{
    public class LookDirectionViewModelComponent : IViewModelComponent
    {
        private LiveData<Vector3> _lookDirection;

        [PropertyBinding(typeof(ILookDirectionPropertyBind))]
        private IBindableProperty<Vector3> _worldRotation;
        
        public LookDirectionViewModelComponent(int id, GetLookDirectionQuery getLookDirectionQuery) => 
            _lookDirection = getLookDirectionQuery.Handle(id);

        public void Enable() => 
            _lookDirection.Observe(OnLookDirectionChanged);

        public void Disable() => 
            _lookDirection.UnObserve(OnLookDirectionChanged);

        private void OnLookDirectionChanged(Vector3 direction) => 
            _worldRotation.Value = direction;
    }
}