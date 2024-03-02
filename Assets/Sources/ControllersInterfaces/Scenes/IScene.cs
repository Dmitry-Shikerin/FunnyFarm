using Sources.InfrastructureInterfaces.StateMachines.SceneStateMachines.States;

namespace Sources.ControllersInterfaces.Scenes
{
    public interface IScene : IState
    {
        public string Name { get; }
    }
}