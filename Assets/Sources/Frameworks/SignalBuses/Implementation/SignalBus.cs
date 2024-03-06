using System;
using Sources.Frameworks.SignalBuses.Interfaces;
using Sources.Frameworks.SignalBuses.Interfaces.Signals;

namespace Sources.Frameworks.SignalBuses.Implementation
{
    public class SignalBus : ISignalBus
    {
        private readonly ISignalHandler _signalHandler;

        public SignalBus(ISignalHandler signalHandler)
        {
            _signalHandler = signalHandler ?? throw new ArgumentNullException(nameof(signalHandler));
        }

        public void Handle<T>(T signal) where T : ISignal
        {
            //Network
            
            _signalHandler.Handle(signal);
        }
    }
}