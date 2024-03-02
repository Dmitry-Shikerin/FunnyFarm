using Cysharp.Threading.Tasks;
using Sources.InfrastructureInterfaces.Services.LifeTimes;
using Sources.InfrastructureInterfaces.Services.Updates;

namespace Sources.InfrastructureInterfaces.Services.SceneService
{
    public interface ISceneService : IUpdatable, IFixedUpdatable, ILateUpdatable, IDisable
    {
        UniTask ChangeSceneAsync(string sceneName, object payload);
    }
}