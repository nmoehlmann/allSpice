namespace allSpice.Controllers
{
  [ApiController]
  [Route("api/recipes")]
  public class RecipesController : ControllerBase
  {
    private readonly RecipesService _recipesService;
    private readonly Auth0Provider _auth;

    public RecipesController(RecipesService recipesService, Auth0Provider auth)
    {
      _recipesService = recipesService;
      _auth = auth;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        recipeData.creatorId = userInfo.Id;

        Recipe newRecipe = _recipesService.CreateRecipe(recipeData);
        return new ActionResult<Recipe>(Ok(newRecipe));
      }
      catch (Exception e)
      {
        return new ActionResult<Recipe>(BadRequest(e.Message));
      }
    }

    [HttpGet]
    public ActionResult<List<Recipe>> GetAllRecipes()
    {
      try
      {
        List<Recipe> recipes = _recipesService.GetAllRecipes();
        return Ok(recipes);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{recipeId}")]
    public ActionResult<Recipe> GetByRecipeId(int recipeId)
    {
      try
      {
        Recipe recipe = _recipesService.GetRecipeById(recipeId);
        return Ok(recipe);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{recipeId}")]
    [Authorize]
    public ActionResult<Recipe> updateRecipe(int recipeId, [FromBody] Recipe updateData)
    {
      try
      {
        updateData.Id = recipeId;
        Recipe updatedRecipe = _recipesService.updateRecipe(updateData);
        return Ok(updatedRecipe);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{recipeId}")]
    [Authorize]
    public async Task<ActionResult<Recipe>> DeleteRecipe(int recipeId)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        Recipe deletedRecipe = _recipesService.DeleteRecipe(recipeId, userInfo.Id);
        return Ok(deletedRecipe);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}