using Sources.Client.InfrastructureInterfaces.Services.CurrentPlayers;
using UnityEngine;

namespace Sources.Client.Infrastructure.Services.CurrentPlayers
{
    //TODO этот сервис для определения ID текущего игрока если игра по сети?
    //TODO можно ли этот сервис зарегестрировать в резолвере?
    public class CurrentPlayerService : ICurrentPlayerService
    {
        private int _characterId;

        public int CharacterId
        {
            get => _characterId;
            set
            {
                _characterId = value;
                Debug.Log($"{nameof(CurrentPlayerService)} {nameof(CharacterId)} {CharacterId}");
            }
        }
    }
}