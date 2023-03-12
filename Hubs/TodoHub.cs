using Microsoft.AspNetCore.SignalR;
using FirstApp.Models;
namespace FirstApp.Hubs;

public class TodoHub : Hub
{
    public async Task NewTodoAdded(TodoModel todo)
    {
        await Clients.All.SendAsync("TodoAdded", todo);
    }
}