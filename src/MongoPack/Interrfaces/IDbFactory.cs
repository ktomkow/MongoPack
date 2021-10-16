using MongoDB.Driver;

namespace MongoPack.Interrfaces
{
    public interface IDbFactory
    {
        IMongoDatabase Create();
    }
}
