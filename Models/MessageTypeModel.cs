using System;

namespace HP_Messaging.Models
{
    public class MessageTypeModel
    { 
        public int MessageTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
