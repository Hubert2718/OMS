using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace OMS.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext dataContext;

        public AuthService(DataContext dataContext, IConfiguration configuration)
        {
            this.dataContext = dataContext;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task<ServiceResponce<string>> Login(string email, string password)
        {
            var response = new ServiceResponce<string>();
            var user = await dataContext.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
            if (user == null)
            {
                response.Success = false;
                response.Message = "Wrong email or password";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong email or password";
            }
            else
            {
                /*
                var userUpdate = new User() {
                    Id = user.Id,
                    LastLogin = DateTime.Now
                };
                dataContext.Users.Attach(userUpdate);
                dataContext.Entry(userUpdate).Property(x => x.LastLogin).IsModified = true;
                dataContext.SaveChanges();
                */

                response.Data = CreateToken(user);
            }
            return response;
        }

        public async Task<ServiceResponce<int>> Register(User user, string password)
        {
            if(await UserExists(user.Email))
            {
                return new ServiceResponce<int>
                {
                    Success = false,
                    Message = $"User with email: {user.Email} alreasy exists.\nPlease provide another email."
                };
            }

            CreatePasswordHash(password, out byte[] passordHash, out byte[] passwordSalt);

            user.PasswordHash = passordHash;
            user.PasswordSalt = passwordSalt;

            dataContext.Users.Add(user);
            await dataContext.SaveChangesAsync();

            return new ServiceResponce<int>
            {
                Data = user.Id,
                Message = "Registration successful!"
            };
        }

        public async Task<bool> UserExists(string email)
        {
            if(await dataContext.Users.AnyAsync(user => user.Email.ToLower().Equals(email.ToLower())))
                return true;
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<ServiceResponce<bool>> ChangePassword(int userId, string newPassword)
        {
            var user = await dataContext.Users.FindAsync(userId);
            if(user == null)
            {
                return new ServiceResponce<bool>
                {
                    Success = false,
                    Message = "User not found."
                };
            }
            CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await dataContext.SaveChangesAsync();

            return new ServiceResponce<bool>
            {
                Data = true,
                Message = "Password has been changed"
            };
        }
    }
}
