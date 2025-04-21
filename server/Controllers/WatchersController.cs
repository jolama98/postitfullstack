namespace postitfullstack.Controllers;

[ApiController]
[Route("api/[controller]")]

public class WatchersController : ControllerBase
{
    private readonly Auth0Provider _auth0Provider;
    private readonly WatchersService _watchersService;

    public WatchersController(Auth0Provider auth0Provider, WatchersService watchersService)
    {
        _auth0Provider = auth0Provider;
        _watchersService = watchersService;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<WatcherProfile>> CreateWatcher([FromBody] Watcher watcherData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            watcherData.AccountId = userInfo.Id;
            WatcherProfile watcherProfile = _watchersService.CreateWatcher(watcherData);
            return Ok(watcherProfile);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}