using MongoDB.Driver;

namespace Exemplos.EF;

public class ConexaoMongoDb
{
    public IMongoDatabase DataBase { get; }

    public ConexaoMongoDb()
    {
        var mongoConnectionUrl = new MongoUrl("mongodb://localhost:27017");
        var client = new MongoClient(MongoClientSettings.FromUrl(mongoConnectionUrl));
        DataBase = client.GetDatabase("TesteOCAD");
    }
}