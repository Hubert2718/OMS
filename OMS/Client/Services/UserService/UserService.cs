using System.Runtime.InteropServices;

namespace OMS.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;
        public List<User> Users { get; set; } = new List<User>();

        public string[] Roles { get; set; } = new string[2] { "Admin", "Regular User" };

        public event Action OnChange;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task AddUser(User user)
        {
            var response = await httpClient.PostAsJsonAsync("api/user", user);
            Users = (await response.Content.ReadFromJsonAsync<ServiceResponce<List<User>>>()).Data;
            OnChange.Invoke();
        }

        public User CreateNewUser()
        {
            var newUser = new User { IsNew = true, Editing = true};
            Users.Add(newUser);
            OnChange.Invoke();
            return newUser;
        }

        public async Task DeleteUser(int userId)
        {
            var response = await httpClient.DeleteAsync($"api/user/{userId}");
            Users = (await response.Content.ReadFromJsonAsync<ServiceResponce<List<User>>>()).Data;
            OnChange.Invoke();
        }

        public async Task GetUsers()
        {
            var response = await httpClient.GetFromJsonAsync<ServiceResponce<List<User>>>("api/user");
            if (response != null && response.Data != null)
                Users = response.Data;
        }

        public async Task UpdateUser(User user)
        {
            var response = await httpClient.PutAsJsonAsync("api/user", user);
            Users = (await response.Content.ReadFromJsonAsync<ServiceResponce<List<User>>>()).Data;
            OnChange.Invoke();
        }
    }
}
