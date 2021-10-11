using MongoPack.Interrfaces;
using System;

namespace MongoPack.Implementations
{
    public class DefaultCollectionNameResolver : ICollectionNameResolver
    {
        public string Resolve(object @object)
        {
            return @object.GetType().Name;
        }

        public string Resolve(Type type)
        {
            return type.Name;
        }
    }
}
