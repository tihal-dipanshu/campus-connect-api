using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CampusConnect.DataAccess.Repositories
{
    public class EventAttendeeRepository : IEventAttendeeRepository
    {
        private readonly CampusConnectContext _context;

        public EventAttendeeRepository(CampusConnectContext context)
        {
            _context = context;
        }

        public async Task<EventAttendee> AddAttendee(int eventId, int userId)
        {
            var attendee = new EventAttendee
            {
                EventID = eventId,
                UserID = userId,
                RSVPStatus = "Attending",
                CreatedAt = DateTime.UtcNow
            };
            _context.EventAttendees.Add(attendee);

            var eventItem = await _context.Events.FindAsync(eventId);
            if (eventItem != null && eventItem.Capacity > 0)
            {
                eventItem.Capacity--;
            }

            await _context.SaveChangesAsync();
            return attendee;
        }


        public async Task RemoveAttendee(int eventId, int userId)
        {
            var attendee = await _context.EventAttendees
                .FirstOrDefaultAsync(a => a.EventID == eventId && a.UserID == userId);
            if (attendee != null)
            {
                _context.EventAttendees.Remove(attendee);

                var eventItem = await _context.Events.FindAsync(eventId);
                if (eventItem != null)
                {
                    eventItem.Capacity++;
                }

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EventAttendee>> GetAllAttendees()
        {
            return await _context.EventAttendees
                .Include(a => a.User)
                .Include(a => a.Event)
                .ToListAsync();
        }

        // public async Task<IEnumerable<EventAttendee>> GetAttendeesByEventId(int eventId)
        // {
        //     return await _context.EventAttendees
        //         .Where(a => a.EventID == eventId)
        //         .ToListAsync();
        // }
        
        public async Task<IEnumerable<EventAttendee>> GetAttendeesByEventId(int eventId)
        {
            return await _context.EventAttendees
                .Where(a => a.EventID == eventId)
                .Include(a => a.User)
                .Include(a => a.Event)
                .ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsByUserId(int userId)
        {
            return await _context.EventAttendees
                .Where(a => a.UserID == userId)
                .Select(a => a.Event)
                .ToListAsync();
        }
    }
}