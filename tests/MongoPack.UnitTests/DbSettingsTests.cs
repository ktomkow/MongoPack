using FluentAssertions;
using System.Reflection;
using Xunit;

namespace MongoPack.UnitTests
{
    public class DbSettingsTests
    {
        private const string ConnectionString = "does not matter now";

        [Fact]
        public void DbName_WhenDbNameNotSpecified_UseProjectName()
        {
            DbSettings dbSettings = new DbSettings(ConnectionString);

            dbSettings.DbName.Should().Be(Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}
