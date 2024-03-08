using System;
using Sources.Client.Domain.Players;
using Sources.Client.Infrastructure.Services.IdGenerators;
using Sources.Client.InfrastructureInterfaces.Factories.Domain;
using Sources.Client.InfrastructureInterfaces.Repositories;
using UnityEngine;

namespace Sources.Client.UseCases.Queries.Players
{
    public class CreateCurrentCharacterQuery
    {
        private readonly IEntityRepository _entityRepository;
        private readonly IPlayerFactory _playerFactory;
        private readonly IIdGenerator _idGenerator;

        public CreateCurrentCharacterQuery
        (
            IEntityRepository entityRepository,
            IPlayerFactory playerFactory,
            IIdGenerator idGenerator
        )
        {
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
        }

        public int Handle(Vector3 spawnPosition)
        {
            int id = _idGenerator.GetId();
            
            Player player = _playerFactory.Create(id, spawnPosition);
            _entityRepository.Add(player);
            
            return id;
        }
    }
}