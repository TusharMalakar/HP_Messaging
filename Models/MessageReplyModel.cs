using System;
using System.ComponentModel.DataAnnotations;

namespace HP_Messaging.Models
{
    public class MessageReplyModel
    {
        public int MessageReplyId { get; set; }
        [Required]
        public int MessageId { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public virtual UserModel User { get; set; }
    }
}
