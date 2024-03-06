using Sources.Frameworks.SignalBuses.Interfaces.Signals;

namespace Sources.Frameworks.SignalBuses.Interfaces
{
    public interface ISignalHandler
    {
        void Handle<T>(T signal) where T : ISignal;
    }
}