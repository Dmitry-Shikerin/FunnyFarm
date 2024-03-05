using System;

namespace Sources.Frameworks.MVVM.ControllersInterfaces
{
    public interface IViewModel
    {
        public event Action Destroyed;

        void Enable();
        void Disable();
    }
}