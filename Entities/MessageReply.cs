using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HP_Messaging.Entities
{
    [Table("MessageReply")]
    public class MessageReply
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageReplyId { get; set; }
        public int MessageId { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
