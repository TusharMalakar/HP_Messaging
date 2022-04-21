using HP_Messaging.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HP_Messaging.Controllers
{
    [ApiController]
    [Route("chat")]
    public class MessaginController : ControllerBase
    {

        [HttpGet]
        public object SendMsg([FromBody] Message message)
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
