using MongoPack.Implementations;
using MongoPack.Testing;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace MongoPack.IntegrationTests
{
    [Collection("TestsFixture")]
    public abstract class TestsFixture : IAsyncLifetime
    {
        private static readonly TestsSettings Settings = LoadSettings();
        private readonly MongoDbSettings mongoSettings;

        protected readonly DbFactory dbFactory;
        protected readonly ICollectionPurger collectionPurger;

        public TestsFixture()
        {
            LoadSettings();
            
            this.mongoSettings = new MongoDbSettings(Settings.ConnectionString, "MongoPackTestDb");
            this.dbFactory = new DbFactory(mongoSettings);
            this.collectionPurger = new CollectionPurger(dbFactory);
        }

        private static TestsSettings LoadSettings()
        {
            var settingsFile = "settings.json";
            var settingsJson = File.ReadAllText(settingsFile);

            return JsonSerializer.Deserialize<TestsSettings>(settingsJson);
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
