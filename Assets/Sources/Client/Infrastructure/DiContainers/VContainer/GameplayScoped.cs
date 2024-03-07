using Sources.Client.Controllers.Actions.Players;
using Sources.Client.Controllers.ViewModels;
using Sources.Client.Controllers.ViewModels.Players;
using Sources.Client.Infrastructure.Factories.Controllers.SignalControllers;
using Sources.Client.Infrastructure.Factories.Controllers.ViewModels;
using Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Components;
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
using Sources.Client.UseCases.Common.Components.LookDirection.Commands;
using Sources.Client.UseCases.Common.Components.Positions.Commands;
using Sources.Client.UseCases.Common.Components.Positions.Queries;
using Sources.Client.UseCases.Common.Components.Speeds.Commands;
using Sources.Client.UseCases.Common.Components.Speeds.Queries;
using Sources.Client.UseCases.Queries.Players;
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
            builder.Register<GameplaySceneFactory>(Lifetime.Singleton);
            builder.Register<GamePlaySceneViewFactory>(Lifetime.Singleton);

            builder.Register<IInputService, InputService>(Lifetime.Singleton);

            builder.Register<IEntityRepository, EntityRepository>(Lifetime.Singleton);
            builder.RegisterInstance<IIdGenerator, IdGenerator>(new IdGenerator(10));

            builder.Register<IBinder, Binder>(Lifetime.Singleton);
            builder.Register<IBindableViewFactory, BindableViewFactory>(Lifetime.Singleton);

            builder.Register<ISignalBus, SignalBus>(Lifetime.Singleton);
            builder
                .Register<SignalHandler>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();

            builder.Register<MovePositionCommand>(Lifetime.Transient);
            builder.Register<SetLookDirectionCommand>(Lifetime.Transient);
            builder.Register<SetSpeedCommand>(Lifetime.Transient);

            builder.Register<LookDirectionViewModelComponentFactory>(Lifetime.Transient);
            builder.Register<CharacterControllerMovementViewModelComponentFactory>(Lifetime.Transient);
            
            RegisterPlayer(builder);
        }

        private void RegisterPlayer(IContainerBuilder builder)
        {
            builder.Register<PlayerMovementServiceFactory>(Lifetime.Singleton);

            builder
                .Register<CurrentPlayerService>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();

            builder.Register<IPlayerFactory, PlayerFactory>(Lifetime.Singleton);
            builder.Register<IViewModelFactory<PlayerViewModel>,
                PlayerViewModelFactory>(Lifetime.Singleton);

            builder.Register<PlayerSignalControllerFactory>(Lifetime.Singleton);
            builder.Register<CreateCurrentCharacterQuery>(Lifetime.Singleton);

            builder.Register<CreatePlayerSignalAction>(Lifetime.Transient);
            builder.Register<PlayerMoveSignalAction>(Lifetime.Transient);
            builder.Register<PlayerRotateSignalAction>(Lifetime.Transient);
            builder.Register<PlayerSpeedSignalAction>(Lifetime.Transient);
        }
    }
}