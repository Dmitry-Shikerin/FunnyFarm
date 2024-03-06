using Sources.Frameworks.SignalBuses.Interfaces.Controllers;

namespace Sources.Frameworks.SignalBuses.Interfaces.Handlers
{
    public interface ISignalHandlerRegisterer
    {
        void Register(ISignalController signalController);
        void Unregister(ISignalController signalController);
    }
}