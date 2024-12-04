using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusConnect.DataAccess.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly CampusConnectContext _context;

        public EventsRepository(CampusConnectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetEventById(int eventId)
        {
            return await _context.Events.FindAsync(eventId);
        }

        public async Task<Event  > CreateEvent(Event newEvent)
        {
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
            return newEvent;
        }

        public async Task UpdateEvent(int eventId, Event updateEvent)
        {
            var existingEvent = await _context.Events.FindAsync(eventId);
            if (existingEvent == null)
                throw new KeyNotFoundException("Event not found");

            _context.Entry(existingEvent).CurrentValues.SetValues(updateEvent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEvent(int eventId)
        {
            var eventToDelete = await _context.Events.FindAsync(eventId);
            if (eventToDelete == null)
                throw new KeyNotFoundException("Event not found");

            _context.Events.Remove(eventToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsByCategory(int categoryId)
        {
            return await _context.Events.Where(e => e.CategoryID == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Event>> SearchEvents(string searchTerm)
        {
            return await _context.Events
                .Where(e => e.EventName.Contains(searchTerm) || e.Description.Contains(searchTerm))
                .ToListAsync();
        }
    }
}