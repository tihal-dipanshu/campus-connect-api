namespace CampusConnect.Business.Entities;

public class ChatMessageModel
{
    public int MessageID { get; set; }
    public int ChatID { get; set; }
    public int UserID { get; set; }
    public string MessageContent { get; set; }
    public DateTime SentAt { get; set; }
}