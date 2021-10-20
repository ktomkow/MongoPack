using MongoDB.Bson;
using MongoDB.Driver;
using MongoPack.Interrfaces;
using ProjectsCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;

namespace MongoPack.IdGeneration
{
    public class EntityIntIdGenerator<TEntity> : IEntityIdGenerator<int, TEntity> where TEntity : IEntity<int>
    {
        private const string CollectionName = "_identifiers";
        private static readonly string EntityTypeName = typeof(TEntity).Name;
        private static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        private readonly IMongoDatabase db;

        public EntityIntIdGenerator(IDbFactory dbFactory)
        {
            this.db = dbFactory.Create();
        }

        public async Task<int> Generate()
        {
            var collection = this.GetCollection();

            var filter = Builders<IntIdState>.Filter.Eq("_id", EntityTypeName);

            await semaphore.WaitAsync();

            List<IntIdState> entities = await (await collection.FindAsync(filter).ConfigureAwait(false)).ToListAsync().ConfigureAwait(false);
            IntIdState idState;

            if (entities.Any() == false)
            {
                idState = new IntIdState();
                await collection.InsertOneAsync(idState).ConfigureAwait(false);

            }
            else if (entities.Count > 1)
            {
                semaphore.Release();
                throw new Exception($"WTF, more than 1 Id container for type: [{EntityTypeName}] ");
            }
            else
            {
                idState = entities.First();
            }

            int result = idState.Tick();
            
            await collection.FindOneAndReplaceAsync(filter, idState).ConfigureAwait(false);

            semaphore.Release();

            return result;
        }

        private IMongoCollection<IntIdState> GetCollection()
        {
            var collection = this.db.GetCollection<IntIdState>(CollectionName);

            return collection;
        }

        private class IntIdState : IdState<int>
        {
            public IntIdState() : base(EntityTypeName) { }

            public override int Tick()
            {
                this.Value++;
                return Value;
            }
        }
    }
}
