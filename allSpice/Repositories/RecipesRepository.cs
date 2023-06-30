namespace allSpice.Repositories
{
  public class RecipesRepository
  {
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
      string sql = @"
      INSERT INTO recipes
      (title, instructions, category, img, creatorId)
      VALUES
      (@title, @instructions, @category, @img, @creatorId);

      SELECT
        rec.*,
        creator.*
      FROM recipes rec
      JOIN accounts creator ON rec.creatorId = creator.id
      WHERE rec.Id = LAST_INSERT_ID();
      ";

      Recipe newRecipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) =>
      {
        recipe.creator = creator;
        return recipe;
      }, recipeData).FirstOrDefault();
      return newRecipe;
    }

    internal int DeleteRecipe(int recipeId)
    {
      string sql = @"DELETE FROM recipes WHERE id = @recipeId LIMIT 1;";
      int rows = _db.Execute(sql, new { recipeId });
      return rows;
    }

    internal List<Recipe> GetAllRecipes()
    {
      string sql = @"
      SELECT
      rec.*,
      creator.*
      FROM recipes rec
      JOIN accounts creator ON rec.creatorId = creator.id;
      ";
      List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) =>
      {
        recipe.creator = creator;
        return recipe;
      }).ToList();
      return recipes;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
      string sql = @"
      SELECT
      rec.*,
      creator.*
      FROM recipes rec
      JOIN accounts creator ON rec.creatorId = creator.id
      WHERE rec.Id = @recipeId;
      ";
      Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) =>
      {
        recipe.creator = creator;
        return recipe;
      }, new { recipeId }).FirstOrDefault();
      return recipe;
    }

    internal void updateRecipe(Recipe updateData)
    {
      string sql = @"
      UPDATE recipes SET
      title = @title,
      instructions = @instructions,
      category = @category,
      img = @img;";
      _db.Execute(sql, updateData);
    }
  }

}