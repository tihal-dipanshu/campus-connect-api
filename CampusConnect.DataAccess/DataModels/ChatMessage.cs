using System.Text.Json.Serialization;
using CampusConnect.DataAccess.DataModels.CampusConnect.DataAccess.DataModels;

namespace CampusConnect.DataAccess.DataModels;

public class ChatMessage
{
    public int MessageID { get; set; }
    public int ChatID { get; set; }
    public int UserID { get; set; }
    public string MessageContent { get; set; }
    public DateTime SentAt { get; set; }

    [JsonIgnore]
    public virtual GroupChat GroupChat { get; set; }
    [JsonIgnore]
    public virtual User User { get; set; }
}