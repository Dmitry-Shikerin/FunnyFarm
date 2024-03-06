﻿using System;
using Sources.Frameworks.MVVM.ControllersInterfaces;
using Sources.Frameworks.MVVM.InfrastructureInterfaces.Builders;
using Sources.Frameworks.MVVM.PresentationInterfaces.Factories;
using Sources.Frameworks.MVVM.PresentationInterfaces.Views;

namespace Sources.Frameworks.MVVM.Infrastructure.Builders
{
    public class BindableViewBuilder<TViewModel> : IBindableViewBuilder<TViewModel> where TViewModel : IViewModel
    {
        private readonly IBindableViewFactory _bindableViewFactory;
        private readonly IViewModelFactory<TViewModel> _viewModelFactory;
        private readonly string _viewPath;

        //TODO хочется убрать отсюда зависимость на стринг
        public BindableViewBuilder
        (
            IBindableViewFactory bindableViewFactory,
            IViewModelFactory<TViewModel> viewModelFactory,
            string viewPath
        )
        {
            _bindableViewFactory = bindableViewFactory ??
                                   throw new ArgumentNullException(nameof(bindableViewFactory));
            _viewModelFactory = viewModelFactory ??
                                throw new ArgumentNullException(nameof(viewModelFactory));
            _viewPath = viewPath ?? throw new ArgumentNullException(nameof(viewPath));
        }

        public IBindableView Build(int entityId, string prefabName, IBindableView parent = null)
        {
            IViewModel viewModel = _viewModelFactory.Create(entityId);
            IBindableView view = _bindableViewFactory.Create(_viewPath, prefabName);
            
            view.Bind(viewModel);

            return view;
        }
    }
}