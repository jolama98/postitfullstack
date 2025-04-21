public class Watcher : RepoItem<int>
{
    public string AccountId { get; set; }
    public int AlbumId { get; set; }
}

public class WatcherProfile : Profile
{
    public int WatcherId { get; set; }
    public int AlbumId { get; set; }
}

public class WatcherAlbum : Album
{
    public int WatcherId { get; set; }
    public string AccountId { get; set; }
}