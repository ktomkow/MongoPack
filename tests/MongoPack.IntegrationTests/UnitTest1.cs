using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoPack.Implementations;
using MongoPack.Interrfaces;
using ProjectsCore.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MongoPack.IntegrationTests
{
    public class UnitTest1
    {
        public UnitTest1()
        {
            var dbClient = new MongoClient("mongodb://192.168.0.133:3099");
            var db = dbClient.GetDatabase("test");

            var dbCollection = db.GetCollection<SimpleClass>("SimpleClass");

            dbCollection.DeleteMany(new BsonDocument());
        }

        [Fact]
        public async Task Test1()
        {
            ICollectionNameResolver resolver = new DefaultCollectionNameResolver();
            var repo = new Repository<Guid, SimpleClass>(resolver);

            Guid guid = Guid.Parse("df791abe-7e95-48c9-81af-6bf300a76f80");
            SimpleClass newobject = new SimpleClass(guid);
            newobject.Name = "Some name";

            await repo.Insert(newobject);

            var result = await repo.GetAll();

            result.FirstOrDefault().Should().NotBeNull();
            result.FirstOrDefault().Name.Should().Be("Some name");
        }

        private class SimpleClass : Entity<Guid>
        {
            public string Name { get; set; }

            public SimpleClass(Guid id)
            {
                this.id = id;
            }
        }
    }
}
