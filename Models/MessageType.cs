using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HP_Messaging.Models
{
    public class MessageType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MessageTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
