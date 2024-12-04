namespace CampusConnect.Business.DTO;

public class EventAttendeeDTO
{
    public int AttendeeID { get; set; }
    //public int EventID { get; set; }
    //public int UserID { get; set; }
    public string RSVPStatus { get; set; }
    public DateTime CreatedAt { get; set; }
    public UserDTO User { get; set; }
    public EventDTO Event { get; set; }
}