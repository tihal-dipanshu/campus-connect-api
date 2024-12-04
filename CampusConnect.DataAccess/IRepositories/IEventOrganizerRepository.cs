using CampusConnect.DataAccess.DataModels;

namespace CampusConnect.DataAccess.IRepositories;

public interface IEventOrganizerRepository
{
    Task<IEnumerable<EventOrganizer>> GetAllEventOrganizers();
    Task<IEnumerable<EventOrganizer>> GetOrganizersByEventId(int eventId);
    Task<EventOrganizer> GetOrganizerById(int userId);
    Task<IEnumerable<Event>> GetEventsByOrganizerId(int userId);
}