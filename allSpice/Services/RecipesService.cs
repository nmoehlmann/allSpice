namespace allSpice.Services
{
  public class RecipesService
  {
    private readonly RecipesRepository _repo;

    public RecipesService(RecipesRepository repo)
    {
      _repo = repo;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
      Recipe recipe = _repo.CreateRecipe(recipeData);
      return recipe;
    }

    internal Recipe DeleteRecipe(int recipeId, string userId)
    {
      Recipe recipe = GetRecipeById(recipeId);
      if (recipe.creatorId != userId) throw new Exception("STOP RIGHT THERE SCUM!");

      int rows = _repo.DeleteRecipe(recipeId);
      return recipe;
    }

    internal List<Recipe> GetAllRecipes()
    {
      List<Recipe> recipes = _repo.GetAllRecipes();
      return recipes;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
      Recipe recipe = _repo.GetRecipeById(recipeId);
      if (recipe == null) throw new Exception($"recipe at id: {recipeId} doesn't exist");
      return recipe;
    }

    internal Recipe updateRecipe(Recipe updateData)
    {
      Recipe original = GetRecipeById(updateData.Id);

      original.title = updateData.title != null ? updateData.title : original.title;

      original.instructions = updateData.instructions != null ? updateData.instructions : original.instructions;

      original.category = updateData.category != null ? updateData.category : original.category;

      original.img = updateData.img != null ? updateData.img : original.img;

      _repo.updateRecipe(original);
      return original;
    }
  }
}