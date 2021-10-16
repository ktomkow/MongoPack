using MongoDB.Driver;
using MongoPack.Interrfaces;

namespace MongoPack.Implementations
{
    public class DbFactory : IDbFactory
    {
        private readonly MongoDbSettings settings;

        public DbFactory(MongoDbSettings settings)
        {
            this.settings = settings;
        }

        public IMongoDatabase Create()
        {
            var dbClient = new MongoClient(settings.ConnectionString);
            var db = dbClient.GetDatabase(settings.DbName);

            return db;
        }
    }
}
