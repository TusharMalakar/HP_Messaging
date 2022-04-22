﻿using HP_Messaging.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HP_Messaging.Controllers
{
    [ApiController]
    [Route("chat")]
    public class MessaginController : ControllerBase
    {

        [HttpGet]
        public object SendMsg([FromBody] MessageModel message)
        {
            return "welcome";
        }

        [HttpGet]
        [Route("[action]")]
        public List<object> GetObjs()
        {
            return new List<object>();
        }
    }
}
