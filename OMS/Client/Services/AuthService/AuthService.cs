namespace OMS.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;

        public AuthService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ServiceResponce<bool>> ChangePassword(UserChangePassword request)
        {
            var result = await httpClient.PostAsJsonAsync("api/auth/change-password", request.Password);
            return await result.Content.ReadFromJsonAsync<ServiceResponce<bool>>();
        }

        public async Task<ServiceResponce<string>> Login(UserLogin request)
        {
            var result = await httpClient.PostAsJsonAsync("api/auth/login", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponce<string>>();
        }

        public async Task<ServiceResponce<int>> Register(UserRegister request)
        {
            var result = await httpClient.PostAsJsonAsync("api/auth/register", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponce<int>>();
        }
    }
}
