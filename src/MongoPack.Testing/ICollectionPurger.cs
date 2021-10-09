using ProjectsCore.Models;
using System.Threading.Tasks;

namespace MongoPack.Testing
{
    public interface ICollectionPurger<TKey, TEntity> 
        where TKey : struct
        where TEntity : IEntity<TKey>
    {
        Task Purge();
    }
}
 