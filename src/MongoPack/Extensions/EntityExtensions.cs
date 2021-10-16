using ProjectsCore.Models;
using System;

namespace MongoPack.Extensions
{
    internal static class EntityExtensions
    {
        internal static void SetId<TKey, TEntity>(this TEntity entity, TKey key ) where TKey : struct where TEntity : Entity<TKey>
        {
            Type entityType = entity.GetType();
            var setter = entityType.GetField("id", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            setter.SetValue(entity, key);
        }

        internal static void SetIdOnEntity<TKey, TEntity>(this TEntity entity, TKey key) where TKey : struct where TEntity : IEntity<TKey>
        {
            Type entityType = entity.GetType();
            var setter = entityType.GetField("id", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            setter.SetValue(entity, key);
        }
    }
}
