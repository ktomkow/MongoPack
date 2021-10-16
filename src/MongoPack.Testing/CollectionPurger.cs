using MongoDB.Bson;
using MongoDB.Driver;
using MongoPack.Interrfaces;
using System;
using System.Threading.Tasks;

namespace MongoPack.Testing
{
    public class CollectionPurger : ICollectionPurger
    {
        private readonly IMongoDatabase db;

        public CollectionPurger(IDbFactory dbFactory)
        {
            this.db = dbFactory.Create();
        }

        public Task Purge()
        {
            throw new NotImplementedException();
        }

        public async Task Purge(string collection)
        {
            var dbCollection = db.GetCollection<object>(collection);
            await dbCollection.DeleteManyAsync(new BsonDocument());
        }
    }
}
