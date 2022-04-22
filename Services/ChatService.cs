using System;
using AutoMapper;
using System.Linq;
using HP_Messaging.Models;
using HP_Messaging.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using HP_Messaging.Entities;
using Microsoft.EntityFrameworkCore;

namespace HP_Messaging.Services
{
    public class ChatService : IChatService
    {
        private ChatContext dbContext;
        private readonly IMapper mapper;

        public ChatService(ChatContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public async Task<MessageModel> SendMessage(MessageModel message)
        {
            var messageEntity = mapper.Map<Message>(message);
            dbContext.Messages.Add(messageEntity);
            await dbContext.SaveChangesAsync();
            return mapper.Map<MessageModel>(messageEntity);
        }

        public async Task<MessageReplyModel> ReplyMessage(MessageReplyModel reply)
        {
            var messageEntity = mapper.Map<MessageReply>(reply);
            dbContext.MessageReplies.Add(messageEntity);
            await dbContext.SaveChangesAsync();
            return mapper.Map<MessageReplyModel>(messageEntity);
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
