using System;
using Sources.Client.Controllers.ViewModels.Components;
using Sources.Client.InfrastructureInterfaces.Repositories;
using Sources.Client.UseCases.Common.Components.LookDirection.Queries;
using Sources.Frameworks.MVVM.ControllersInterfaces.Components;

namespace Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Components
{
    //TODO сделать интерфейс для этих фабрик?
    public class LookDirectionViewModelComponentFactory
    {
        private readonly IEntityRepository _entityRepository;

        public LookDirectionViewModelComponentFactory(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
        }

        public IViewModelComponent Create(int id)
        {
            //TODO вынести в резолвер
            GetLookDirectionQuery getLookDirectionQuery = new GetLookDirectionQuery(_entityRepository);

            return new LookDirectionViewModelComponent(id, getLookDirectionQuery);
        }
    }
}