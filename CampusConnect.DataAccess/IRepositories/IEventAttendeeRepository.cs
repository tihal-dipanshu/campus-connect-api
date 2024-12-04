using CampusConnect.DataAccess.DataModels;

namespace CampusConnect.DataAccess.IRepositories
{
    public interface IEventAttendeeRepository
    {
        Task<EventAttendee> AddAttendee(int eventId, int userId);
        Task RemoveAttendee(int eventId, int userId);
        Task<IEnumerable<EventAttendee>> GetAllAttendees();
        Task<IEnumerable<EventAttendee>> GetAttendeesByEventId(int eventId);
        Task<IEnumerable<Event>> GetEventsByUserId(int userId);
    }
}