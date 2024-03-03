using Cysharp.Threading.Tasks;
using Sources.ControllersInterfaces.Scenes;

namespace Sources.Infrastructure.Factories.Scenes
{
    public interface ISceneFactory
    {
        UniTask<IScene> Create(object payload);
    }
}