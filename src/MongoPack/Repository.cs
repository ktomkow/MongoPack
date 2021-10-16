using MongoDB.Bson;
using MongoDB.Driver;
using MongoPack.Interrfaces;
using ProjectsCore.Models;
using ProjectsCore.Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MongoPack
{
    public class Repository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TKey : struct
        where TEntity : IEntity<TKey>
    {
        private readonly ICollectionNameResolver resolver;
        private readonly IMongoClient dbClient;
        private readonly IMongoDatabase db;

        public Repository(ICollectionNameResolver resolver)
        {
            this.resolver = resolver ?? throw new System.ArgumentNullException(nameof(resolver));

            this.dbClient = new MongoClient("mongodb://192.168.0.133:3099");
            this.db = this.dbClient.GetDatabase("test");
        }

        public Task<TEntity> Get(TKey key)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            var result = this.GetCollection().AsQueryable();

            return await Task.FromResult(result.AsQueryable());
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            var collection = this.GetCollection();
            await collection.InsertOneAsync(entity);

            return entity;
        }

        public Task<TEntity> Remove(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public IMongoCollection<TEntity> GetCollection()
        {
            string collectionName = this.resolver.Resolve(typeof(TEntity));
            var collection = this.db.GetCollection<TEntity>(collectionName);

            return collection;
        }
    }
}
