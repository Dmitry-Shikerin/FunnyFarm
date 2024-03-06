using System;
using Sources.Client.Domain.Players;
using Sources.Client.Infrastructure.Services.IdGenerators;

namespace Sources.Client.Infrastructure.Factories.Views.Scenes
{
    public class GamePlaySceneViewFactory
    {
        private readonly IIdGenerator _idGenerator;

        public GamePlaySceneViewFactory
        (
            IIdGenerator idGenerator
        )
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
        }

        public void Create()
        {

            int movementId = _idGenerator.GetId();
            Player player = new Player(movementId);
            
            
        }
    }
}