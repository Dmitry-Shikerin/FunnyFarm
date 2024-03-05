using Cysharp.Threading.Tasks;
using Sources.Client.Controllers.Scenes;
using Sources.Controllers.Scenes;
using Sources.ControllersInterfaces.Scenes;
using Sources.Infrastructure.Factories.Scenes;

namespace Sources.Client.Infrastructure.Factories.Scenes
{
    public class GameplaySceneFactory : ISceneFactory
    {
        public async UniTask<IScene> Create(object payload)
        {
            return new GameplayScene();
        }
    }
}