using FluentAssertions;
using MongoPack.Extensions;
using ProjectsCore.Models;
using Xunit;

namespace MongoPack.UnitTests
{
    public class SettingNonPublicIdTests
    {
        [Fact]
        public void SetId_TypeInt()
        {
            int id = 15;
            ClassWithoutPublicIdSetter instance = new ClassWithoutPublicIdSetter();

            instance.SetId(id);

            instance.Id.Should().Be(id);
        }

        private class ClassWithoutPublicIdSetter : Entity<int>
        {

        }
    }
}
