using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Client.DomainInterfaces.Entities;
using Sources.Client.InfrastructureInterfaces.Repositories;

namespace Sources.Client.Infrastructure.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private List<IEntity> _entities = new List<IEntity>();
        
        public void Add(IEntity entity)
        {
            if (_entities.Contains(entity))
                throw new AggregateException();
            
            _entities.Add(entity);
        }

        public IEntity Get(int id) => 
            _entities.FirstOrDefault(entity => entity.Id == id) 
            ?? throw new NullReferenceException(id.ToString());
    }
}