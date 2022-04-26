using AutoMapper;
using HP_Messaging.Models;
using HP_Messaging.Services;
using HP_Messaging.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace HP_Messaging.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private AuthService authService;

        public AuthController(ChatContext _dbContext, IMapper _mapper)
        {
            authService = new AuthService(_dbContext, _mapper);
        }
        [HttpPost]
        public async Task<UserModel> SignIn([FromBody] UserModel userModel)
        {
            return await authService.SignIn(userModel);
        }

    }
}
