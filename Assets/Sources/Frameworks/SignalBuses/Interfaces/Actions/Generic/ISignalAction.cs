using Sources.Frameworks.SignalBuses.Interfaces.Signals;

namespace Sources.Frameworks.SignalBuses.Interfaces.Actions.Generic
{
    public interface ISignalAction<in T> : ISignalAction where T : ISignal
    {
        void Handle(T signal);
    }
}