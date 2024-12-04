using System;
using System.Text.Json.Serialization;
using CampusConnect.DataAccess.DataModels.CampusConnect.DataAccess.DataModels;

namespace CampusConnect.DataAccess.DataModels
{
    public class EventAttendee
    {
        public int AttendeeID { get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }
        public string RSVPStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        
        [JsonIgnore]
        public virtual Event Event { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}