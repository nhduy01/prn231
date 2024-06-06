namespace Domain.Models.Base
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public Guid? CreatedBy { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedTime { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}