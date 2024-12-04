using CampusConnect.Business.DTO;
using CampusConnect.DataAccess.DataModels;

namespace CampusConnect.Business.IService
{
    public interface IEventAttendeeService
    {
        Task<EventAttendee> AddAttendee(int eventId, int userId);
        Task RemoveAttendee(int eventId, int userId);
        Task<IEnumerable<EventAttendeeDTO>> GetAllAttendees();
        Task<IEnumerable<EventAttendeeDTO>> GetAttendeesByEventId(int eventId);
        Task<IEnumerable<Event>> GetEventsByUserId(int userId);

    }
}