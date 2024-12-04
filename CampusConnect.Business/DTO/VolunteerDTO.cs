namespace CampusConnect.Business.DTO
{

    public class VolunteerDTO
    {
        public int VolunteerID { get; set; }
        //public int EventID { get; set; }
        //public int UserID { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserDTO User { get; set; }
        public EventDTO Event { get; set; }
    }
}