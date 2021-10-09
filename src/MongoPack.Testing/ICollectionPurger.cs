using ProjectsCore.Models;
using System.Threading.Tasks;

namespace MongoPack.Testing
{
    interface ICollectionPurger<TKey, TEntity> 
        where TKey : struct
        where TEntity : IEntity<TKey>
    {
        Task Purge();
    }
}
 