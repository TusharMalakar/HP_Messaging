using HP_Messaging.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HP_Messaging.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private AppSettings appSetting;
        public AuthController()
        {
            appSetting = new AppSettings();
        }
        [HttpGet]
        public ChatUser SignIn([FromQuery] int email, [FromQuery] int password)
        {

            var temp = appSetting.SqlConnection;
            return new ChatUser();
        }

    }
}
