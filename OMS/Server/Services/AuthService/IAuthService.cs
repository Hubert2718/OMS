namespace OMS.Server.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponce<int>> Register(User user, string password);
        Task<bool> UserExists(string email);
        Task<ServiceResponce<string>> Login(string email, string password);
        Task<ServiceResponce<bool>> ChangePassword(int userId, string newPassword);
    }
}
