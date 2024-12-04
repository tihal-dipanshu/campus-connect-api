using CampusConnect.Business.IService;
using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusConnect.Business.Service
{
    public class EventsService : IEventsService
    {
        private readonly IEventsRepository _eventsRepository;

        public EventsService(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _eventsRepository.GetAllEvents();
        }

        public async Task<Event> GetEventById(int eventId)
        {
            return await _eventsRepository.GetEventById(eventId);
        }

        public async Task<Event> CreateEvent(Event newEvent)
        {
            return await _eventsRepository.CreateEvent(newEvent);
        }

        public async Task UpdateEvent(int eventId, Event updateEvent)
        {
            await _eventsRepository.UpdateEvent(eventId, updateEvent);
        }

        public async Task DeleteEvent(int eventId)
        {
            await _eventsRepository.DeleteEvent(eventId);
        }

        public async Task<IEnumerable<Event>> GetEventsByCategory(int categoryId)
        {
            return await _eventsRepository.GetEventsByCategory(categoryId);
        }

        public async Task<IEnumerable<Event>> SearchEvents(string searchTerm)
        {
            return await _eventsRepository.SearchEvents(searchTerm);
        }
    }
}