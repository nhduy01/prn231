using Domain.Models.Base;

namespace Domain.Models;

public class Notification : BaseModel
{
    public string Title { get; set; }
    public string Message { get; set; }
    public bool IsReaded { get; set; } = false;
    public Guid? AccountId { get; set; }


    //Relation
    public Account Account { get; set; }
}