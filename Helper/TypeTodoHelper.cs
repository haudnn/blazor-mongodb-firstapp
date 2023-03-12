using FirstApp.Models;

namespace FirstApp.Helpers;

public class TypeTodoHelper
{

    public static List<TodoTextModel> AddTypeToList()
    {
        List<TodoTextModel> listPriority = new List<TodoTextModel>();
        listPriority.Add(new TodoTextModel() { id = 1, name = "Kế hoạch" });
        listPriority.Add(new TodoTextModel() { id = 2, name = "Cấp trên giao" });
        listPriority.Add(new TodoTextModel() { id = 3, name = "Đột xuất" });
        return listPriority;
    }
    public static TodoTextModel FindTypeById(int id)
    {
        List<TodoTextModel> listType = AddTypeToList();
        return listType.Find(type => type.id == id);
    }
}


