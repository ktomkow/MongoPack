using FluentAssertions;
using MongoPack.IdGeneration;
using MongoPack.Implementations;
using MongoPack.Interrfaces;
using MongoPack.Testing;
using ProjectsCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MongoPack.IntegrationTests.IdGenerationTests
{
    public class IntIdGenerationTests : TestsFixture, IAsyncLifetime
    {
        private readonly EntityIntIdGenerator<IntKeyedClass> generator;

        public IntIdGenerationTests(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.generator = new EntityIntIdGenerator<IntKeyedClass>(this.dbFactory);
        }

        [Fact]
        public async Task GenerateThreeIdentifiersOneByOne()
        {
            int firstId = await this.generator.Generate();
            int secondId = await this.generator.Generate();
            int thirdId = await this.generator.Generate();

            firstId.Should().Be(1);
            secondId.Should().Be(2);
            thirdId.Should().Be(3);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public async Task CheckRaceConditions(int repeats)
        {
            var list = new List<Task>();

            for (int i = 0; i < repeats; i++)
            {
                list.Add(this.generator.Generate());
            }

            await Task.WhenAll(list);

            int lastOne = await this.generator.Generate();

            lastOne.Should().Be(repeats + 1);
        }

        protected override async Task Cleanup()
        {
            await this.collectionPurger.Purge("_identifiers");
        }

        private class IntKeyedClass : Entity<int>
        {
            public string Name { get; set; }
        }
    }
}
