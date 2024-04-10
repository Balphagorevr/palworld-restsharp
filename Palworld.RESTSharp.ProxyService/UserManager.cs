using Palworld.RESTSharp.Common;
using Palworld.RESTSharp.ProxyService.Database;

namespace Palworld.RESTSharp.ProxyService
{
    public interface IUserManager
    {
        Task<bool> TokenHasRoles(string token, string[] roles);
        Task<int> Add(User user);
        Task<IEnumerable<User>> Get();
        Task<User> Get(User user);
        Task UpdateUser(User user);
        Task<bool> Delete(int userID);
    }

    public class UserManager : IUserManager
    {
        IUserRepository userRepository;
        PalworldRESTSharpProxyConfig appConfig;
        public UserManager(
            IUserRepository userRepository,
            IConfiguration config)
        {
            this.userRepository = userRepository;
            appConfig = config.GetSection("PalworldRESTSharpProxyConfig").Get<PalworldRESTSharpProxyConfig>();
        }

        public async Task<bool> TokenHasRoles(string token, string[] roles)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Token required");
            }

            User user = await userRepository.Get(new User() { Token = token });

            if (user == null) return false;

            foreach (string role in user.Roles)
            {
                if (roles.Any(r => r == role))
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<int> Add(User user)
        {
            return await userRepository.Add(user);
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await userRepository.Get();
        }
        public async Task<User> Get(User user)
        {
            return await userRepository.Get(user);
        }
        public async Task UpdateUser(User user)
        {
            await userRepository.UpdateUser(user);
        }
        public async Task<bool> Delete(int userID)
        {
            return await userRepository.Delete(userID);
        }
    }
}
