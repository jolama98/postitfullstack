
using System.Reflection;

namespace postitfullstack.Services;

public class PictureService
{
    private readonly PictureRepository _repo;

    public PictureService(PictureRepository repo)
    {
        _repo = repo;
    }

    internal Picture CreatePicture(Picture pictureData)
    {
        Picture picture = _repo.CreatePicture(pictureData);
        return picture;
    }
    /*
      internal Poem CreatePoem(Poem poemData)
    {
        Poem poem = _poemRepository.CreatePoem(poemData);
        return poem;
    }
    */

    internal List<Picture> GetAllPics()
    {
        List<Picture> pictures = _repo.GetAllPics();
        return pictures;
    }
}
