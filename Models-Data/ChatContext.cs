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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatUser>().HasKey(t => new
            {
                t.UserId
            });
            modelBuilder.Entity<MessageType>().HasKey(t => new
            {
                t.MessageTypeId
            });
            modelBuilder.Entity<Message>().HasKey(t => new
            {
                t.MessageId
            });
        }
    }
}
