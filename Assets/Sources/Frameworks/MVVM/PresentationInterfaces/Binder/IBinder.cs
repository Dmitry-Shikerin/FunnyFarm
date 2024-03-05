using Sources.Frameworks.MVVM.ControllersInterfaces;
using Sources.Frameworks.MVVM.PresentationInterfaces.Views;

namespace Sources.Frameworks.MVVM.PresentationInterfaces.Binder
{
    public interface IBinder
    {
        void Bind(IBindableView view, IViewModel viewModel);
        void Unbind(IBindableView view, IViewModel viewModel);
    }
}