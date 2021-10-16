using System;
using System.Reflection;

namespace MongoPack
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; }

        public string DbName { get; }

        public MongoDbSettings(string connectionString)
        {
            this.ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(this.ConnectionString));

            this.DbName = Assembly.GetCallingAssembly().GetName().Name;
        }

        public MongoDbSettings(string connectionString, string dbName)
        {
            this.ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            this.DbName = dbName ?? throw new ArgumentNullException(nameof(dbName));
        }
    }
}
