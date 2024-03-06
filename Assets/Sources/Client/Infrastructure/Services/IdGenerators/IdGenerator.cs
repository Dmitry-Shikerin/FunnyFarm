namespace Sources.Client.Infrastructure.Services.IdGenerators
{
    //TODO для чего разные idGenerator'ы? или он один?
    public class IdGenerator : IIdGenerator
    {
        private int _currentId;
        
        public IdGenerator(int startId)
        {
            _currentId = startId;
        }

        public int GetId() => 
            _currentId++;
    }
}