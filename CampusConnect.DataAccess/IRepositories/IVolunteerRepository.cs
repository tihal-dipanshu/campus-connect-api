using CampusConnect.DataAccess.DataModels;

namespace CampusConnect.DataAccess.IRepositories
{

    public interface IVolunteerRepository
    {
        Task<IEnumerable<Volunteer>> GetVolunteersByEventId(int eventId);
        Task<IEnumerable<Volunteer>> GetAllVolunteers();
        Task<Volunteer> AddVolunteer(Volunteer volunteer);
        Task<bool> RemoveVolunteer(int volunteerId);
        Task<Volunteer> UpdateVolunteerStatus(int volunteerId, string status);
        Task<Volunteer> GetVolunteerById(int volunteerId);
    }
}