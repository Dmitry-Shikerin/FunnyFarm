using System;
using Sources.Client.Domain.Composites;
using Sources.Client.DomainInterfaces.Composite.Components;
using Sources.Client.DomainInterfaces.Entities;
using Sources.Client.InfrastructureInterfaces.Repositories;

namespace Sources.Client.UseCases.Common.Components
{
    public class ComponentUseCaseBase<T> where T : IComponent
    {
        private readonly IEntityRepository _entityRepository;

        public ComponentUseCaseBase(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
        }

        protected T GetComponent(int id)
        {
            IEntity entity = _entityRepository.Get(id);

            if (entity is not Composite composite)
                throw new NullReferenceException(nameof(entity));

            if (composite.TryGetComponent(out T component) == false)
                throw new NullReferenceException(nameof(component));

            return component;
        }
    }
}