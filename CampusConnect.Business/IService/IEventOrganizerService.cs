using CampusConnect.Business.DTO;

namespace CampusConnect.Business.IService
{
    public interface IEventOrganizerService
    {
        Task<IEnumerable<EventOrganizerDTO>> GetAllEventOrganizers();
        Task<IEnumerable<EventOrganizerDTO>> GetOrganizersByEventId(int eventId);
        Task<EventOrganizerDTO> GetOrganizerById(int userId);
        Task<IEnumerable<EventDTO>> GetEventsByOrganizerId(int userId);
    }
}