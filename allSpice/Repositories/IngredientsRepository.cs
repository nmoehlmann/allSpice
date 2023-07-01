namespace allSpice.Repositories
{
  public class IngredientsRepository
  {
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
      string sql = @"
      INSERT INTO ingredients
      (name, quantity, recipeId)
      VALUES
      (@name, @quantity, @recipeId);

      SELECT
      ing.*,
      rec.*
      FROM ingredients ing
      JOIN recipes rec ON ing.recipeId = rec.Id 
      WHERE ing.Id = LAST_INSERT_ID();
      ;";

      Ingredient newIngredient = _db.Query<Ingredient, Recipe, Ingredient>(sql, (ingredient, recipe) =>
      {
        ingredient.recipeId = recipe.Id;
        return ingredient;
      }, ingredientData).FirstOrDefault();
      return newIngredient;
    }

    internal int DeleteIngredient(int ingredientId)
    {
      string sql = @"DELETE FROM ingredients WHERE id = @ingredientId LIMIT 1 ;";
      int rowsAffected = _db.Execute(sql, new { ingredientId });
      return rowsAffected;
    }

    internal Ingredient GetIngredientById(int ingredientId)
    {
      string sql = @"
      SELECT
      ing.*,
      rec.*
      FROM ingredients ing
      JOIN recipes rec ON ing.recipeId = rec.Id
      WHERE ing.Id = @ingredientId;
      ";
      Ingredient ingredient = _db.Query<Ingredient, Recipe, Ingredient>(sql, (ingredient, recipe) =>
      {
        ingredient.recipeId = recipe.Id;
        return ingredient;
      }, new { ingredientId }).FirstOrDefault();
      return ingredient;
    }

    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
      string sql = @"
      SELECT
      ing.*,
      rec.*
      FROM ingredients ing
      JOIN recipes rec ON rec.Id = ing.recipeId
      WHERE rec.Id = @recipeId
      ;";
      List<Ingredient> recipeIngredients = _db.Query<Ingredient, Recipe, Ingredient>(sql, (ingredient, recipe) =>
      {
        ingredient.recipeId = recipe.Id;
        return ingredient;
      }, new { recipeId }).ToList();
      return recipeIngredients;
    }
  }
}