using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FirstApp.Models;


// _id
// date: date created todo
// status: status todd: 1 => new ; 2 => checkin; 3 => checkout
// todos: List<TodoModel> todos: {"1233", "2344"}
// total: total todos in a day
// quantityTodosDone: total quantity todos done
public class TodoListModel
{
    [BsonId]
    public string _id { get; set; }

    // status: status todd: 1 => new ; 2 => checkin; 3 => checkout
    public string status { get; set; }

    // total: total todos in a day
    public string total { get; set; }

}