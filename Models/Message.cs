using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HP_Messaging.Models
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MessageId { get; set; }
        public string Body { get; set; }
        public int MessageTypeId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual MessageType MessageType { get; set; }
    }
}
