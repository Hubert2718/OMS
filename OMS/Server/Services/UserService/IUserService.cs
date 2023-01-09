namespace OMS.Server.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponce<List<User>>> GetUsers();
        Task<ServiceResponce<List<User>>> AddUser(User user);
        Task<ServiceResponce<List<User>>> UpdateUser(User user);
        Task<ServiceResponce<List<User>>> DeleteUser(int userId);
    }
}
