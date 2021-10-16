using ProjectsCore.Models;
using System;
using System.Threading.Tasks;

namespace MongoPack.IdGeneration
{
    public class EntityGuidIdGenerator<TEntity> : IEntityIdGenerator<Guid, TEntity> where TEntity : IEntity<Guid>
    {
        public async Task<Guid> Generate()
        {
            Guid guid = Guid.NewGuid();

            return await Task.FromResult(guid);
        }
    }
}
