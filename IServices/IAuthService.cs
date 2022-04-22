using HP_Messaging.Models;
using System.Threading.Tasks;

namespace HP_Messaging.IServices
{
    public interface IAuthService
    {
        Task<ChatUserModel> SignIn(string email, string password);
    }
}
