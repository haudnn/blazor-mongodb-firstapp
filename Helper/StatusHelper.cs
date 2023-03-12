
using FirstApp.Models;
namespace FirstApp.Helpers;

public class StatusHelper
{
    public static List<TodoTextModel> AddStatusToList()
    {
        List<TodoTextModel> listStatus = new List<TodoTextModel>();
        listStatus.Add(new TodoTextModel() { id = 1, name = "Todo", color = "", });
        listStatus.Add(new TodoTextModel() { id = 2, name = "Pending", color = "is-warning" });
        listStatus.Add(new TodoTextModel() { id = 3, name = "Doing", color = "is-link" });
        listStatus.Add(new TodoTextModel() { id = 4, name = "Done", color = "is-success" });
        listStatus.Add(new TodoTextModel() { id = 5, name = "Cancel", color = "is-dark" });
        return listStatus;
    }
    public static TodoTextModel FindStatusById(int id)
    {
        List<TodoTextModel> listStatus = AddStatusToList();
        return listStatus.Find(status => status.id == id); ;
    }
}



