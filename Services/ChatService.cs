using System;
using AutoMapper;
using System.Linq;
using HP_Messaging.Models;
using HP_Messaging.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using HP_Messaging.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using HP_Messaging.Data;

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

        public async Task<MessageModel> SaveMessage(MessageModel message)
        {
            var messageEntity = mapper.Map<Message>(message);
            
            string eventType = string.Empty;
            messageEntity.User = null;
            messageEntity.UserId = dbContext.profile.UserId;
            if (messageEntity.MessageId == 0)
            {
                dbContext.Messages.Add(messageEntity);
                eventType = "MessageAdded";
            }
            else
            {
                dbContext.Messages.Update(messageEntity);
                eventType = "MessageUpdated";
                if (messageEntity.ActiveStatusId == (int)ActiveStatusTypeEnum.Edited)
                    eventType = "MessageUpdated";
                if (messageEntity.ActiveStatusId == (int)ActiveStatusTypeEnum.Removed)
                    eventType = "MessageRemoved";
            }
                
            await dbContext.SaveChangesAsync();
            messageEntity.User = dbContext.profile;
            await hubContext.Clients.All.BroadcastMessage(eventType, messageEntity);
            return mapper.Map<MessageModel>(messageEntity);
        }

        public async Task<MessageReplyModel> SaveReply(MessageReplyModel reply)
        {
            var messageReplyEntity = mapper.Map<MessageReply>(reply);
            
            string eventType = string.Empty;
            messageReplyEntity.User = null;
            messageReplyEntity.UserId = dbContext.profile.UserId;
            if (messageReplyEntity.MessageReplyId == 0)
            {
                dbContext.MessageReplies.Add(messageReplyEntity);
                eventType = "MessageReplyAdded";
            }
            else
            {
                dbContext.MessageReplies.Update(messageReplyEntity);
                if(messageReplyEntity.ActiveStatusId == (int)ActiveStatusTypeEnum.Edited)
                    eventType = "MessageReplyUpdated";
                if (messageReplyEntity.ActiveStatusId == (int)ActiveStatusTypeEnum.Removed)
                    eventType = "MessageReplyRemoved";
            }
                
            await dbContext.SaveChangesAsync();
            messageReplyEntity.User = dbContext.profile;
            await hubContext.Clients.All.BroadcastMessage(eventType, messageReplyEntity);
            return mapper.Map<MessageReplyModel>(messageReplyEntity);
        }

        public List<MessageModel> GetMessages()
        {
            var messages = dbContext.Messages.Where(message => message.MessageId > 0)
                            .AsNoTracking()
                            .Include(msg => msg.User)
                            .Include(msg => msg.MessageReplys);

            return mapper.Map<List<MessageModel>>(messages);
        }

    }
}
