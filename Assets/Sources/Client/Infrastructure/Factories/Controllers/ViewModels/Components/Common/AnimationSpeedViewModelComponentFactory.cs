using System;
using Sources.Client.Controllers.ViewModels.Components;
using Sources.Client.UseCases.Common.Components.Speeds.Queries;
using Sources.Frameworks.MVVM.ControllersInterfaces.Components;

namespace Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Components.Common
{
    public class AnimationSpeedViewModelComponentFactory
    {
        private readonly GetSpeedQuery _getSpeedQuery;

        public AnimationSpeedViewModelComponentFactory(GetSpeedQuery getSpeedQuery)
        {
            _getSpeedQuery = getSpeedQuery ?? throw new ArgumentNullException(nameof(getSpeedQuery));
        }

        public IViewModelComponent Create(int id)
        {
            return new AnimationSpeedViewModelComponent(id, _getSpeedQuery);
        }
    }
}