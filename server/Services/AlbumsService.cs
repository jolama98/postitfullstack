


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

    internal Album GetAlbumById(int albumId)
    {
        Album album = _repo.GetAlbumById(albumId);
        if (album == null)
        {
            throw new Exception("No album found with the id of " + albumId);
        }
        return album;
    }

    internal Album ArchiveAlbum(int albumId, Account userInfo)
    {
        Album album = GetAlbumById(albumId);

        if (album.CreatorId != userInfo.Id)
        {
            throw new Exception($"YOU CANNOT ARCHIVE ANOTHER USER'S ALBUM, {userInfo.Name.ToUpper()}!");
        }

        album.Archived = !album.Archived;

        _repo.ArchiveAlbum(album);

        return album;
    }


    internal List<Album> GetAllAlbums()
    {
        List<Album> albums = _repo.GetAllAlbums();
        return albums;
    }
}
