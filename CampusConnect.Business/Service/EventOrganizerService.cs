using AutoMapper;
using CampusConnect.Business.DTO;
using CampusConnect.Business.IService;
using CampusConnect.DataAccess.IRepositories;

namespace CampusConnect.Business.Service
{
    public class EventOrganizerService : IEventOrganizerService
    {
        private readonly IEventOrganizerRepository _eventOrganizerRepository;
        private readonly IMapper _mapper;

        public EventOrganizerService(IEventOrganizerRepository eventOrganizerRepository, IMapper mapper)
        {
            _eventOrganizerRepository = eventOrganizerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventOrganizerDTO>> GetAllEventOrganizers()
        {
            var organizers = await _eventOrganizerRepository.GetAllEventOrganizers();
            return _mapper.Map<IEnumerable<EventOrganizerDTO>>(organizers);
        }

        public async Task<IEnumerable<EventOrganizerDTO>> GetOrganizersByEventId(int eventId)
        {
            var organizers = await _eventOrganizerRepository.GetOrganizersByEventId(eventId);
            return _mapper.Map<IEnumerable<EventOrganizerDTO>>(organizers);
        }

        public async Task<EventOrganizerDTO> GetOrganizerById(int userId)
        {
            var organizer = await _eventOrganizerRepository.GetOrganizerById(userId);
            return _mapper.Map<EventOrganizerDTO>(organizer);
        }

        public async Task<IEnumerable<EventDTO>> GetEventsByOrganizerId(int userId)
        {
            var events = await _eventOrganizerRepository.GetEventsByOrganizerId(userId);
            return _mapper.Map<IEnumerable<EventDTO>>(events);
        }
    }
}