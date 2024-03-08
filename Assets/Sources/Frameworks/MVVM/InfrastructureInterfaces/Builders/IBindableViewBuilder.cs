﻿using Sources.Frameworks.MVVM.ControllersInterfaces;
using Sources.Frameworks.MVVM.Presentation.Views;
using Sources.Frameworks.MVVM.PresentationInterfaces.Views;

namespace Sources.Frameworks.MVVM.InfrastructureInterfaces.Builders
{
    public interface IBindableViewBuilder<TViewModel> where TViewModel : IViewModel
    {
        //TODO сделать такойже класс только с дженериком модели и без энтити
        IBindableView Build(int entityId,string viewPath, string prefabName,  IBindableView parent = null);
        public IBindableView Build(int entityId, BindableView bindableView, IBindableView parent = null);
    }
}