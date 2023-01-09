namespace OMS.Client.Services.UserService
{
    public interface IUserService
    {
        event Action OnChange;
        List<User> Users { get; set; }
        String[] Roles { get; set; }
        Task GetUsers();
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int userId);
        User CreateNewUser();
    }
}
