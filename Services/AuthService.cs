using HP_Messaging.Data;
using HP_Messaging.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HP_Messaging.Services
{
    public class AuthService 
    {
        private ChatContext dbContext;
        
        public AuthService(ChatContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public ChatUser SignIn(string email, string password)
        {
            var user = dbContext.ChatUsers.FirstOrDefault(user => user.Email==email);
            if (user != null) return user;
            var newChatUser = new ChatUser() { Email = email, Password = password, DateCreated = DateTime.Now };
            dbContext.ChatUsers.Add(newChatUser);
            dbContext.SaveChanges();
            return newChatUser;
        }
    }
}
