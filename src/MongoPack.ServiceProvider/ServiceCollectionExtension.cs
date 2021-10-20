using MongoPack.IdGeneration;
using Microsoft.Extensions.DependencyInjection;
using System;
using ProjectsCore.Models;
using ProjectsCore.Persistence;

namespace MongoPack.ServiceProvider
{
    public static class ServiceCollectionExtension
    {
        public static void AddMongo(IServiceCollection services)
        {
            services.AddTransient<IEntityIdGenerator<Guid, IEntity<Guid>>, EntityGuidIdGenerator<IEntity<Guid>>>();
            services.AddTransient<IEntityIdGenerator<int, IEntity<int>>, EntityIntIdGenerator<IEntity<int>>>();

            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
        }
    }
}
