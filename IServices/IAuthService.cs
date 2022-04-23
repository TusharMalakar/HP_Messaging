using HP_Messaging.Models;
using System.Threading.Tasks;

namespace HP_Messaging.IServices
{
    public interface IAuthService
    {
        Task<UserModel> SignIn(UserModel userModel);
    }
}
