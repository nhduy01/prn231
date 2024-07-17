using Domain.Models.Base;

namespace Domain.Models;

public class Resources : BaseModel
{
    public string Sponsorship { get; set; }
    public Guid? SponsorId { get; set; }
    public Guid? ContestId { get; set; }


    //Relation

    public Contest Contest { get; set; }

    public Sponsor Sponsor { get; set; }
}