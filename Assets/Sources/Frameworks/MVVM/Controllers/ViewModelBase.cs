using System;
using Sirenix.Utilities;
using Sources.Frameworks.MVVM.ControllersInterfaces;
using Sources.Frameworks.MVVM.ControllersInterfaces.Components;
using Unity.VisualScripting;

namespace Sources.Frameworks.MVVM.Controllers
{
    public abstract class ViewModelBase : IViewModel
    {
        //TODO сделать базовую вьюМодель без компонентов
        private readonly IViewModelComponent[] _components;

        private bool _isEnabled;

        protected ViewModelBase(IViewModelComponent[] components)
        {
            _components = components;
        }

        public event Action Destroyed;

        public void Enable()
        {
            if (_isEnabled)
                return;

            EnableParts();

            OnBeforeEnable();
            _isEnabled = true;
            OnEnable();
            OnAfterEnable();
        }

        public void Disable()
        {
            if (_isEnabled == false)
                return;

            OnBeforeDisable();
            _isEnabled = false;
            OnDisable();
            OnAfterDisable();

            DisableParts();
        }

        protected abstract void OnEnable();

        protected abstract void OnDisable();

        protected virtual void OnBeforeEnable()
        {
        }

        protected virtual void OnBeforeDisable()
        {
        }

        protected virtual void OnAfterEnable()
        {
        }

        protected virtual void OnAfterDisable()
        {
        }

        //TODO каким образом получилось через Linq?
        private void EnableParts() => 
            _components.ForEach(component => component.Enable());

        private void DisableParts() => 
            _components.ForEach(component => component.Disable());
    }
}