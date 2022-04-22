using HP_Messaging.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HP_Messaging.IServices
{
    public interface IChatService
    {
        Task<List<MessageModel>> GetMessages();
        Task<MessageModel> SendMessage(MessageModel message);
    }
}
