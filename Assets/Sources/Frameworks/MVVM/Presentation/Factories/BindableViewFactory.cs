using System.Reflection;
using Sources.Client.Infrastructure.Factories.PrefabFactories;
using Sources.Frameworks.MVVM.Presentation.Views;
using Sources.Frameworks.MVVM.PresentationInterfaces.Binder;
using Sources.Frameworks.MVVM.PresentationInterfaces.Factories;
using Sources.Frameworks.MVVM.PresentationInterfaces.Views;

namespace Sources.Frameworks.MVVM.Presentation.Factories
{
    public class BindableViewFactory : IBindableViewFactory
    {
        private static readonly string s_constructorMethodName = "Construct";

        private static readonly BindingFlags s_bindingFlags =
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

        private readonly PrefabFactory _prefabFactory = new PrefabFactory();
        private readonly IBinder _binder;

        public BindableViewFactory(IBinder binder)
        {
            _binder = binder;
        }
        
        public IBindableView Create(string viewPath, string name, IBindableView parent = null)
        {
            BindableView view = _prefabFactory.Create<BindableView>(viewPath + name);
            Construct(view);
            
            //TODO для чего здесь устанавливать парента?
            view.SetParent(parent);

            return view;
        }

        private void Construct(BindableView view)
        {
            //TODO для чего констрак в биндейблВью публичный если мы его берем через рефлекси?
            MethodInfo methodInfo = typeof(BindableView).GetMethod(s_constructorMethodName, s_bindingFlags);
            
            //TODO что здесь происходит?
            methodInfo.Invoke(view, new object[] { _binder });
        }
    }
}