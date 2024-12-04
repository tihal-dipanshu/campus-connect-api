using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using CampusConnect.API.Hubs;
using CampusConnect.Business.DTO;
using CampusConnect.Business.IService;
using CampusConnect.DataAccess.DataModels;

namespace CampusConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatsService _chatsService;
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatsController(IChatsService chatsService, IHubContext<ChatHub> hubContext)
        {
            _chatsService = chatsService;
            _hubContext = hubContext;
        }
        

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessageDTO message)
        {
            var savedMessage = await _chatsService.AddMessage(message);
            await _hubContext.Clients.Group(message.GroupChatId.ToString())
                .SendAsync("ReceiveMessage", savedMessage.UserID, savedMessage.MessageContent);
            return Ok(savedMessage);
        }

        [HttpGet("{chatId}")]
        public async Task<IActionResult> GetMessagesByChatId(int chatId)
        {
            var messages = await _chatsService.GetMessagesByChatId(chatId);
            return Ok(messages);
        }
        
        [HttpGet("event/{eventId}/messages")]
        public async Task<IActionResult> GetMessagesByEventId(int eventId)
        {
            var messages = await _chatsService.GetMessagesByEventId(eventId);
            return Ok(messages);
        }
        
        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetChatByEventId(int eventId)
        {
            var chat = await _chatsService.GetChatByEventId(eventId);
            if (chat == null)
                return NotFound();
            return Ok(chat);
        }
        
        [HttpPost("event/{eventId}")]
        public async Task<IActionResult> CreateChatForEvent(int eventId)
        {
            var chat = await _chatsService.CreateChatForEvent(eventId);
            return CreatedAtAction(nameof(GetChatByEventId), new { eventId = chat.EventID }, chat);
        }
    }
}