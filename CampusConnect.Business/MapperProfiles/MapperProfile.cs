using AutoMapper;
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
        }
    }
}