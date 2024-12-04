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
            
            CreateMap<EventAttendee, EventAttendeeDTO>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Event, opt => opt.MapFrom(src => src.Event));
            
            CreateMap<CreateEventDTO, Event>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => 1));
        }
    }
}