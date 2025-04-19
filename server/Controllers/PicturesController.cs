namespace postitfullstack.Controllers;


[ApiController]
[Route("api/[controller]")]

public class PicturesController : ControllerBase
{
    private readonly PicturesService _picturesService;
    private readonly Auth0Provider _auth0Provider;

    public PicturesController(PicturesService picturesService, Auth0Provider auth0Provider)
    {
        _picturesService = picturesService;
        _auth0Provider = auth0Provider;
    }

    [HttpGet]
    public ActionResult<List<Picture>> GetAllPics()

    {
        try
        {
            List<Picture> picture = _picturesService.GetAllPics();
            return Ok(picture);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Picture>> CreatePicture([FromBody] Picture pictureData)

    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            pictureData.CreatorId = userInfo.Id;
            Picture picture = _picturesService.CreatePicture(pictureData);
            return Ok(picture);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

}
