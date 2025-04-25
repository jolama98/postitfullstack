namespace postitfullstack.Controllers;
[ApiController]
[Authorize]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  private readonly WatchersService _watchersService;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider, WatchersService watchersService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _watchersService = watchersService;
  }

  [HttpGet]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateAccount(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet("watchers")]
  public async Task<ActionResult<List<WatcherAlbum>>> GetMyWatcherAlbums()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<WatcherAlbum> watcherAlbums = _watchersService.GetMyWatcherAlbum(userInfo.Id);
      return Ok(watcherAlbums);
    }


    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}
