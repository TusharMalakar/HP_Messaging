using HP_Messaging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HP_Messaging.Models_Data
{
    public class AuthResponse: ChatUser
    {
        public string AuthHash { get; set; }
    }
}
