namespace CampusConnect.DataAccess.DataModels
{
    public class EventAttendee
    {
        public int AttendeeID { get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }
        public string RSVPStatus { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}
