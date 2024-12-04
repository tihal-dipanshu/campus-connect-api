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
            // return await _context.Events.ToListAsync();
            return await _context.Events.Where(e => e.IsActive == 1).ToListAsync();
        }

        public async Task<Event> GetEventById(int eventId)
        {
            // return await _context.Events.FindAsync(eventId);
            return await _context.Events.FirstOrDefaultAsync(e => e.EventID == eventId && e.IsActive == 1);
        }

        public async Task<Event> CreateEvent(Event newEvent)
        {
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync(); // Save the event first

            var chat = new GroupChat
            {
                EventID = newEvent.EventID, // Now newEvent.EventID will have a value
                CreatedAt = DateTime.UtcNow
            };
            await _context.GroupChats.AddAsync(chat);
            await _context.SaveChangesAsync();

            return newEvent;
        }

        public async Task UpdateEvent(Event updateEvent)
        {
            // var existingEvent = await _context.Events.FindAsync(updateEvent.EventID);
            var existingEvent = await _context.Events.FirstOrDefaultAsync(e => e.EventID == updateEvent.EventID && e.IsActive == 1);
            if (existingEvent == null)
                throw new KeyNotFoundException("Event not found");

            _context.Entry(existingEvent).CurrentValues.SetValues(updateEvent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEvent(int eventId)
        {
            // var eventToDelete = await _context.Events.FindAsync(eventId);
            var eventToDelete = await _context.Events.FirstOrDefaultAsync(e => e.EventID == eventId && e.IsActive == 1);
            if (eventToDelete == null)
                throw new KeyNotFoundException("Event not found");
            
            // Event updateEvent = new Event
            // {
            //     EventID = eventId,
            //     EventName = eventToDelete.EventName,
            //     Description = eventToDelete.Description,
            //     StartDateTime = eventToDelete.StartDateTime,
            //     EndDateTime = eventToDelete.EndDateTime,
            //     Location = eventToDelete.Location,
            //     CategoryID = eventToDelete.CategoryID,
            //     Capacity = eventToDelete.Capacity,
            //     CreatedAt = eventToDelete.CreatedAt,
            //     IsActive = 0
            // };
            
            eventToDelete.IsActive = 0;

            // _context.Entry(eventToDelete).CurrentValues.SetValues(updateEvent);
            await _context.SaveChangesAsync();
        }
        
        // public async Task DecrementEventCapacity(int eventId)
        // {
        //     var eventItem = await _context.Events.FindAsync(eventId);
        //     if (eventItem != null && eventItem.Capacity > 0)
        //     {
        //         eventItem.Capacity--;
        //         await _context.SaveChangesAsync();
        //     }
        // }
        //
        // public async Task IncrementEventCapacity(int eventId)
        // {
        //     var eventItem = await _context.Events.FindAsync(eventId);
        //     if (eventItem != null)
        //     {
        //         eventItem.Capacity++;
        //         await _context.SaveChangesAsync();
        //     }
        // }

        public async Task<IEnumerable<Event>> GetEventsByCategory(int categoryId)
        {
            // return await _context.Events.Where(e => e.CategoryID == categoryId).ToListAsync();
            return await _context.Events.Where(e => e.CategoryID == categoryId && e.IsActive == 1).ToListAsync();
        }

        public async Task<IEnumerable<Event>> SearchEvents(string searchTerm)
        {
            // return await _context.Events
            //     .Where(e => e.EventName.Contains(searchTerm) || e.Description.Contains(searchTerm))
            //     .ToListAsync();
            
            return await _context.Events
                .Where(e => e.IsActive == 1 && (e.EventName.Contains(searchTerm) || e.Description.Contains(searchTerm)))
                .ToListAsync();
        }
    }
}