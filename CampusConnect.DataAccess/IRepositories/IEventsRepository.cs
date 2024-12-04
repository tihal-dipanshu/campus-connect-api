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
        Task UpdateEvent(int eventId, Event updateEvent);
        Task DeleteEvent(int eventId);
        Task<IEnumerable<Event>> GetEventsByCategory(int categoryId);
        Task<IEnumerable<Event>> SearchEvents(string searchTerm);
    }
}