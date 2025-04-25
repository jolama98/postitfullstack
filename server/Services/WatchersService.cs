



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

    private Watcher GetWatcherById(int watcherId)
    {
        Watcher watcher = _watchersRepository.GetWatcherById(watcherId);

        if (watcher == null)
        {
            throw new Exception("Invalid watcher id: " + watcherId);
        }
        return watcher;
    }

    internal void DeleteWatcher(int watcherId, Account userInfo)
    {
        Watcher watcher = GetWatcherById(watcherId);

        if (watcher.AccountId != userInfo.Id)
        {
            throw new Exception($"YOU CANNOT DELETE ANOTHER USER'S WATCHER, {userInfo.Name.ToUpper()}!!!");
        }

        _watchersRepository.DeleteWatcher(watcherId);
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
