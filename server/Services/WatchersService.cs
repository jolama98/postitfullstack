
namespace postitfullstack.Services;

public class WatchersService
{
    private readonly WatchersRepository _watchersRepository;

    public WatchersService(WatchersRepository watchersRepository)
    {
        _watchersRepository = watchersRepository;
    }

    internal WatcherProfile CreateWatcher(Watcher watcherData)
    {
        WatcherProfile watcherProfile = _watchersRepository.CreateWatcher(watcherData);
        return watcherProfile;
    }
}
