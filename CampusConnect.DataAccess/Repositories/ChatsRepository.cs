
using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CampusConnect.DataAccess.Repositories
{
    public class ChatsRepository : Repository<ChatMessage>, IChatsRepository
    {
        public ChatsRepository(CampusConnectContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ChatMessage>> GetMessagesByChatId(int chatId)
        {
            var messages = await Context.ChatMessages
                .Where(m => m.ChatID == chatId)
                .OrderBy(m => m.SentAt)
                .ToListAsync();
    
            return messages ?? new List<ChatMessage>();
        }

        public async Task<ChatMessage> AddMessage(ChatMessage message)
        {
            await Context.ChatMessages.AddAsync(message);
            await Context.SaveChangesAsync();
            return message;
        }

        public async Task<GroupChat> GetChatByEventId(int eventId)
        {
            return await Context.GroupChats
                .FirstOrDefaultAsync(c => c.EventID == eventId);
        }
        
        public async Task<IEnumerable<ChatMessage>> GetMessagesByEventId(int eventId)
        {
            var groupChat = await Context.GroupChats
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c => c.EventID == eventId);

            return groupChat?.Messages ?? Enumerable.Empty<ChatMessage>();
        }

        public async Task<GroupChat> CreateChat(GroupChat chat)
        {
            await Context.GroupChats.AddAsync(chat);
            await Context.SaveChangesAsync();
            return chat;
        }
    }
}