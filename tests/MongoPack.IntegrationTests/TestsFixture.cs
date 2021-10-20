using Microsoft.Extensions.DependencyInjection;
using MongoPack.Interrfaces;
using MongoPack.Testing;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MongoPack.IntegrationTests
{
    [Collection("TestsFixture")]
    public abstract class TestsFixture : IAsyncLifetime
    {
        private readonly IServiceProvider serviceProvider;

        protected IDbFactory dbFactory => this.serviceProvider.GetService<IDbFactory>();
        protected ICollectionPurger collectionPurger => this.serviceProvider.GetService<ICollectionPurger>();

        public TestsFixture(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public virtual async Task InitializeAsync()
        {
            await Cleanup();
        }

        public virtual async Task DisposeAsync()
        {
            await Cleanup();
        }

        protected abstract Task Cleanup();
    }
}
