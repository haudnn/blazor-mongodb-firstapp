using FirstApp.Models;

namespace FirstApp.Helpers;

public class PriorityHelper
{

    public static List<TodoTextModel> AddPriorityToList()
    {
        List<TodoTextModel> listPriority = new List<TodoTextModel>();
        listPriority.Add(new TodoTextModel() { id = 1, name = "Bình thường", color = "has-text-success" });
        listPriority.Add(new TodoTextModel() { id = 2, name = "Quan trọng", color = "has-text-warning" });
        listPriority.Add(new TodoTextModel() { id = 3, name = "Rất quan trọng", color = "has-text-danger" });
        return listPriority;
    }
    public static TodoTextModel FindPriorityById(int id)
    {
        List<TodoTextModel> listPriority = AddPriorityToList();
        return listPriority.Find(priority => priority.id == id);
    }
}


