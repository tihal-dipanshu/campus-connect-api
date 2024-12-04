using AutoMapper;
using CampusConnect.Business.DTO;
using CampusConnect.Business.IService;
using CampusConnect.DataAccess.DataModels;

namespace CampusConnect.Business.Service;

public class ChatsService : IChatsService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork.IUnitOfWork _unitOfWork;

    public ChatsService(IMapper mapper, IUnitOfWork.IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ChatMessage> SaveMessage(ChatMessage message)
    {
        var chatMessage = _mapper.Map<ChatMessage>(message);
        chatMessage.SentAt = DateTime.UtcNow;

        await _unitOfWork.ChatsRepository.AddMessage(chatMessage);
        _unitOfWork.Save();

        return _mapper.Map<ChatMessage>(chatMessage);
    }

    public async Task<GroupChat> GetChatByEventId(int eventId)
    {
        var chat = await _unitOfWork.ChatsRepository.GetChatByEventId(eventId);
        return _mapper.Map<GroupChat>(chat);
    }
    
    public async Task<IEnumerable<ChatMessage>> GetMessagesByEventId(int eventId)
    {
        var messages = await _unitOfWork.ChatsRepository.GetMessagesByEventId(eventId);
        return _mapper.Map<IEnumerable<ChatMessage>>(messages);
    }

    public async Task<GroupChat> CreateChatForEvent(int eventId)
    {
        var newChat = new GroupChat
        {
            EventID = eventId,
            CreatedAt = DateTime.UtcNow
        };
        var createdChat = await _unitOfWork.ChatsRepository.CreateChat(newChat);
        return _mapper.Map<GroupChat>(createdChat);
    }

    public async Task<ChatMessage> AddMessage(ChatMessageDTO message)
    {
        var newMessage = new ChatMessage
        {
            ChatID = message.GroupChatId,
            UserID = message.UserId,
            MessageContent = message.Message,
            SentAt = DateTime.UtcNow
        };
        
        var chatMessage = _mapper.Map<ChatMessage>(newMessage);
        chatMessage.SentAt = DateTime.UtcNow;

        var addedMessage = await _unitOfWork.ChatsRepository.AddMessage(chatMessage);
        return _mapper.Map<ChatMessage>(addedMessage);
    }

    public async Task<IEnumerable<ChatMessage>> GetMessagesByChatId(int chatId)
    {
        if (_unitOfWork.ChatsRepository == null)
        {
            throw new InvalidOperationException("ChatsRepository is not initialized.");
        }
    
        return await _unitOfWork.ChatsRepository.GetMessagesByChatId(chatId);
    }
}