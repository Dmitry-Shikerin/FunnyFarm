using System;
using Sources.Client.Controllers.ViewModels.Components;
using Sources.Client.InfrastructureInterfaces.Repositories;
using Sources.Client.UseCases.Common.Components.Visibilities.Queries;
using Sources.Frameworks.MVVM.ControllersInterfaces.Components;

namespace Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class VisibilityViewModelComponentFactory
    {
        private readonly GetVisibilityQuery _getVisibilityQuery;
        private readonly IEntityRepository _entityRepository;

        public VisibilityViewModelComponentFactory
        (
            GetVisibilityQuery getVisibilityQuery
        )
        {
            _getVisibilityQuery = getVisibilityQuery ?? 
                                  throw new ArgumentNullException(nameof(getVisibilityQuery));
        }

        public IViewModelComponent Create(int id)
        {
            return new VisibilityViewModelComponent(id, _getVisibilityQuery);
        }
    }
}