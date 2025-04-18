namespace postitfullstack.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]

public class AlbumController : ControllerBase
{
    private readonly AlbumService _albumService;
    private readonly Auth0Provider _auth0Provider;

    public AlbumController(AlbumService albumService, Auth0Provider auth0Provider)
    {
        _albumService = albumService;
        _auth0Provider = auth0Provider;
    }



}
