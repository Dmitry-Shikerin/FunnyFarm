using Sources.Client.Infrastructure.Factories.Scenes;
using VContainer;
using VContainer.Unity;

namespace Sources.Client.Infrastructure.DiContainers
{
    public class GameplayScoped : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameplaySceneFactory>(Lifetime.Singleton);
            
        }
    }
}