namespace CampusConnect.Business.DTO;

public class UpdateEventDTO
{
    public int EventID { get; set; }
    public string EventName { get; set; }
    public string Description { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public string Location { get; set; }
    public int CategoryID { get; set; }
    public int Capacity { get; set; }
    
    public DateTime CreatedAt { get; set; }
}