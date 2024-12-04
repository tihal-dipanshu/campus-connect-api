namespace CampusConnect.Business.DTO;

public class EventDTO
{
    public int EventID { get; set; }
    public string EventName { get; set; }
    public string Description { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public string Location { get; set; }
}