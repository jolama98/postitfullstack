using Microsoft.AspNetCore.Http.HttpResults;

namespace postitfullstack.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class PictureController : ControllerBase
{
    private readonly PictureService _pictureService;
    private readonly Auth0Provider _auth0Provider;

    public PictureController(PictureService pictureService, Auth0Provider auth0Provider)
    {
        _pictureService = pictureService;
        _auth0Provider = auth0Provider;
    }

    [HttpGet]
    public ActionResult<List<Picture>> GetAllPics()

    {
        try
        {
            List<Picture> picture = _pictureService.GetAllPics();
            return Ok(picture);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Picture>> CreatePicture([FromBody] Picture pictureData)

    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            pictureData.CreatorId = userInfo.Id;
            Picture picture = _pictureService.CreatePicture(pictureData);
            return Ok(picture);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

}
