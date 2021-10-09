using FluentAssertions;
using ProjectsCore.Models;
using System;
using Xunit;

namespace MongoPack.IntegrationTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            true.Should().Be(true);
        }

        private class SimpleClass : Entity<Guid>
        {
            public string Name { get; set; }

            protected SimpleClass() { }

            public SimpleClass(Guid id)
            {
                this.id = id;
            }
        }
    }
}
