using System;

namespace CampusConnect.Business.Entities
{
    public class EventOrganizerModel
    {
        public int EventOrganizerID { get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}