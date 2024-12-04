using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CampusConnect.DataAccess.DataModels
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Location { get; set; }
        public int CategoryID { get; set; }
        public int Capacity { get; set; }
        public DateTime CreatedAt { get; set; }
        public int IsActive { get; set; }
        
        [JsonIgnore]
        public virtual EventCategory Category { get; set; }
        [JsonIgnore]
        public virtual ICollection<EventAttendee> Attendees { get; set; }
        [JsonIgnore]
        public virtual ICollection<EventOrganizer> Organizers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Volunteer> Volunteers { get; set; }
        [JsonIgnore]
        public virtual GroupChat GroupChat { get; set; }
    }
}