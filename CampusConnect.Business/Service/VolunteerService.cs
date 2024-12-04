using AutoMapper;
using CampusConnect.Business.DTO;
using CampusConnect.Business.IService;
using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.IRepositories;

namespace CampusConnect.Business.Service
{
    public class VolunteerService : IVolunteerService
    {
        private readonly IVolunteerRepository _volunteerRepository;
        private readonly IMapper _mapper;

        public VolunteerService(IVolunteerRepository volunteerRepository, IMapper mapper)
        {
            _volunteerRepository = volunteerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VolunteerDTO>> GetVolunteersByEventId(int eventId)
        {
            var volunteers = await _volunteerRepository.GetVolunteersByEventId(eventId);
            return _mapper.Map<IEnumerable<VolunteerDTO>>(volunteers);
        }

        public async Task<IEnumerable<VolunteerDTO>> GetAllVolunteers()
        {
            var volunteers = await _volunteerRepository.GetAllVolunteers();
            return _mapper.Map<IEnumerable<VolunteerDTO>>(volunteers);
        }

        public async Task<VolunteerDTO> AddVolunteer(VolunteerDTO volunteerDTO)
        {
            var volunteer = _mapper.Map<Volunteer>(volunteerDTO);
            var result = await _volunteerRepository.AddVolunteer(volunteer);
            return _mapper.Map<VolunteerDTO>(result);
        }

        public async Task<bool> RemoveVolunteer(int volunteerId)
        {
            return await _volunteerRepository.RemoveVolunteer(volunteerId);
        }
        
        // public async Task<Volunteer> AddVolunteer(CreateVolunteerDTO volunteerDTO)
        // {
        //     var volunteer = new Volunteer
        //     {
        //         EventID = volunteerDTO.EventID,
        //         UserID = volunteerDTO.UserID,
        //         Status = "Pending"
        //     };
        //     var result = await _volunteerRepository.AddVolunteer(volunteer);
        //     return _mapper.Map<Volunteer>(result);
        // }

        public async Task<Volunteer> AddVolunteer(CreateVolunteerDTO volunteerDTO)
        {
            var volunteer = new Volunteer
            {
                EventID = volunteerDTO.EventID,
                UserID = volunteerDTO.UserID,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };
            var result = await _volunteerRepository.AddVolunteer(volunteer);
            return await _volunteerRepository.GetVolunteerById(result.VolunteerID);
        }
        
        public async Task<VolunteerDTO> ApproveVolunteer(int volunteerId)
        {
            var result = await _volunteerRepository.UpdateVolunteerStatus(volunteerId, "Approved");
            return _mapper.Map<VolunteerDTO>(result);
        }

        public async Task<VolunteerDTO> RejectVolunteer(int volunteerId)
        {
            var result = await _volunteerRepository.UpdateVolunteerStatus(volunteerId, "Rejected");
            return _mapper.Map<VolunteerDTO>(result);
        }
    }
}