using Sources.Client.Domain.Components;
using Sources.Client.InfrastructureInterfaces.Repositories;
using Sources.Frameworks.LiveData;
using UnityEngine;

namespace Sources.Client.UseCases.Common.Components.LookDirection.Queries
{
    public class GetLookDirectionQuery : ComponentUseCaseBase<LookDirectionComponent>
    {
        public GetLookDirectionQuery(IEntityRepository entityRepository) : base(entityRepository)
        {
        }

        public LiveData<Vector3> Handle(int id) => 
            GetComponent(id).Direction;
    }
}
