namespace allSpice.Repositories
{
  public class SubscribersRepository
  {
    private readonly IDbConnection _db;

    public SubscribersRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Subscriber CreateSubscription(Subscriber subData)
    {
      string sql = @"
      INSERT INTO subscribers
      (accountId, recipeId)
      VALUES
      (@accountId, @recipeId);
      SELECT LAST_INSERT_ID()
      ;";

      int lastInsertId = _db.ExecuteScalar<int>(sql, subData);
      subData.Id = lastInsertId;
      return subData;
    }

    internal List<SubscriberRecipe> GetMySubscribedRecipes(string accountId)
    {
      string sql = @"
      SELECT
      sub.*,
      rec.*,
      act.*
      FROM subscribers sub
      JOIN recipes rec ON rec.id = sub.recipeId
      JOIN accounts act ON act.id = sub.accountId
      WHERE sub.accountId = @accountId
      ;";

      List<SubscriberRecipe> subRecipes = _db.Query<Subscriber, SubscriberRecipe, Account, SubscriberRecipe>(sql, (sub, recipe, account) =>
      {
        recipe.SubscriptionId = sub.Id;
        recipe.creator = account;
        return recipe;
      }, new { accountId }).ToList();
      return subRecipes;
    }
  }
}