using System;

namespace HP_Messaging.Models
{
    public class MessageModel
    {
        public int MessageId { get; set; }
        public string Body { get; set; }
        public int MessageTypeId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual MessageTypeModel MessageType { get; set; }
        public virtual ChatUserModel author { get; set; }
    }
}
