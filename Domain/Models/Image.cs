using Domain.Models.Base;

namespace Domain.Models;

public class Image : BaseModel
{
    public string Url { get; set; }
    public string Description { get; set; }

    //Relation
    public ICollection<PostImage> PostImage { get; set; }
}