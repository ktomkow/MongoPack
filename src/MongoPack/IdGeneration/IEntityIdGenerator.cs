using ProjectsCore.Models;
using System.Threading.Tasks;

namespace MongoPack.IdGeneration
{
    public interface IEntityIdGenerator<TKey, TEntity>
        where TKey : struct
        where TEntity : IEntity<TKey>
    {
        Task<TKey> Generate();
    }
}