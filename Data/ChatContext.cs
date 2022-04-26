using HP_Messaging.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HP_Messaging.Data
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        {

        }
        public User profile { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageReply> MessageReplies { get; set; }
    }
}
