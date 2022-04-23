using AutoMapper;
using HP_Messaging.Entities;
using HP_Messaging.Models;
using HP_Messaging.Security;
using HP_Messaging.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace HP_Messaging.Controllers
{
    [CustomRouteAuthorize]
    [ApiController]
    [Route("chat")]
    public class MessaginController : ControllerBase
    {
        private ChatService chatService;
        public MessaginController(ChatContext _dbContext, IMapper _mapper)
        {
            chatService = new ChatService(_dbContext, _mapper);
        }

        [HttpGet]
        [Route("[action]")]
        public List<MessageModel> GetMessages()
        {
            return chatService.GetMessages();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<MessageModel> SendMsg([FromBody] MessageModel message)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            return await chatService.SendMessage(message);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<MessageReplyModel> ReplyMsg([FromBody] MessageReplyModel reply)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            return await chatService.ReplyMessage(reply);
        }
    }
}
