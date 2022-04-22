using AutoMapper;
using HP_Messaging.Models;
using HP_Messaging.Services;
using HP_Messaging.Security;
using HP_Messaging.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace HP_Messaging.Controllers
{
    [CustomRouteAuthorize]
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private AuthService authService;

        public AuthController(ChatContext _dbContext, IMapper _mapper)
        {
            authService = new AuthService(_dbContext, _mapper);
        }
        [HttpGet]
        public async Task<ChatUserModel> SignIn([FromQuery] string email, [FromQuery] string password)
        {
            return await authService.SignIn(email, password);
        }

    }
}
