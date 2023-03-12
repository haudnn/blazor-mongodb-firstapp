using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace FirstApp.Models;
public class TodoModel
{
    // public string id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
    [BsonId]
    public string _id { get; set; }

    /// <summary>Todolist ID</summary>
    public string todoList { get; set; }

    /// <summary>User ID</summary>
    public string userId { get; set; }

    /// <summary> Tên công việc</summary>
    public string name { get; set; }
    public string description { get; set; }

    /// <summary> Kết quả</summary>
    public string result { get; set; }

    /// <summary>Ngày của Todolist</summary>
    public string date { get; set; }

    /// <summary> Thời gian bắt đầu</summary>
    public string startTime { get; set; }

    /// <summary> Thời gian kết thúc</summary>
    public string endTime { get; set; }

    /// <summary> Phân loại</summary>
    /// 1: Ke hoach
    /// 2: Cap tren giao
    /// 3: Dot xuat
    public int type { get; set; }

    /// <summary> Độ ưu tiên</summary>
    /// 1: Binh thuong
    /// 2: Quan trong
    /// 3: Rat quan trong
    public int priority { get; set; }

    /// <summary> Trạng thái</summary>
    /// 1: Todo
    /// 2: Pending
    /// 3: Doing
    /// 4: Done
    /// 5: Cancel
    public int status { get; set; }

    // public Status getStatus
    // {
    //     get
    //     {
    //         var statusModel = new StatusModel();
    //         var status = statusModel.FindStatusById(this.status);
    //         return status;
    //     }
    // }
}