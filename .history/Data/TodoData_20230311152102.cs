using FirstApp.Models;
using FirstApp.Helpers;
using MongoDB.Driver;
namespace FirstApp.Data;

public class TodoData
{
    private readonly IMongoClient _client;
    public TodoData()
    {
        var connectDB = new ConnectDB();
        _client = connectDB.GetClient();
    }
    // Create todoList =>  getIdTodoList => create todo with idTodoList
    public async Task CreateTodo(TodoModel todo)
    {
        var database = _client.GetDatabase("todo-list");
        var todoCollection = database.GetCollection<TodoModel>("todo");
        await todoCollection.InsertOneAsync(todo);
        return;
    }
    public async Task<List<TodoModel>> FindTodoByDate(string currentDate)
    {
        var database = _client.GetDatabase("todo-list");
        var todoCollection = database.GetCollection<TodoModel>("todo");
        var filter = Builders<TodoModel>.Filter.Eq("date", currentDate);
        var todos = await todoCollection.Find(filter).ToListAsync();
        return todos;
    }
    public async Task DeleteTodo(string todoId)
    {
        var database = _client.GetDatabase("todo-list");
        var todoCollection = database.GetCollection<TodoModel>("todo");
        var filter = Builders<TodoModel>.Filter.Eq(todo => todo._id, todoId);
        await todoCollection.DeleteOneAsync(filter);
        return;
    }
    public async Task UpdateTodo(TodoModel todo)
    {
        var database = _client.GetDatabase("todo-list");
        var todoCollection = database.GetCollection<TodoModel>("todo");
        var filter = Builders<TodoModel>.Filter.Eq(todo => todo._id, todo._id);
        var update = Builders<TodoModel>.Update
            .Set(todo => todo.name, todo.name)
            .Set(todo => todo.description, todo.description)
            .Set(todo => todo.result, todo.result)
            .Set(todo => todo.startTime, todo.startTime)
            .Set(todo => todo.endTime, todo.endTime)
            .Set(todo => todo.type, todo.type)
            .Set(todo => todo.result, todo.result)
            .Set(todo => todo.status, todo.status)
            .Set(todo => todo.priority, todo.priority);

        await todoCollection.UpdateOneAsync(filter, update);
        return;
    }
    public async Task UpdateStatusTodo(string todoId, int status)
    {
        var database = _client.GetDatabase("todo-list");
        var todoCollection = database.GetCollection<TodoModel>("todo");
        var filter = Builders<TodoModel>.Filter.Eq(todo => todo._id, todoId);
        var update = Builders<TodoModel>.Update
            .Set(todo => todo.status, status);
        await todoCollection.UpdateOneAsync(filter, update);
        return;
    }
}


//
// using MongoDB.Driver;

// // Create an instance of the ConnectDB class
// var connectDB = new ConnectDB();

// // Get the MongoClient object from the ConnectDB class
// var client = connectDB.Client;

// // Get a database from the MongoClient object
// var database = client.GetDatabase("mydatabase");

// // Get a collection from the database
// var collection = database.GetCollection<BsonDocument>("mycollection");

// // Insert a document into the collection
// var document = new BsonDocument {
//     { "name", "John Doe" },
//     { "age", 30 }
// };
// collection.InsertOne(document);





// using MongoDB.Bson;
// using MongoDB.Driver;
// public class Person
// {
//     public ObjectId Id { get; set; }
//     public string Name { get; set; }
// }
// var client = new MongoClient("mongodb://localhost:27017");
// var database = client.GetDatabase("foo");
// var collection = database.GetCollection<Person>("bar");

// await collection.InsertOneAsync(new Person { Name = "Jack" });

// var list = await collection.Find(x => x.Name == "Jack")
//     .ToListAsync();

// foreach(var person in list)
// {
//     Console.WriteLine(person.Name);
// }