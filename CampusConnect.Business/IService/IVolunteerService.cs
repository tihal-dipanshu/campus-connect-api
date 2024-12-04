using CampusConnect.Business.DTO;
using CampusConnect.DataAccess.DataModels;

namespace CampusConnect.Business.IService{

    public interface IVolunteerService
    {
        Task<IEnumerable<VolunteerDTO>> GetVolunteersByEventId(int eventId);
        Task<IEnumerable<VolunteerDTO>> GetAllVolunteers();
        Task<Volunteer> AddVolunteer(CreateVolunteerDTO volunteerDTO);
        Task<bool> RemoveVolunteer(int volunteerId);
        Task<VolunteerDTO> ApproveVolunteer(int volunteerId);
        Task<VolunteerDTO> RejectVolunteer(int volunteerId);
    }
}