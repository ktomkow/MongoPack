using FluentAssertions;
using MongoPack.IdGeneration;
using MongoPack.Implementations;
using ProjectsCore.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MongoPack.IntegrationTests
{
    public class SimpleRepositoryTests : TestsFixture
    {
        private readonly Repository<int, SimpleEntity> repositoryIntKey;
        private readonly Repository<Guid, SimpleEntityGuidId> repositoryGuidKey;

        private readonly string collectionName;

        public SimpleRepositoryTests()
        {
            var nameResolver = new DefaultCollectionNameResolver();
            var intIdGenerator  = new EntityIntIdGenerator<SimpleEntity>(this.dbFactory);
            var guidIdGenerator  = new EntityGuidIdGenerator<SimpleEntityGuidId>();
            this.repositoryIntKey = new Repository<int, SimpleEntity>(this.dbFactory, nameResolver, intIdGenerator);
            this.repositoryGuidKey = new Repository<Guid, SimpleEntityGuidId>(this.dbFactory, nameResolver, guidIdGenerator);

            this.collectionName = nameResolver.Resolve(typeof(SimpleEntity));
        }

        [Fact]
        public async Task Insert_IntId_ShouldBeGenerated()
        {
            SimpleEntity entity = new SimpleEntity()
            {
                Name = "Naaaame"
            };

            await repositoryIntKey.Insert(entity);

            entity.Id.Should().NotBe(default(int));
        }

        [Fact]
        public async Task Insert_GuidId_ShouldBeGenerated()
        {
            SimpleEntityGuidId entity = new SimpleEntityGuidId()
            {
                Name = "Naaaame"
            };

            await repositoryGuidKey.Insert(entity);

            entity.Id.Should().NotBe(default(Guid));
        }

        protected override async Task Cleanup()
        {
            await this.collectionPurger.Purge(this.collectionName);
        }

        private class SimpleEntity : Entity<int>
        {
            public string Name { get; set; }
        }

        private class SimpleEntityGuidId : Entity<Guid>
        {
            public string Name { get; set; }
        }
    }
}
