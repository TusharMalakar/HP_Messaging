using HP_Messaging.Data;
using HP_Messaging.IServices;
using HP_Messaging.Models;
using HP_Messaging.Models_Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HP_Messaging.Services
{
    public class AuthService : IAuthService
    {
        private ChatContext dbContext;
        
        public AuthService(ChatContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public AuthResponse SignIn(string email, string password)
        {
            AuthResponse authUser =null;
            var hash = !string.IsNullOrEmpty(email) ? GetHash(email) : string.Empty;
            var user = dbContext.ChatUsers.FirstOrDefault(user => user.Email==email);
            if (user != null)
            {
                authUser = ToAuthResponse(user);
                authUser.AuthHash = hash;
                return authUser;
            }
            
            var newChatUser = new ChatUser() { Email = email, Password = password, DateCreated = DateTime.Now };
            dbContext.ChatUsers.Add(newChatUser);
            dbContext.SaveChanges();
            authUser = ToAuthResponse(newChatUser);
            authUser.AuthHash = hash;
            return authUser;
        }

        public static string GetHash(string email)
        {
            SHA256 sha256Hash = SHA256.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(email));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static bool VerifyHash(string input, string hash)
        {
            SHA256 sha256Hash = SHA256.Create();
            // Hash the input.
            var hashOfInput = GetHash(input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }

        private AuthResponse ToAuthResponse(ChatUser chatUser)
        {
            if (chatUser == null) return null;
            return new AuthResponse()
            {
                UserId = chatUser.UserId,
                FirstName = chatUser.FirstName,
                LastName = chatUser.LastName,
                Email = chatUser.Email,
                Password=chatUser.Password,
                DateCreated = chatUser.DateCreated
            };
        }
    }
}
