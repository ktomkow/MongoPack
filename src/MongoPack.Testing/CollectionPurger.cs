using ProjectsCore.Models;
using System;
using System.Threading.Tasks;

namespace MongoPack.Testing
{
    public class CollectionPurger<TKey, TEntity> : ICollectionPurger<TKey, TEntity>
        where TKey : struct
        where TEntity : IEntity<TKey>
    {
        public Task Purge()
        {
            throw new NotImplementedException();
        }
    }
}
