using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HP_Messaging.Entities
{
    [Table("Message")]
    public class Message
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
        public string Body { get; set; }
        public int MessageTypeId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual MessageType MessageType { get; set; }
        public virtual ChatUser author { get; set; }
    }
}
