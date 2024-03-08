using Sirenix.OdinInspector;
using Sources.Client.Controllers.Actions.Players;
using Sources.Client.Controllers.ViewModels.Players;
using Sources.Client.Controllers.ViewModels.Uis.GameplayHud.Forms;
using Sources.Client.Infrastructure.Factories.Controllers.ContextStateMachines;
using Sources.Client.Infrastructure.Factories.Controllers.SignalControllers;
using Sources.Client.Infrastructure.Factories.Controllers.ViewModels;
using Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Components;
using Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Components.Common;
using Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Components.Uis.Gameplay;
using Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Uis.Gameplay;
using Sources.Client.Infrastructure.Factories.Domain;
using Sources.Client.Infrastructure.Factories.Domain.Forms.Gameplay;
using Sources.Client.Infrastructure.Factories.Scenes;
using Sources.Client.Infrastructure.Factories.Services;
using Sources.Client.Infrastructure.Factories.Services.FormServices;
using Sources.Client.Infrastructure.Factories.Views.Scenes;
using Sources.Client.Infrastructure.Repositories;
using Sources.Client.Infrastructure.Services.CurrentPlayers;
using Sources.Client.Infrastructure.Services.IdGenerators;
using Sources.Client.Infrastructure.Services.InputServices;
using Sources.Client.Infrastructure.Services.Providers;
using Sources.Client.Infrastructure.Services.UpdateServices;
using Sources.Client.InfrastructureInterfaces.Factories.Domain;
using Sources.Client.InfrastructureInterfaces.Factories.Domain.Forms.Gameplay;
using Sources.Client.InfrastructureInterfaces.Repositories;
using Sources.Client.InfrastructureInterfaces.Services.InputServices;
using Sources.Client.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Client.Presentations.Containers.Ui;
using Sources.Client.UseCases.Common.Components.LookDirection.Commands;
using Sources.Client.UseCases.Common.Components.Positions.Commands;
using Sources.Client.UseCases.Common.Components.Positions.Queries;
using Sources.Client.UseCases.Common.Components.Speeds.Commands;
using Sources.Client.UseCases.Common.Components.Speeds.Queries;
using Sources.Client.UseCases.Common.Components.Visibilities.Commands;
using Sources.Client.UseCases.Common.Components.Visibilities.Queries;
using Sources.Client.UseCases.Queries.Players;
using Sources.Client.UseCases.Queries.Ui.Forms.Gameplay;
using Sources.Frameworks.MVVM.Infrastructure.Builders;
using Sources.Frameworks.MVVM.InfrastructureInterfaces.Builders;
using Sources.Frameworks.MVVM.Presentation.Binders;
using Sources.Frameworks.MVVM.Presentation.Factories;
using Sources.Frameworks.MVVM.PresentationInterfaces.Binder;
using Sources.Frameworks.MVVM.PresentationInterfaces.Factories;
using Sources.Frameworks.SignalBuses.Implementation;
using Sources.Frameworks.SignalBuses.Interfaces;
using UnityEngine;
using Zenject;
using SignalBus = Sources.Frameworks.SignalBuses.Implementation.SignalBus;

namespace Sources.Client.Infrastructure.DiContainers.Zenject
{
    public class GameplayInstaller : MonoInstaller
    {
        [Required][SerializeField] private GameplayHud _gameplayHud;
        
        public override void InstallBindings()
        {
            Container.Bind<GameplaySceneFactory>().AsSingle();
            Container.Bind<GamePlaySceneViewFactory>().AsSingle();

            Container.Bind<GameplayHud>().FromInstance(_gameplayHud);
            
            Container.Bind<IInputService>().To<InputService>().AsSingle();
            Container.Bind<IUpdateService>().To<UpdateService>().AsSingle();

            Container.Bind<IEntityRepository>().To<EntityRepository>().AsSingle();
            Container.Bind<IIdGenerator>().To<IdGenerator>()
                .FromInstance(new IdGenerator(10)).AsSingle();

            Container.Bind<IBinder>().To<Binder>().AsSingle();
            Container.Bind<IBindableViewFactory>().To<BindableViewFactory>().AsSingle();

            Container.Bind<ISignalBus>().To<SignalBus>().AsSingle();
            Container.BindInterfacesAndSelfTo<SignalHandler>().AsSingle();

            //TODO зарегистрировать все Запросы
            //TODO порефакторить проэкт
            Container.Bind<GetVisibilityQuery>().AsTransient();
            Container.Bind<GetPositionQuery>().AsTransient();
            Container.Bind<GetSpeedQuery>().AsTransient();
            
            Container.Bind<MovePositionCommand>().AsTransient();
            Container.Bind<SetLookDirectionCommand>().AsTransient();
            Container.Bind<SetSpeedCommand>().AsTransient();
            Container.Bind<HideCommand>().AsTransient();
            Container.Bind<ShowCommand>().AsTransient();

            Container.Bind<LookDirectionViewModelComponentFactory>().AsSingle();
            Container.Bind<CharacterControllerMovementViewModelComponentFactory>().AsSingle();
            Container.Bind<VisibilityViewModelComponentFactory>().AsSingle();
            Container.Bind<AnimationSpeedViewModelComponentFactory>().AsSingle();

            BindPlayer();
            BindForms();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerMovementServiceFactory>().AsSingle();
            Container.Bind<PlayerMovementStateMachineFactory>().AsSingle();
            
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

        private void BindForms()
        {
            Container.Bind<IViewModelFactory<HudFormViewModel>>()
                .To<HudFormViewModelFactory>().AsSingle();
            Container.Bind<IViewModelFactory<PauseFormViewModel>>().
                To<PauseFormViewModelFactory>().AsSingle();
            
            Container.Bind<IBindableViewBuilder<HudFormViewModel>>()
                .To<BindableViewBuilder<HudFormViewModel>>().AsSingle();
            Container.Bind<IBindableViewBuilder<PauseFormViewModel>>()
                .To<BindableViewBuilder<PauseFormViewModel>>().AsSingle();

            Container.Bind<IHudFormFactory>().To<HudFormFactory>().AsSingle();
            Container.Bind<IPauseFormFactory>().To<PauseFormFactory>().AsSingle();

            Container.Bind<CreateHudFormQuery>().AsSingle();
            Container.Bind<CreatePauseFormQuery>().AsSingle();
            
            Container.Bind<ShowPauseFormViewModelComponentFactory>().AsSingle();
            Container.Bind<ShowHudFormViewModelComponentFactory>().AsSingle();

            Container.BindInterfacesAndSelfTo<FormService>().AsSingle();
            Container.Bind<GameplayFormServiceFactory>().AsSingle();
        }
    }
}