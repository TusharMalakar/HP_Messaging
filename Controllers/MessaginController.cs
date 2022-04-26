using AutoMapper;
using HP_Messaging.Models;
using HP_Messaging.Security;
using HP_Messaging.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using HP_Messaging.Data;

namespace HP_Messaging.Controllers
{
    [CustomRouteAuthorize]
    [ApiController]
    [Route("chat")]
    public class MessaginController : ControllerBase
    {
        private ChatService chatService;
        public MessaginController(ChatContext _dbContext, IMapper _mapper, IHubContext<BroadcastHub, IHubClient> _hubContext)
        {
            chatService = new ChatService(_dbContext, _mapper, _hubContext);
        }

        [HttpGet]
        [Route("[action]")]
        public List<MessageModel> GetMessages()
        {
            return chatService.GetMessages();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<MessageModel> SaveMessage([FromBody] MessageModel message)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            return await chatService.SaveMessage(message);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<MessageReplyModel> SaveReply([FromBody] MessageReplyModel reply)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            return await chatService.SaveReply(reply);
        }
    }
}
