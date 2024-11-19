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
        public int OrganizerID { get; set; }
        public int Capacity { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual EventCategory Category { get; set; }
        public virtual User Organizer { get; set; }
        public virtual ICollection<EventAttendee> Attendees { get; set; }
        public virtual GroupChat GroupChat { get; set; }
    }
}
