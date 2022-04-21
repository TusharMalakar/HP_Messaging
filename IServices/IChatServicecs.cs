using HP_Messaging.Models;
using System.Collections.Generic;

namespace HP_Messaging.IServices
{
    public interface IChatServicecs
    {
        List<Message> GetMessages();
        Message SendMessage(Message message);
    }
}
