using System;
using System.ComponentModel.DataAnnotations;

namespace HP_Messaging.Models
{
    public class MessageReplyModel
    {
        public int MessageReplyId { get; set; }
        public string Body { get; set; }
        [Required]
        public int MessageId { get; set; }
        [Required]
        public int ActiveStatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual UserModel User { get; set; }
    }
}
