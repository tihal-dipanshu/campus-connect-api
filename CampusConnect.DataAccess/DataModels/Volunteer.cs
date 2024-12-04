using System.Text.Json.Serialization;
using CampusConnect.DataAccess.DataModels.CampusConnect.DataAccess.DataModels;

namespace CampusConnect.DataAccess.DataModels
{
    public class Volunteer
    {
        public int VolunteerID { get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        [JsonIgnore]
        public virtual Event Event { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}