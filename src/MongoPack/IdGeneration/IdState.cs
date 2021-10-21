using System;

namespace MongoPack.IdGeneration
{
    public abstract class IdState<T> where T : struct
    {
        public string Id { get; protected set; }

        public T Value { get; protected set; }

        protected IdState() { }

        protected IdState(Type type)
        {
            this.Id = type.Name;
        }

        protected IdState(string typeName)
        {
            this.Id = typeName;
        }

        public abstract T Tick();
    }
}
