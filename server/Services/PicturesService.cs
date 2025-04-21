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

        if (album.Archived)
        {
            throw new Exception(album.Title + " is archived and no longer accepting pictures!");
        }
        Picture picture = _repo.CreatePicture(pictureData);
        return picture;
    }
    private Picture GetPictureById(int pictureId)
    {
        Picture picture = _repo.GetPictureById(pictureId);

        if (picture == null)
        {
            throw new Exception("Invalid picture id: " + pictureId);
        }

        return picture;
    }

    internal void DeletePicture(int pictureId, Account userInfo)
    {
        Picture picture = GetPictureById(pictureId);

        if (picture.CreatorId != userInfo.Id)
        {
            throw new Exception($"YOU CAN NOT DELETE ANOTHER USER'S PICTURE, {userInfo.Name.ToUpper()}!");
        }

        _repo.DeletePicture(pictureId);
    }


    internal List<Picture> GetPicturesByAlbumId(int albumId)
    {

        List<Picture> pictures = _repo.GetPicturesByAlbumId(albumId);
        return pictures;
    }
}
