using System;
using Sources.Client.Controllers.ViewModels.Uis.GameplayHud.Forms;
using Sources.Client.Domain.Ui.Forms.Gameplay;
using Sources.Client.Infrastructure.Services.IdGenerators;
using Sources.Client.Infrastructure.Services.Providers;
using Sources.Client.InfrastructureInterfaces.Factories.Domain.Forms.Gameplay;
using Sources.Client.InfrastructureInterfaces.Services.Providers;
using Sources.Client.Presentations.Containers.Ui;
using Sources.Client.UseCases.Queries.Ui.Forms;
using Sources.Client.UseCases.Queries.Ui.Forms.Gameplay;
using Sources.Frameworks.MVVM.ControllersInterfaces;
using Sources.Frameworks.MVVM.InfrastructureInterfaces.Builders;
using Sources.Frameworks.MVVM.PresentationInterfaces.Factories;
using Sources.Frameworks.MVVM.PresentationInterfaces.Views;

namespace Sources.Client.Infrastructure.Factories.Services.FormServices
{
    public class GameplayFormServiceFactory
    {
        private readonly FormService _formService;
        private readonly GameplayHud _gameplayHud;
        private readonly IViewModelFactory<HudFormViewModel> _hudFormViewModelFactory;
        private readonly IViewModelFactory<PauseFormViewModel> _pauseFormViewModelFactory;
        private readonly CreateHudFormQuery _createHudFormQuery;
        private readonly CreatePauseFormQuery _createPauseFormQuery;
        private readonly IBindableViewBuilder<HudFormViewModel> _hudFormBindableViewBuilder;
        private readonly IBindableViewBuilder<PauseFormViewModel> _pauseFormBindableViewBuilder;

        public GameplayFormServiceFactory
        (
            FormService formService,
            GameplayHud gameplayHud,
            CreateHudFormQuery createHudFormQuery,
            CreatePauseFormQuery createPauseFormQuery,
            IBindableViewBuilder<HudFormViewModel> hudFormBindableViewBuilder,
            IBindableViewBuilder<PauseFormViewModel> pauseFormBindableViewBuilder
        )
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
            _createHudFormQuery = createHudFormQuery ?? throw new ArgumentNullException(nameof(createHudFormQuery));
            _createPauseFormQuery =
                createPauseFormQuery ?? throw new ArgumentNullException(nameof(createPauseFormQuery));
            _hudFormBindableViewBuilder = hudFormBindableViewBuilder ?? throw new ArgumentNullException(nameof(hudFormBindableViewBuilder));
            _pauseFormBindableViewBuilder = pauseFormBindableViewBuilder ?? throw new ArgumentNullException(nameof(pauseFormBindableViewBuilder));
        }

        public IFormService Create()
        {
            //TODO чепуха принимать сюда сервис и выдавать его наружу
            int hudFormId = _createHudFormQuery.Handle();
            _hudFormBindableViewBuilder.Build(hudFormId, _gameplayHud.HudFormBindableView);
            _formService.Register<HudForm>(hudFormId);

            int pauseFormId = _createPauseFormQuery.Handle();
            _pauseFormBindableViewBuilder.Build(pauseFormId, _gameplayHud.PauseFormBindableView);
            _formService.Register<PauseForm>(pauseFormId);

            return _formService;
        }
    }
}