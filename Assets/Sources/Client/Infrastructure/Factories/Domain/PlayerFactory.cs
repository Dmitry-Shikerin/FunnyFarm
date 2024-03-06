using Sources.Client.Domain.Players;
using Sources.Client.InfrastructureInterfaces.Factories.Domain;

namespace Sources.Client.Infrastructure.Factories.Domain
{
    public class PlayerFactory : IPlayerFactory
    {
        public Player Create(int id)
        {
            //TODO додклать
            return new Player(1);
        }
    }
}