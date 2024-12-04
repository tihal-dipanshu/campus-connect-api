using CampusConnect.Business.DTO;
using CampusConnect.DataAccess.DataModels;

namespace CampusConnect.Business.IService;

public interface IChatsService
{
    Task<GroupChat> GetChatByEventId(int eventId);
    Task<GroupChat> CreateChatForEvent(int eventId);
    Task<ChatMessage> AddMessage(ChatMessageDTO message);
    Task<IEnumerable<ChatMessage>> GetMessagesByChatId(int chatId);
    Task<ChatMessage> SaveMessage(ChatMessage message);
    Task<IEnumerable<ChatMessage>> GetMessagesByEventId(int chatId);
}

