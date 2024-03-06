using Sources.Client.Controllers.ViewModels;
using Sources.Client.Controllers.ViewModels.Players;
using Sources.Client.Infrastructure.Factories.Controllers.SignalControllers;
using Sources.Client.Infrastructure.Factories.Controllers.ViewModels;
using Sources.Client.Infrastructure.Factories.Domain;
using Sources.Client.Infrastructure.Factories.Scenes;
using Sources.Client.Infrastructure.Factories.Services;
using Sources.Client.Infrastructure.Factories.Views.Scenes;
using Sources.Client.Infrastructure.Repositories;
using Sources.Client.Infrastructure.Services.CurrentPlayers;
using Sources.Client.Infrastructure.Services.IdGenerators;
using Sources.Client.Infrastructure.Services.InputServices;
using Sources.Client.Infrastructure.Services.MovementService;
using Sources.Client.InfrastructureInterfaces.Factories.Domain;
using Sources.Client.InfrastructureInterfaces.Repositories;
using Sources.Client.InfrastructureInterfaces.Services.CurrentPlayers;
using Sources.Client.InfrastructureInterfaces.Services.InputServices;
using Sources.Client.InfrastructureInterfaces.Services.MovementServices;
using Sources.Client.UseCases.Common.Components.Positions.Queries;
using Sources.Client.UseCases.Common.Components.Speeds.Queries;
using Sources.Frameworks.MVVM.InfrastructureInterfaces.Builders;
using Sources.Frameworks.MVVM.Presentation.Binders;
using Sources.Frameworks.MVVM.Presentation.Factories;
using Sources.Frameworks.MVVM.PresentationInterfaces.Binder;
using Sources.Frameworks.MVVM.PresentationInterfaces.Factories;
using Sources.Frameworks.SignalBuses.Implementation;
using Sources.Frameworks.SignalBuses.Interfaces;
using VContainer;
using VContainer.Unity;

namespace Sources.Client.Infrastructure.DiContainers
{
    public class GameplayScoped : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            //TODO потестить VContainer
            builder.Register<IInputService, InputService>(Lifetime.Singleton);
            // builder.Register<IPlayerMovementService, PlayerMovementService>(Lifetime.Singleton);
            builder.Register<PlayerMovementServiceFactory>(Lifetime.Singleton);

            builder.Register<IEntityRepository, EntityRepository>(Lifetime.Singleton);
            builder.Register<IIdGenerator, IdGenerator>(Lifetime.Singleton);

            builder.Register<GamePlaySceneViewFactory>(Lifetime.Singleton);
            builder.Register<GameplaySceneFactory>(Lifetime.Singleton);

            builder.Register<IBinder, Binder>(Lifetime.Singleton);
            builder.Register<IBindableViewFactory, BindableViewFactory>(Lifetime.Singleton);

            builder.Register<ISignalBus, SignalBus>(Lifetime.Singleton);
            builder
                .Register<SignalHandler>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();

            //TODO сработает ли?
            builder
                .Register<CurrentPlayerService>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();
            //TODO или
            // builder.Register<CurrentPlayerService>(Lifetime.Singleton).As<ICurrentPlayerService>();

            builder.Register<IPlayerFactory, PlayerFactory>(Lifetime.Singleton);
            builder.Register<IViewModelFactory<PlayerViewModel>,
                PlayerViewModelFactory>(Lifetime.Singleton);

            builder.Register<PlayerSignalControllerFactory>(Lifetime.Singleton);

            //TODO будут ли это новые экземпляры?
            // builder.Register<GetPositionQuery>(Lifetime.Transient);
            // builder.Register<GetSpeedQuery>(Lifetime.Transient);
        }
    }
}