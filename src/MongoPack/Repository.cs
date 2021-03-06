using MongoDB.Bson;
using MongoDB.Driver;
using MongoPack.Extensions;
using MongoPack.IdGeneration;
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
        where TEntity : Entity<TKey>
    {
        private readonly ICollectionNameResolver resolver;
        private readonly IEntityIdGenerator<TKey> idGenerator;
        private readonly IMongoDatabase db;

        public Repository(
            IDbFactory dbFactory,
            ICollectionNameResolver resolver, 
            IEntityIdGenerator<TKey> idGenerator)
        {
            this.resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            this.idGenerator = idGenerator;
            this.db = dbFactory.Create();
        }

        public Task<TEntity> Get(TKey key)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            var result = this.GetCollection().AsQueryable();

            return await Task.FromResult(result.AsQueryable());
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            var collection = this.GetCollection();

            TKey id = await idGenerator.Generate(typeof(TEntity));
            entity.SetId(id);

            await collection.InsertOneAsync(entity);

            return entity;
        }

        public Task<TEntity> Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IMongoCollection<TEntity> GetCollection()
        {
            string collectionName = this.resolver.Resolve(typeof(TEntity));
            var collection = this.db.GetCollection<TEntity>(collectionName);

            return collection;
        }
    }
}
