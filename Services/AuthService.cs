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

        public async Task<UserModel> SignIn(UserModel userModel)
        {
            UserModel authUser =null;
            var hash = !string.IsNullOrEmpty(userModel.Email) ? HashHelper.GetHash(userModel.Email) : string.Empty;
            var user = dbContext.Users.FirstOrDefault(user => user.Email== userModel.Email);
            if (user != null)
            {
                authUser = mapper.Map<UserModel>(user);
                authUser.AuthHash = hash;
                return authUser;
            }
            userModel.DateCreated = DateTime.Now;
            var newChatUser = mapper.Map<User>(userModel);
            dbContext.Users.Add(newChatUser);
            await dbContext.SaveChangesAsync();
            authUser = mapper.Map<UserModel>(newChatUser);
            authUser.AuthHash = hash;
            return authUser;
        }
    }
}
