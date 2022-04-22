using HP_Messaging.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HP_Messaging.IServices
{
    public interface IChatService
    {
        List<MessageModel> GetMessages();
        Task<MessageModel> SendMessage(MessageModel message);
        Task<MessageReplyModel> ReplyMessage(MessageReplyModel reply);
    }
}
