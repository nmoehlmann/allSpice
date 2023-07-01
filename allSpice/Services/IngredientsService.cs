namespace allSpice.Services
{

  public class IngredientsService
  {
    private readonly IngredientsRepository _repo;

    public IngredientsService(IngredientsRepository repo)
    {
      _repo = repo;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
      Ingredient newIngredient = _repo.CreateIngredient(ingredientData);
      return newIngredient;
    }

    internal Ingredient GetIngredientById(int ingredientId)
    {
      Ingredient ingredient = _repo.GetIngredientById(ingredientId);
      if (ingredient == null) throw new Exception($"ingredient at id: {ingredientId} doesn't exist");
      return ingredient;
    }

    internal void DeleteIngredient(int ingredientId, string userId)
    {
      Ingredient ingredient = GetIngredientById(ingredientId);
      int rowsAffected = _repo.DeleteIngredient(ingredientId);
    }

    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
      List<Ingredient> ingredients = _repo.GetIngredientsByRecipeId(recipeId);
      return ingredients;
    }
  }
}
