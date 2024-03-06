using Sources.Frameworks.SignalBuses.Interfaces.Signals;

namespace Sources.Frameworks.SignalBuses.Interfaces.Controllers
{
    public interface ISignalController
    {
        void Handle<T>(T signal) where T : ISignal;
    }
}