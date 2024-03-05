using Sources.ControllersInterfaces.Scenes;

namespace Sources.Client.Controllers.Scenes
{
    public class GameplayScene : IScene
    {
        public GameplayScene()
        {
        }

        public string Name { get; }

        public void Enter(object payload)
        {
        }

        public void Exit()
        {
        }

        public void Update(float deltaTime)
        {
        }

        public void UpdateLate(float deltaTime)
        {
        }

        public void UpdateFixed(float fixedDeltaTime)
        {
        }
    }
}