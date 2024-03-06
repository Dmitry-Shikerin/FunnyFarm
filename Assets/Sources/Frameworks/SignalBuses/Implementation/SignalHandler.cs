using System;
using System.Collections.Generic;
using Sources.Frameworks.SignalBuses.Interfaces;
using Sources.Frameworks.SignalBuses.Interfaces.Controllers;
using Sources.Frameworks.SignalBuses.Interfaces.Handlers;
using Sources.Frameworks.SignalBuses.Interfaces.Signals;

namespace Sources.Frameworks.SignalBuses.Implementation
{
    public class SignalHandler : ISignalHandler, ISignalHandlerRegisterer
    {
        private readonly List<ISignalController> _signalControllers = new List<ISignalController>();
        
        public void Handle<T>(T signal) where T : ISignal
        {
            foreach (ISignalController signalController in _signalControllers)
            {
                signalController.Handle(signal);
            }
        }

        public void Register(ISignalController signalController)
        {
            if (_signalControllers.Contains(signalController))
                throw new AggregateException();
            
            _signalControllers.Add(signalController);
        }

        public void Unregister(ISignalController signalController)
        {
            _signalControllers.Remove(signalController);
        }
    }
}