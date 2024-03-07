using Sources.Client.Domain.Components;
using Sources.Client.InfrastructureInterfaces.Repositories;
using Sources.Frameworks.LiveData;

namespace Sources.Client.UseCases.Common.Components.Visibilities.Queries
{
    public class GetVisibilityQuery : ComponentUseCaseBase<VisibilityComponent>
    {
        public GetVisibilityQuery(IEntityRepository entityRepository) : base(entityRepository)
        {
        }

        public LiveData<bool> Handle(int id) => 
            GetComponent(id).IsVisible;
    }
}