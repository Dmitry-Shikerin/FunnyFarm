using System;
using Sources.Client.Domain.Ui.Forms.Gameplay;
using Sources.Client.Infrastructure.Services.IdGenerators;
using Sources.Client.InfrastructureInterfaces.Factories.Domain.Forms.Gameplay;
using Sources.Client.InfrastructureInterfaces.Repositories;

namespace Sources.Client.UseCases.Queries.Ui.Forms.Gameplay
{
    public class CreatePauseFormQuery
    {
        private readonly IPauseFormFactory _pauseFormFactory;
        private readonly IEntityRepository _entityRepository;
        private readonly IIdGenerator _idGenerator;

        public CreatePauseFormQuery
        (
            IPauseFormFactory pauseFormFactory,
            IEntityRepository entityRepository,
            IIdGenerator idGenerator
        )
        {
            _pauseFormFactory = pauseFormFactory ?? throw new ArgumentNullException(nameof(pauseFormFactory));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
        }

        public int Handle()
        {
            int hudFormId = _idGenerator.GetId();
            PauseForm pauseForm = _pauseFormFactory.Create(hudFormId);
            _entityRepository.Add(pauseForm);

            return hudFormId;
        }
    }
}