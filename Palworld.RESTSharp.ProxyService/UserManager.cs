using Palworld.RESTSharp.ProxyServer;
using Palworld.RESTSharp.ProxyService.Database;

namespace Palworld.RESTSharp.ProxyService
{
    public interface IUserManager
    {
        Task<int> Add(User user);
        Task<IEnumerable<User>> Get();
        Task<User> Get(User user);
        Task UpdateUser(User user);
        Task<bool> Delete(int userID);
        Task<UserAccessLevel> GetAccessLevel(User user);
    }

    public class UserManager : IUserManager
    {
        IUserRepository userRepository;

        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
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

        public async Task<UserAccessLevel> GetAccessLevel(User user)
        {
            return await userRepository.GetAccessLevel(user);
        }
    }
}
