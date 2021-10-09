using MongoPack.Interrfaces;
using ProjectsCore.Models;
using ProjectsCore.Persistence;
using System.Threading.Tasks;

namespace MongoPack
{
    public class Repository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TKey : struct
        where TEntity : IEntity<TKey>
    {
        private readonly ICollectionNamerResolver resolver;

        public Repository(ICollectionNamerResolver resolver)
        {
            this.resolver = resolver ?? throw new System.ArgumentNullException(nameof(resolver));
        }

        public Task<TEntity> Get(TKey key)
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> Insert(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> Remove(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
