namespace allSpice.Controllers;

[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  private readonly SubscribersService _subscribersService;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider, SubscribersService subscribersService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _subscribersService = subscribersService;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("favorites")]
  [Authorize]
  public async Task<ActionResult<List<SubscriberRecipe>>> GetMySubscribedRecipes()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<SubscriberRecipe> subRecipes = _subscribersService.GetMySubscribedRecipes(userInfo.Id);
      return Ok(subRecipes);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
