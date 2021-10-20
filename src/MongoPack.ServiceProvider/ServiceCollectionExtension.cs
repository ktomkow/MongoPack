using MongoPack.IdGeneration;
using Microsoft.Extensions.DependencyInjection;
using System;
using ProjectsCore.Models;
using ProjectsCore.Persistence;
using MongoPack.Interrfaces;
using MongoPack.Implementations;

namespace MongoPack.ServiceProvider
{
    public static class ServiceCollectionExtension
    {
        public static void AddMongo(this IServiceCollection services)
        {
            services.AddTransient<IEntityIdGenerator<Guid, IEntity<Guid>>, EntityGuidIdGenerator<IEntity<Guid>>>();
            services.AddTransient<IEntityIdGenerator<int, IEntity<int>>, EntityIntIdGenerator<IEntity<int>>>();

            services.AddTransient<IDbFactory, DbFactory>();
            services.AddTransient<ICollectionNameResolver, DefaultCollectionNameResolver>();

            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
        }
    }
}
