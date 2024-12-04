using AutoMapper;
using CampusConnect.Business.DTO;
using CampusConnect.Business.IService;
using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.IRepositories;

namespace CampusConnect.Business.Service
{
    public class EventAttendeeService : IEventAttendeeService
    {
        private readonly IEventAttendeeRepository _eventAttendeeRepository;
        private readonly IEventsService _eventsService;
        private readonly IMapper _mapper;

        public EventAttendeeService(IEventAttendeeRepository eventAttendeeRepository, IEventsService eventsService, IMapper mapper)
        {
            _eventAttendeeRepository = eventAttendeeRepository;
            _eventsService = eventsService;
            _mapper = mapper;
        }

        public async Task<EventAttendee> AddAttendee(int eventId, int userId)
        {
            return await _eventAttendeeRepository.AddAttendee(eventId, userId);
        }

        public async Task RemoveAttendee(int eventId, int userId)
        {
            await _eventAttendeeRepository.RemoveAttendee(eventId, userId);
        }

        public async Task<IEnumerable<EventAttendeeDTO>> GetAllAttendees()
        {
            var attendees = await _eventAttendeeRepository.GetAllAttendees();
            return _mapper.Map<IEnumerable<EventAttendeeDTO>>(attendees);
        }

        // public async Task<IEnumerable<EventAttendee>> GetAttendeesByEventId(int eventId)
        // {
        //     return await _eventAttendeeRepository.GetAttendeesByEventId(eventId);
        // }
        
        public async Task<IEnumerable<EventAttendeeDTO>> GetAttendeesByEventId(int eventId)
        {
            var attendees = await _eventAttendeeRepository.GetAttendeesByEventId(eventId);
            return _mapper.Map<IEnumerable<EventAttendeeDTO>>(attendees);
        }

        public async Task<IEnumerable<Event>> GetEventsByUserId(int userId)
        {
            return await _eventAttendeeRepository.GetEventsByUserId(userId);
        }
    }
}