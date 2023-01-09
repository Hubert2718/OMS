namespace OMS.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponce<int>> Register(UserRegister request);
        Task<ServiceResponce<string>> Login(UserLogin request);
        Task<ServiceResponce<bool>> ChangePassword(UserChangePassword request);
    }
}
