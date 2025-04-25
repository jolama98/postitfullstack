


namespace postitfullstack.Services;

public class WatchersService
{
    private readonly WatchersRepository _watchersRepository;

    public WatchersService(WatchersRepository watchersRepository)
    {
        _watchersRepository = watchersRepository;
    }

    internal Watcher CreateWatcher(Watcher watcherData)
    {
        Watcher watcher = _watchersRepository.CreateWatcher(watcherData);
        return watcher;
    }

    internal List<WatcherAlbum> GetMyWatcherAlbum(string accountId)
    {
        List<WatcherAlbum> watcherAlbums = _watchersRepository.GetMyWatcherAlbum(accountId);
        return watcherAlbums;
    }

    internal List<WatcherProfile> GetWatcherProfilesByAlbumId(int albumId)
    {
        List<WatcherProfile> watcherProfiles = _watchersRepository.GetWatcherProfilesByAlbumId(albumId);
        return watcherProfiles;
    }
}
