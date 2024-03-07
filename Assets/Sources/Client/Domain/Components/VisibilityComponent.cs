using Sources.Client.DomainInterfaces.Composite.Components;
using Sources.Frameworks.LiveData;

namespace Sources.Client.Domain.Components
{
    public class VisibilityComponent : IComponent
    {
        private MutableLiveData<bool> _isVisible;

        public VisibilityComponent(bool isVisible)
        {
            _isVisible = new MutableLiveData<bool>(isVisible);
        }

        public LiveData<bool> IsVisible => _isVisible;

        public void Show() => 
            _isVisible.Value = true;

        public void Hide() => 
            _isVisible.Value = false;
    }
}