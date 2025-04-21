namespace postitfullstack.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]

public class AlbumsController : ControllerBase
{
    private readonly AlbumsService _albumsService;
    private readonly Auth0Provider _auth0Provider;
    private readonly PicturesService _picturesService;

    public AlbumsController(AlbumsService albumService, Auth0Provider auth0Provider, PicturesService picturesService)
    {
        _albumsService = albumService;
        _auth0Provider = auth0Provider;
        _picturesService = picturesService;
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

    [HttpGet]
    public ActionResult<List<Album>> GetAllAlbums()
    {
        try
        {
            List<Album> albums = _albumsService.GetAllAlbums();
            return Ok(albums);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpGet("{albumId}")]
    public async Task<ActionResult<Album>> GetAlbumById(int albumId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            Album album = _albumsService.GetAlbumById(albumId);
            return Ok(album);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
    [Authorize]
    [HttpDelete("{albumId}")]
    public async Task<ActionResult<Album>> DestroyAlbum(int albumId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            Album album = _albumsService.ArchiveAlbum(albumId, userInfo);
            return Ok(album);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
    [HttpGet("{albumId}/pictures")]
    public ActionResult<List<Picture>> GetPicturesByAlbumId(int albumId)
    {
        try
        {
            List<Picture> pictures = _picturesService.GetPicturesByAlbumId(albumId);
            return Ok(pictures);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }

    }

}

