using CampusConnect.DataAccess.DataModels.CampusConnect.DataAccess.DataModels;

using CampusConnect.DataAccess.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using CampusConnect.Business.DTO;

namespace CampusConnect.Business.IService
{
    public interface IEventsService
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> GetEventById(int eventId);
        Task<Event> CreateEvent(CreateEventDTO newEvent);
        Task UpdateEvent(UpdateEventDTO updateEvent);
        Task DeleteEvent(int eventId);
        // Task DecrementEventCapacity(int eventId);
        // Task IncrementEventCapacity(int eventId);
        Task<IEnumerable<Event>> GetEventsByCategory(int categoryId);
        Task<IEnumerable<Event>> SearchEvents(string searchTerm);
    }
}