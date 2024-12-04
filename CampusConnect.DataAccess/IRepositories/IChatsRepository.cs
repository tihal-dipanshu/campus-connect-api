using CampusConnect.DataAccess.DataModels;

namespace CampusConnect.DataAccess.IRepositories;

public interface IChatsRepository
{
    Task<GroupChat> GetChatByEventId(int eventId);
    Task<GroupChat> CreateChat(GroupChat chat);
    Task<ChatMessage> AddMessage(ChatMessage message);
    Task<IEnumerable<ChatMessage>> GetMessagesByChatId(int chatId);
    Task<IEnumerable<ChatMessage>> GetMessagesByEventId(int chatId);

}