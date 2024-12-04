namespace CampusConnect.Business.Entities;

public class GroupChatModel
{
    public int ChatID { get; set; }
    public int EventID { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<ChatMessageModel> Messages { get; set; }
}