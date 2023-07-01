namespace allSpice.Controllers
{
  [ApiController]
  [Route("api/ingredients")]
  public class IngredientsController : ControllerBase
  {
    private readonly IngredientsService _ingredientsService;
    private readonly Auth0Provider _auth;

    public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth)
    {
      _ingredientsService = ingredientsService;
      _auth = auth;
    }

    [HttpPost]
    public ActionResult<Ingredient> CreateIngredient([FromBody] Ingredient ingredientData)
    {
      try
      {
        Ingredient newIngredient = _ingredientsService.CreateIngredient(ingredientData);
        return Ok(newIngredient);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{ingredientId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteIngredient(int ingredientId)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        _ingredientsService.DeleteIngredient(ingredientId, userInfo.Id);
        return Ok($"ingredient at id: {ingredientId} has been deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}