namespace Application.SendModels.Notification;

public class NotificationRequest
{
        public string Title { get; set; }
        public string Message { get; set; }
        public Guid? AccountId { get; set; }
}