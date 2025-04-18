namespace postitfullstack.Services;

public class AlbumService
{
    private readonly AlbumRepository _repo;

    public AlbumService(AlbumRepository repo)
    {
        _repo = repo;
    }
}
