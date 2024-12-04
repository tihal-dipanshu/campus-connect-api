using CampusConnect.DataAccess.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusConnect.DataAccess.IRepositories
{
    public interface IEventsRepository
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> GetEventById(int eventId);
        Task<Event> CreateEvent(Event newEvent);
        Task UpdateEvent(Event updateEvent);
        Task DeleteEvent(int eventId);
        // Task DecrementEventCapacity(int eventId);
        // Task IncrementEventCapacity(int eventId);
        Task<IEnumerable<Event>> GetEventsByCategory(int categoryId);
        Task<IEnumerable<Event>> SearchEvents(string searchTerm);
    }
}