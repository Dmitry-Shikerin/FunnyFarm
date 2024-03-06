using Sources.Client.Controllers.ViewModels;
using Sources.Client.Controllers.ViewModels.Players;
using Sources.Client.Infrastructure.Factories.Controllers.ViewModels;
using Sources.Client.Infrastructure.Factories.Scenes;
using Sources.Client.Infrastructure.Factories.Views.Scenes;
using Sources.Client.Infrastructure.Repositories;
using Sources.Client.Infrastructure.Services.IdGenerators;
using Sources.Client.InfrastructureInterfaces.Repositories;
using Sources.Frameworks.MVVM.InfrastructureInterfaces.Builders;
using Sources.Frameworks.MVVM.Presentation.Binders;
using Sources.Frameworks.MVVM.Presentation.Factories;
using Sources.Frameworks.MVVM.PresentationInterfaces.Binder;
using Sources.Frameworks.MVVM.PresentationInterfaces.Factories;
using VContainer;
using VContainer.Unity;

namespace Sources.Client.Infrastructure.DiContainers
{
    public class GameplayScoped : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameplaySceneFactory>(Lifetime.Singleton);
            builder.Register<GamePlaySceneViewFactory>(Lifetime.Singleton);

            builder.Register<IEntityRepository, EntityRepository>(Lifetime.Singleton);
            builder.Register<IIdGenerator, IdGenerator>(Lifetime.Singleton);

            builder.Register<IBinder, Binder>(Lifetime.Singleton);
            builder.Register<IBindableViewFactory, BindableViewFactory>(Lifetime.Singleton);
            
            builder.Register<IViewModelFactory<PlayerViewModel>, 
                MovementViewModelFactory>(Lifetime.Singleton);
            
        }
    }
}