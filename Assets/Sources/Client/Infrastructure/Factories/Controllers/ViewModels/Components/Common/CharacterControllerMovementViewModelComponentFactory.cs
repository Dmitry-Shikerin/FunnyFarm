using System;
using Sources.Client.Controllers.ViewModels.Components;
using Sources.Client.InfrastructureInterfaces.Repositories;
using Sources.Client.UseCases.Common.Components.Positions.Commands;
using Sources.Client.UseCases.Common.Components.Positions.Queries;
using Sources.Frameworks.MVVM.ControllersInterfaces.Components;

namespace Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class CharacterControllerMovementViewModelComponentFactory
    {
        private readonly IEntityRepository _entityRepository;

        public CharacterControllerMovementViewModelComponentFactory(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
        }

        public IViewModelComponent Create(int id)
        {
            //TODO переместить в резолвер
            GetPositionQuery getPositionQuery = new GetPositionQuery(_entityRepository);
            SetPositionCommand setPositionCommand = new SetPositionCommand(_entityRepository);

            return new CharacterControllerMovementViewModelComponent(id, getPositionQuery, setPositionCommand);
        }
    }
}