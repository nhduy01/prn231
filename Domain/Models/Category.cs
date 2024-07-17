using Domain.Models.Base;

namespace Domain.Models;

public class Category : BaseModel
{
    public string Name { get; set; }

    public ICollection<Post> Post { get; set; }
}