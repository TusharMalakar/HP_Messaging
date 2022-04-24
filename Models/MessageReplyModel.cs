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
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public virtual UserModel User { get; set; }
    }
}
