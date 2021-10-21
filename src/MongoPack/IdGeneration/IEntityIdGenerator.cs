using System;
using System.Threading.Tasks;

namespace MongoPack.IdGeneration
{
    public interface IEntityIdGenerator<TKey>
        where TKey : struct
    {
        Task<TKey> Generate(Type type);
    }
}