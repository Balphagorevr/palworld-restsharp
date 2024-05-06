using Palworld.RESTSharp.ProxyServer;

namespace Palworld.RESTSharp.ProxyService.Database
{
    public interface IUserRepository : IRepository
    {
        Task<int> Add(User user);
        Task<User> Get(int userID);
        Task<User> Get(User user);
        Task<bool> UpdateUser(User player);
        Task<IEnumerable<User>> Get();
        Task<bool> Delete(int userID);
        Task<UserAccessLevel> GetAccessLevel(User userID);
    }
}
