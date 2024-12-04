using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CampusConnect.DataAccess.DataModels
{
    using System;

    namespace CampusConnect.DataAccess.DataModels
    {
        public class User
        {
            public int UserID { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string PasswordHash { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserRole { get; set; }
            public DateTime CreatedAt { get; set; }
            
            [JsonIgnore]
            public virtual ICollection<EventAttendee> EventAttendees { get; set; }
            [JsonIgnore]
            public virtual ICollection<EventOrganizer> OrganizedEvents { get; set; }
            [JsonIgnore]
            public virtual ICollection<Volunteer> VolunteeredEvents { get; set; }
            [JsonIgnore]
            public virtual ICollection<ChatMessage> ChatMessages { get; set; }

        }
    }
}
