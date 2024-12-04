using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CampusConnect.DataAccess.Repositories{

    public class EventOrganizerRepository : IEventOrganizerRepository
    {
        private readonly CampusConnectContext _context;

        public EventOrganizerRepository(CampusConnectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventOrganizer>> GetAllEventOrganizers()
        {
            return await _context.EventOrganizers
                .Include(eo => eo.User)
                .Include(eo => eo.Event)
                .ToListAsync();
        }

        public async Task<IEnumerable<EventOrganizer>> GetOrganizersByEventId(int eventId)
        {
            return await _context.EventOrganizers
                .Where(eo => eo.EventID == eventId)
                .Include(eo => eo.User)
                .ToListAsync();
        }

        public async Task<EventOrganizer> GetOrganizerById(int userId)
        {
            return await _context.EventOrganizers
                .Include(eo => eo.User)
                .FirstOrDefaultAsync(eo => eo.UserID == userId);
        }

        public async Task<IEnumerable<Event>> GetEventsByOrganizerId(int userId)
        {
            return await _context.EventOrganizers
                .Where(eo => eo.UserID == userId)
                .Select(eo => eo.Event)
                .ToListAsync();
        }
    }
}