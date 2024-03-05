using System;
using Sources.Frameworks.MVVM.ControllersInterfaces;
using Sources.Frameworks.MVVM.PresentationInterfaces.Binder;
using Sources.Frameworks.MVVM.PresentationInterfaces.Views;
using UnityEngine;

namespace Sources.Frameworks.MVVM.Presentation.Views
{
    public class BindableView : MonoBehaviour, IBindableView
    {
        protected IBinder Binder;

        private IViewModel _viewModel;
        
        private Action AfterUnbindCallback { get; set; }

        //TODO Для чего это?
        private void Awake() => 
            gameObject.SetActive(false);

        //TODO все эти методы должны быть публичными?
        public void Bind(IViewModel viewModel)
        {
            _viewModel = viewModel;
            Binder.Bind(this, viewModel);
            viewModel.Enable();
        }

        public void Unbind()
        {
            if(_viewModel != null)
                Binder.Unbind(this, _viewModel);
            
            gameObject.SetActive(false);
            
            AfterUnbindCallback?.Invoke();
        }

        public void Construct(IBinder binder) => 
            Binder = binder ?? throw new ArgumentNullException(nameof(binder));

        public void SetParent(IBindableView parent)
        {
            if(parent is null)
                return;

            if (parent is not MonoBehaviour monoBehaviour)
                throw new InvalidOperationException();
            
            monoBehaviour.transform.SetParent(transform, false);
        }
    }
}