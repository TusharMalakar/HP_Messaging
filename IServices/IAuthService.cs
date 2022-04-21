using HP_Messaging.Models_Data;

namespace HP_Messaging.IServices
{
    public interface IAuthService
    {
        AuthResponse SignIn(string email, string password);
    }
}
