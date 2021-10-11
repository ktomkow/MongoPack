using System;

namespace MongoPack.Interrfaces
{
    public interface ICollectionNameResolver
    {
        string Resolve(object @object);

        string Resolve(Type type);
    }
}
