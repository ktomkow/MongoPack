using MongoPack.Interrfaces;

namespace MongoPack.Implementations
{
    public class DefaultCollectionNameResolver : ICollectionNamerResolver
    {
        public string Resolve(object @object)
        {
            return @object.GetType().Name;
        }
    }
}
