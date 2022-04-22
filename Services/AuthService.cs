using System;
using AutoMapper;
using System.Linq;
using HP_Messaging.Models;
using HP_Messaging.Entities;
using HP_Messaging.Security;
using HP_Messaging.IServices;
using System.Threading.Tasks;

namespace HP_Messaging.Services
{
    public class AuthService : IAuthService
    {
        private ChatContext dbContext;
        private readonly IMapper mapper;

        public AuthService(ChatContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public async Task<ChatUserModel> SignIn(string email, string password)
        {
            ChatUserModel authUser =null;
            var hash = !string.IsNullOrEmpty(email) ? HashHelper.GetHash(email) : string.Empty;
            var user = dbContext.ChatUsers.FirstOrDefault(user => user.Email==email);
            if (user != null)
            {
                authUser = mapper.Map<ChatUserModel>(user);
                authUser.AuthHash = hash;
                return authUser;
            }
            
            var newChatUser = new ChatUser() { Email = email, Password = password, DateCreated = DateTime.Now };
            dbContext.ChatUsers.Add(newChatUser);
            await dbContext.SaveChangesAsync();
            authUser = mapper.Map<ChatUserModel>(user);
            authUser.AuthHash = hash;
            return authUser;
        }
    }
}
