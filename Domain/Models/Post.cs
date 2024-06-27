using System.ComponentModel;
using Domain.Models.Base;

namespace Domain.Models;

public class Post : BaseModel
{
    public string? Url { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid? StaffId { get; set; }
    public string CategoryId {  get; set; }

    //Relation
    public Category Category { get; set; }
    public ICollection<Image> Images { get; set; }
    public Account Account { get; set; }
}