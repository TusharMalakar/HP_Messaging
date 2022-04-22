using System;

namespace HP_Messaging.Models
{
    public class ChatUserModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public string AuthHash { get; set; }
    }
}
