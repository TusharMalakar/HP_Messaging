using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HP_Messaging.Data.Entities
{
    [Table("MessageReply")]
    public class MessageReply
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageReplyId { get; set; }
        public string Body { get; set; }
        public int MessageId { get; set; }
        public int ActiveStatusId { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
