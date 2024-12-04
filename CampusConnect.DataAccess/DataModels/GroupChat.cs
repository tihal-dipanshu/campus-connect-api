using System.Text.Json.Serialization;

namespace CampusConnect.DataAccess.DataModels;

public class GroupChat
{
    public int ChatID { get; set; }
    public int EventID { get; set; }
    public DateTime CreatedAt { get; set; }

    [JsonIgnore]
    public virtual Event Event { get; set; }
    [JsonIgnore]
    public virtual ICollection<ChatMessage> Messages { get; set; }
}