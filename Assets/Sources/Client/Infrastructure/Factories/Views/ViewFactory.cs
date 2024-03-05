using System.Reflection;
using Sources.Client.Infrastructure.Factories.PrefabFactories;
using Sources.Client.Presentations.Views;
using Sources.Frameworks.MVVM.ControllersInterfaces;
using Binder = Sources.Client.Infrastructure.Bindings.Binder;

namespace Sources.Client.Infrastructure.Factories.Views
{
    public class ViewFactory
    {
        private static readonly string s_constructorMethodName = "Construct";
        private static readonly BindingFlags s_bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
        
        private readonly PrefabFactory _prefabFactory = new PrefabFactory();
        private readonly Binder _binder = new Binder();

        public TView Create<TView, TViewModel>(TViewModel viewModel) 
            where TView : View
            where TViewModel : IViewModel
        {
            TView view = _prefabFactory.Create<TView>();

            MethodInfo methodInfo = typeof(View).GetMethod(s_constructorMethodName, s_bindingFlags);

            methodInfo.Invoke(view, new object[] {viewModel, _binder});

            return view;
        }
    }
}