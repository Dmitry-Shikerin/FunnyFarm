using Sources.Client.PresentationsInterfaces.Binds.Visibilities;
using Sources.Client.UseCases.Common.Components.Visibilities.Queries;
using Sources.Frameworks.LiveData;
using Sources.Frameworks.MVVM.ControllersInterfaces.Components;
using Sources.Frameworks.MVVM.Domain.Attributes;
using Sources.Frameworks.MVVM.DomainInterfaces.Properties;

namespace Sources.Client.Controllers.ViewModels.Components
{
    public class VisibilityViewModelComponent : IViewModelComponent
    {
        private readonly LiveData<bool> _isVisible;

        [PropertyBinding(typeof(IBindableViewEnabledPropertyBind))]
        private IBindableProperty<bool> _isEnabled;
        
        public VisibilityViewModelComponent(int id, GetVisibilityQuery getVisibilityQuery)
        {
            _isVisible = getVisibilityQuery.Handle(id);
        }

        public void Enable() => 
            _isVisible.Observe(OnVisibilityChanged);

        public void Disable() => 
            _isVisible.UnObserve(OnVisibilityChanged);

        private void OnVisibilityChanged(bool value) => 
            _isEnabled.Value = value;
    }
}