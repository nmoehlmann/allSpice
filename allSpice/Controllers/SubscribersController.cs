namespace allSpice.Controllers
{
  [ApiController]
  [Route("api/favorites")]
  public class SubscribersController : ControllerBase
  {
    private readonly SubscribersService _subscribersService;
    private readonly Auth0Provider _auth;

    public SubscribersController(SubscribersService subscribersService, Auth0Provider auth)
    {
      _subscribersService = subscribersService;
      _auth = auth;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Subscriber>> CreateSubscription([FromBody] Subscriber subData)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        subData.accountId = userInfo.Id;

        Subscriber newSubscription = _subscribersService.CreateSubscription(subData);
        return new ActionResult<Subscriber>(Ok(newSubscription));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{subId}")]
    public async Task<ActionResult<Subscriber>> DeleteSubscriber(int subId)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        _subscribersService.DeleteSubscriber(subId, userInfo.Id);
        return Ok("Subscription Removed");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}