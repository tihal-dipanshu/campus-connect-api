using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CampusConnect.DataAccess.Repositories
{

    public class VolunteerRepository : IVolunteerRepository
    {
        private readonly CampusConnectContext _context;

        public VolunteerRepository(CampusConnectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Volunteer>> GetVolunteersByEventId(int eventId)
        {
            return await _context.Volunteers
                .Where(v => v.EventID == eventId)
                .Include(v => v.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Volunteer>> GetAllVolunteers()
        {
            return await _context.Volunteers
                .Include(v => v.User)
                .Include(v => v.Event)
                .ToListAsync();
        }
        public async Task<Volunteer> AddVolunteer(Volunteer volunteer)
        {
            _context.Volunteers.Add(volunteer);
            await _context.SaveChangesAsync();
            return volunteer;
        }

        public async Task<bool> RemoveVolunteer(int volunteerId)
        {
            var volunteer = await _context.Volunteers.FindAsync(volunteerId);
            if (volunteer == null)
                return false;

            _context.Volunteers.Remove(volunteer);
            await _context.SaveChangesAsync();
            return true;
        }
        
        public async Task<Volunteer> UpdateVolunteerStatus(int volunteerId, string status)
        {
            var volunteer = await _context.Volunteers.FindAsync(volunteerId);
            if (volunteer != null)
            {
                volunteer.Status = status;
                await _context.SaveChangesAsync();
            }
            return volunteer;
        }

        public async Task<Volunteer> GetVolunteerById(int volunteerId)
        {
            return await _context.Volunteers.FindAsync(volunteerId);
        }
    }
}