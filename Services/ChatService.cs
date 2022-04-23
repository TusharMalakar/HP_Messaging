using System;
using AutoMapper;
using System.Linq;
using HP_Messaging.Models;
using HP_Messaging.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using HP_Messaging.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;

namespace HP_Messaging.Services
{
    public class ChatService : IChatService
    {
        private ChatContext dbContext;
        private readonly IMapper mapper;
        private readonly IHubContext<BroadcastHub, IHubClient> hubContext;

        public ChatService(ChatContext _dbContext, IMapper _mapper, IHubContext<BroadcastHub, IHubClient> _hubContext)
        {
            dbContext = _dbContext;
            mapper = _mapper;
            hubContext = _hubContext;
        }

        public async Task<MessageModel> SendMessage(MessageModel message)
        {
            var messageEntity = mapper.Map<Message>(message);
            messageEntity.User = dbContext.profile;

            if(messageEntity.MessageId == 0)
                dbContext.Messages.Add(messageEntity);
            else
                dbContext.Messages.Update(messageEntity);

            await dbContext.SaveChangesAsync();
            await hubContext.Clients.All.BroadcastMessage("Message", messageEntity);
            return mapper.Map<MessageModel>(messageEntity);
        }

        public async Task<MessageReplyModel> ReplyMessage(MessageReplyModel reply)
        {
            var messageReplyEntity = mapper.Map<MessageReply>(reply);
            messageReplyEntity.User = dbContext.profile;

            if (messageReplyEntity.MessageReplyId == 0)
                dbContext.MessageReplies.Add(messageReplyEntity);
            else
                dbContext.MessageReplies.Update(messageReplyEntity);

            dbContext.MessageReplies.Add(messageReplyEntity);
            await dbContext.SaveChangesAsync();
            await hubContext.Clients.All.BroadcastMessage("MessageReply", messageReplyEntity);
            return mapper.Map<MessageReplyModel>(messageReplyEntity);
        }

        public List<MessageModel> GetMessages()
        {
            var messages = dbContext.Messages.Where(message => message.MessageId > 0)
                            .Include(msg => msg.User)
                            .Include(msg => msg.MessageReplys);

            return mapper.Map<List<MessageModel>>(messages);
        }

    }
}
