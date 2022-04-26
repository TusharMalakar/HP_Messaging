using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HP_Messaging.Data.Entities
{
    [Table("Message")]
    public class Message
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
        public string Body { get; set; }
        public int ActiveStatusId { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<MessageReply> MessageReplys { get; set; }
       
    }
}
