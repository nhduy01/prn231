namespace Domain.Models.Base
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public int? CreatedBy { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedTime { get; set; }
        public int? UpdatedBy { get; set; }
    }
}