using MongoPack.IdGeneration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using ProjectsCore.Models;
using ProjectsCore.Persistence;
using MongoPack.Interrfaces;
using MongoPack.Implementations;
using System.Linq;

namespace MongoPack.ServiceProvider
{
    public static class ServiceCollectionExtension
    {
        public static void AddMongo(this IServiceCollection services)
        {
            services.AddTransient<IDbFactory, DbFactory>();
            services.AddTransient<ICollectionNameResolver, DefaultCollectionNameResolver>();

            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));

            services.AddTransient<IEntityIdGenerator<int>, EntityIntIdGenerator>();
            services.AddTransient<IEntityIdGenerator<Guid>, EntityGuidIdGenerator>();
        }
    }
}
