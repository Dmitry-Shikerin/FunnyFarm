using Sources.Client.Domain.Players;
using UnityEngine;

namespace Sources.Client.InfrastructureInterfaces.Factories.Domain
{
    public interface IPlayerFactory
    {
        Player Create(int id, Vector3 spawnPosition);
    }
}