using MongoDB.Driver;

namespace FirstApp.Helpers;

public class ConnectDB
{
    private readonly IMongoClient _client;
    private readonly string DB_NAME = "mongodb://localhost:27017/todo-list";
    public ConnectDB()
    {
        var settings = MongoClientSettings.FromConnectionString(DB_NAME);
        _client = new MongoClient(settings);
    }
    public IMongoClient GetClient()
    {
        return _client;
    }

}

// Add methods to access databases and collections here
// var database = _client.GetDatabase("test");
// var connectionString = "mongodb://localhost:27017/mydatabase";
// _client = new MongoClient(connectionString);