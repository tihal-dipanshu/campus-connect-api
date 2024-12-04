using AutoMapper;
using CampusConnect.Business.DTO;
using CampusConnect.Business.Entities;
using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.DataModels.CampusConnect.DataAccess.DataModels;

namespace CampusConnect.Business.MapperProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateBusinessUnitMapping();
        }

        private void CreateBusinessUnitMapping()
        {
            CreateMap<User, UserModel>();
            CreateMap<LoginModel, User>();
            CreateMap<Event, EventModel>();
            CreateMap<ChatMessage, ChatMessageModel>();
            CreateMap<GroupChat, GroupChatModel>();
            //CreateMap<EventAttendee, EventAttendeeDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<Event, EventDTO>();
            CreateMap<UserAccountInfoDTO, User>();
            CreateMap<CreateUserDTO, User>();
            CreateMap<CreateEventCategoryDTO, EventCategory>();
            CreateMap<EventCategory, EventCategoryDTO>().ReverseMap();
            CreateMap<Volunteer, VolunteerDTO>();
            CreateMap<VolunteerDTO, Volunteer>().ReverseMap();
            CreateMap<CreateVolunteerDTO, Volunteer>();
            CreateMap<EventOrganizer, EventOrganizerDTO>();
            
            CreateMap<EventAttendee, EventAttendeeDTO>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Event, opt => opt.MapFrom(src => src.Event));
            
            CreateMap<CreateEventDTO, Event>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => 1));
        }
    }
}