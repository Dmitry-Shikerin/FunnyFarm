using Sources.Frameworks.MVVM.Presentation.Views;
using Sources.Frameworks.MVVM.PresentationInterfaces.Views;

namespace Sources.Frameworks.MVVM.PresentationInterfaces.Factories
{
    public interface IBindableViewFactory
    {
        IBindableView Create(string viewPath, string name, IBindableView parent = null);
        IBindableView Create(BindableView view, IBindableView parent = null);
    }
}