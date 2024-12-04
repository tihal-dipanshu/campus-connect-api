namespace CampusConnect.Business.DTO
{

    public class EventOrganizerDTO
    {
        public int EventOrganizerID { get; set; }
        //public int EventID { get; set; }
        //public int UserID { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserDTO User { get; set; }
        public EventDTO Event { get; set; }
    }
}