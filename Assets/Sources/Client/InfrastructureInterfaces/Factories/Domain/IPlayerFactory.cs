using Sources.Client.Domain.Players;

namespace Sources.Client.InfrastructureInterfaces.Factories.Domain
{
    public interface IPlayerFactory
    {
        Player Create(int id);
    }
}