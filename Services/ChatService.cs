using System;
using HP_Messaging.Models;
using HP_Messaging.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HP_Messaging.Services
{
    public class ChatService : IChatService
    {
        public Task<List<MessageModel>> GetMessages()
        {
            throw new NotImplementedException();
        }

        public Task<MessageModel> SendMessage(MessageModel message)
        {
            throw new NotImplementedException();
        }
    }
}
