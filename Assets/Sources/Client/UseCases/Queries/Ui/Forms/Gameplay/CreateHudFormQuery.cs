using System;
using Sources.Client.Domain.Ui.Forms.Gameplay;
using Sources.Client.Infrastructure.Services.IdGenerators;
using Sources.Client.InfrastructureInterfaces.Factories.Domain.Forms.Gameplay;
using Sources.Client.InfrastructureInterfaces.Repositories;

namespace Sources.Client.UseCases.Queries.Ui.Forms.Gameplay
{
    public class CreateHudFormQuery
    {
        private readonly IHudFormFactory _hudFormFactory;
        private readonly IEntityRepository _entityRepository;
        private readonly IIdGenerator _idGenerator;

        public CreateHudFormQuery
        (
            IHudFormFactory hudFormFactory,
            IEntityRepository entityRepository,
            IIdGenerator idGenerator
        )
        {
            _hudFormFactory = hudFormFactory ?? throw new ArgumentNullException(nameof(hudFormFactory));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
        }

        public int Handle()
        {
            int hudFormId = _idGenerator.GetId();
            HudForm hudForm = _hudFormFactory.Create(hudFormId);
            _entityRepository.Add(hudForm);

            return hudFormId;
        }
    }
}