using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CampusConnect.DataAccess.DataModels
{
    public class EventCategory
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Event> Events { get; set; }
    }
}