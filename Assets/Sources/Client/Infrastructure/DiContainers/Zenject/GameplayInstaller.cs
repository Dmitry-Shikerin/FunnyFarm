using Sources.Client.Controllers.Actions.Players;
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
using Sources.Client.InfrastructureInterfaces.Factories.Domain;
using Sources.Client.InfrastructureInterfaces.Repositories;
using Sources.Client.InfrastructureInterfaces.Services.InputServices;
using Sources.Client.UseCases.Common.Components.LookDirection.Commands;
using Sources.Client.UseCases.Common.Components.Positions.Commands;
using Sources.Client.UseCases.Common.Components.Speeds.Commands;
using Sources.Client.UseCases.Common.Components.Visibilities.Queries;
using Sources.Client.UseCases.Queries.Players;
using Sources.Frameworks.MVVM.Infrastructure.Builders;
using Sources.Frameworks.MVVM.InfrastructureInterfaces.Builders;
using Sources.Frameworks.MVVM.Presentation.Binders;
using Sources.Frameworks.MVVM.Presentation.Factories;
using Sources.Frameworks.MVVM.PresentationInterfaces.Binder;
using Sources.Frameworks.MVVM.PresentationInterfaces.Factories;
using Sources.Frameworks.SignalBuses.Implementation;
using Sources.Frameworks.SignalBuses.Interfaces;
using Zenject;
using SignalBus = Sources.Frameworks.SignalBuses.Implementation.SignalBus;

namespace Sources.Client.Infrastructure.DiContainers.Zenject
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameplaySceneFactory>().AsSingle();
            Container.Bind<GamePlaySceneViewFactory>().AsSingle();
            
            Container.Bind<IInputService>().To<InputService>().AsSingle();

            Container.Bind<IEntityRepository>().To<EntityRepository>().AsSingle();
            Container.Bind<IIdGenerator>().To<IdGenerator>()
                .FromInstance(new IdGenerator(10)).AsSingle();

            Container.Bind<IBinder>().To<Binder>().AsSingle();
            Container.Bind<IBindableViewFactory>().To<BindableViewFactory>().AsSingle();

            Container.Bind<ISignalBus>().To<SignalBus>().AsSingle();
            Container.BindInterfacesAndSelfTo<SignalHandler>().AsSingle();

            //TODO зарегистрировать все Запросы
            Container.Bind<GetVisibilityQuery>().AsTransient();
            
            Container.Bind<MovePositionCommand>().AsTransient();
            Container.Bind<SetLookDirectionCommand>().AsTransient();
            Container.Bind<SetSpeedCommand>().AsTransient();

            Container.Bind<LookDirectionViewModelComponentFactory>().AsSingle();
            Container.Bind<CharacterControllerMovementViewModelComponentFactory>().AsSingle();
            Container.Bind<VisibilityViewModelComponentFactory>().AsSingle();

            BindPlayer();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerMovementServiceFactory>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<CurrentPlayerService>().AsSingle();

            Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();
            
            Container.Bind<IViewModelFactory<PlayerViewModel>>()
                .To<PlayerViewModelFactory>().AsSingle();

            Container.Bind<PlayerSignalControllerFactory>().AsSingle();

            Container.Bind<IBindableViewBuilder<PlayerViewModel>>()
                .To<BindableViewBuilder<PlayerViewModel>>().AsSingle();
            
            Container.Bind<CreateCurrentCharacterQuery>().AsSingle();

            //TODO добавить висибилити компонент на игрока
            //TODO нужныли они AsTransient?
            Container.Bind<CreatePlayerSignalAction>().AsSingle();
            Container.Bind<PlayerMoveSignalAction>().AsSingle();
            Container.Bind<PlayerRotateSignalAction>().AsSingle();
            Container.Bind<PlayerSpeedSignalAction>().AsSingle();
        }
    }
}