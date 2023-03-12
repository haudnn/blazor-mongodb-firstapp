using FirstApp.Models;
using FirstApp.Helpers;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;
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
    // public async Task CreateTodo(TodoModel todo)
    // {
    //     var database = _client.GetDatabase("todo-list");
    //     var todoCollection = database.GetCollection<TodoModel>("todo");
    //     await todoCollection.InsertOneAsync(todo);
    //     return;
    // }


    // var todoCollection = database.GetCollection<TodoModel>("todos");

    // var todoList = await todoListCollection.Find(x => x.Name == "My Todo List").FirstOrDefaultAsync();
    // if (todoList == null)
    // {
    //     // Todo list does not exist, so create it
    //     todoList = new TodoListModel { Name = "My Todo List", Todos = new List<Todo>() };
    //     await todoListCollection.InsertOneAsync(todoList);
    // }

    // var todo = new Todo { Title = "Todo", Description = "This is a todo." };
    // var todoUpdate = new TodoModel { Todo = todo, TodoList = todoList._id };

    // await todoCollection.InsertOneAsync(todoUpdate);

    public async Task CreateTodo(TodoModel todo, string currentDate)
    {
        var database = _client.GetDatabase("todo-list");

        var todoListCollection = database.GetCollection<TodoListModel>("todo-list");
        var todoCollection = database.GetCollection<TodoModel>("todo");

        var todoList = await todoListCollection.Find(x => x.date == currentDate).FirstOrDefaultAsync();

        if (todoList == null)
        {
            todoList = new TodoListModel
            {
                _id = GenerateIDHelper.GenerateID("1234"),
                date = currentDate,
                quantityTodosDone = 0,
                status = 1,
                total = 0
            };
            todoListCollection.InsertOne(todoList);
        }

        todo.todoList = todoList._id;
        await todoCollection.InsertOneAsync(todo);
        return;

    }

    public async Task<List<TodoModel>> FindTodosByDate(string currentDate)
    {
        var database = _client.GetDatabase("todo-list");

        var todoListCollection = database.GetCollection<TodoListModel>("todo-list");

        var todolist = todoListCollection.Find(x => x.date == currentDate).FirstOrDefault();
        if (todolist != null)
        {
            var todoCollection = database.GetCollection<TodoModel>("todo");
            var todos = await todoCollection.Find(x => x.todoList == todolist._id).ToListAsync();
            return todos;
        }
        else
        {

            return new List<TodoModel>();
        }
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