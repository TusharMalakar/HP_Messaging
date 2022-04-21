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

        public object SignIn(string email, string password)
        {
            var temp = dbContext.ChatUsers.FirstOrDefault();
            //SqlHelper.CreateCommand("SELECT TOP (1) [MessageId],[Body],[CreatedBy] ,[CreatedDate],[MessageTypeId] FROM[Messaging].[dbo].[Message]", "Server=localhost;Database=MessagingDB;Trusted_Connection=True;");
            return null;
        }
    }
}
