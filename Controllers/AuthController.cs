using HP_Messaging.Data;
using HP_Messaging.Models;
using HP_Messaging.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HP_Messaging.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private AuthService authService;

        public AuthController(ChatContext _dbContext)
        {
            authService = new AuthService(_dbContext);
        }
        [HttpGet]
        public async Task<ChatUser> SignIn([FromQuery] string email, [FromQuery] string password)
        {
            return await Task.FromResult(authService.SignIn(email, password));
        }

    }
}
