

namespace postitfullstack.Services;

public class AlbumsService
{
    private readonly AlbumsRepository _repo;

    public AlbumsService(AlbumsRepository repo)
    {
        _repo = repo;
    }

    internal Album CreateAlbum(Album albumData)
    {

        Album album = _repo.CreateAlbum(albumData);
        return album;
    }

    internal List<Album> GetAllAlbums()
    {
        List<Album> albums = _repo.GetAllAlbums();
        return albums;
    }
}
