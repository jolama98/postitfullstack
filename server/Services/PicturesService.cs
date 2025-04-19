
using System.Reflection;
using Microsoft.AspNetCore.Http.HttpResults;

namespace postitfullstack.Services;
public class PicturesService
{
    private readonly PicturesRepository _repo;
    private readonly AlbumsService _albumsService;

    public PicturesService(PicturesRepository repo, AlbumsService albumsService)
    {
        _repo = repo;
        _albumsService = albumsService;
    }

    internal Picture CreatePicture(Picture pictureData)
    {
        Album album = _albumsService.GetAlbumById(pictureData.AlbumId);

        if (album.IsArchived)
        {
            throw new Exception(album.Title + " is archived and no longer accepting pictures!");
        }
        Picture picture = _repo.CreatePicture(pictureData);
        return picture;
    }

    internal List<Picture> GetAllPics()
    {
        List<Picture> pictures = _repo.GetAllPics();
        return pictures;
    }

    internal List<Picture> GetPicturesByAlbumId(int albumId)
    {

        List<Picture> pictures = _repo.GetPicturesByAlbumId(albumId);
        return pictures;
    }
}
