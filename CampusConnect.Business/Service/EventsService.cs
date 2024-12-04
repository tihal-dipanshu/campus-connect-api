using CampusConnect.Business.IService;
using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using CampusConnect.Business.DTO;

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

        public async Task<Event> CreateEvent(CreateEventDTO createEventDTO)
        {
            var newEvent = new Event
            {
                EventName = createEventDTO.EventName,
                Description = createEventDTO.Description,
                StartDateTime = createEventDTO.StartDateTime,
                EndDateTime = createEventDTO.EndDateTime,
                Location = createEventDTO.Location,
                CategoryID = createEventDTO.CategoryID,
                Capacity = createEventDTO.Capacity,
                CreatedAt = DateTime.UtcNow
            };

            return await _eventsRepository.CreateEvent(newEvent);
        }
        
        // public async Task UpdateEvent(Event updateEvent)
        // {
        //     await _eventsRepository.UpdateEvent(updateEvent);
        // }
        
        public async Task UpdateEvent(UpdateEventDTO updateEventDTO)
        {
            var existingEvent = await _eventsRepository.GetEventById(updateEventDTO.EventID);
            if (existingEvent == null)
                throw new KeyNotFoundException("Event not found");

            existingEvent.EventName = updateEventDTO.EventName;
            existingEvent.Description = updateEventDTO.Description;
            existingEvent.StartDateTime = updateEventDTO.StartDateTime;
            existingEvent.EndDateTime = updateEventDTO.EndDateTime;
            existingEvent.Location = updateEventDTO.Location;
            existingEvent.CategoryID = updateEventDTO.CategoryID;
            existingEvent.Capacity = updateEventDTO.Capacity;
            
            await _eventsRepository.UpdateEvent(existingEvent);
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