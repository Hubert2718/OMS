using System.Reflection.Metadata.Ecma335;

namespace OMS.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext dataContext;

        public UserService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<ServiceResponce<List<User>>> AddUser(User user)
        {
            user.Editing = user.IsNew = false;
            dataContext.Users.Add(user);
            await dataContext.SaveChangesAsync();
            return await GetUsers();
        }

        public async Task<ServiceResponce<List<User>>> DeleteUser(int userId)
        {
            User user = await GetUserById(userId);
            if (user == null)
            {
                return new ServiceResponce<List<User>>
                {
                    Success = false,
                    Message = "User not found."
                };
            }

            user.Deleted = true;
            await dataContext.SaveChangesAsync();

            return await GetUsers();
        }

        private async Task<User> GetUserById(int userId)
        {
            return await dataContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<ServiceResponce<List<User>>> GetUsers()
        {
            var users = await dataContext.Users.ToListAsync();
            return new ServiceResponce<List<User>>
            { 
                Data = users
            };

        }

        public async Task<ServiceResponce<List<User>>> UpdateUser(User user)
        {
            var dbUser = await GetUserById(user.Id);
            if(dbUser == null)
            {
                return new ServiceResponce<List<User>>
                {
                    Success = false,
                    Message = "User not found."
                };
            }

            dbUser.Email = user.Email;
            dbUser.Active = user.Active;
            dbUser.Role = user.Role;

            await dataContext.SaveChangesAsync();

            return await GetUsers();
        }
    }
}
