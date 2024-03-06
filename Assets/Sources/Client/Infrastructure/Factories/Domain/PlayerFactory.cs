using Sources.Client.Domain.Components;
using Sources.Client.Domain.Players;
using Sources.Client.InfrastructureInterfaces.Factories.Domain;
using UnityEngine;

namespace Sources.Client.Infrastructure.Factories.Domain
{
    public class PlayerFactory : IPlayerFactory
    {
        public Player Create(int id, Vector3 spawnPosition)
        {
            Player player = new Player(id);

            player.AddComponent(new LookDirectionComponent(Vector3.zero));
            player.AddComponent(new PositionComponent(spawnPosition));
            player.AddComponent(new SpeedComponent(10f)); //TODO вынести в конфиг
            
            return player;
        }
    }
}