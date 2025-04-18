namespace postitfullstack.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]

public class AlbumsController : ControllerBase
{
    private readonly AlbumsService _albumsService;
    private readonly Auth0Provider _auth0Provider;

    public AlbumsController(AlbumsService albumService, Auth0Provider auth0Provider)
    {
        _albumsService = albumService;
        _auth0Provider = auth0Provider;
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Album>> CreateAlbum([FromBody] Album albumData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            albumData.CreatorId = userInfo.Id;
            Album album = _albumsService.CreateAlbum(albumData);
            return Ok(album);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

}
