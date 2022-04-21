using HP_Messaging.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HP_Messaging.Data
{
    public class MessagingDb : DbContext
    {
        public MessagingDb(string connString)
        {
            //this.Database.Connection.ConnectionString = connString;//
        }
        public DbSet<Message> Messages { get; set; }
    }
}
