using HP_Messaging.Models;
using Microsoft.EntityFrameworkCore;

namespace HP_Messaging.Data
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        {

        }
        public DbSet<ChatUser> ChatUsers { get; set; }
        public DbSet<MessageType> MessageTypes { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
