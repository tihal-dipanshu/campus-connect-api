using System;

namespace CampusConnect.Business.Entities
{
    public class EventAttendeeModel
    {
        public int AttendeeID { get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }
        public string RSVPStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}