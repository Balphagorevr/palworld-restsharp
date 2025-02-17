using Palworld.RESTSharp.ProxyServer;

namespace Palworld.RESTSharp.ProxyService.Database
{
    public interface IPlayerRepository
    {
        Task<int> AddOrUpdate(TrackedPlayer user);
        Task<TrackedPlayer> Get(int trackedPlayerID);
        Task<TrackedPlayer> DeletePlayer(int trackedPlayerID);
    }

    public class TrackedPlayer
    {

    }
}
