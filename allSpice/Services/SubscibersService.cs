namespace allSpice.Services
{
  public class SubscribersService
  {
    private readonly SubscribersRepository _repo;

    public SubscribersService(SubscribersRepository repo)
    {
      _repo = repo;
    }

    internal Subscriber CreateSubscription(Subscriber subData)
    {
      Subscriber newSubscription = _repo.CreateSubscription(subData);
      return newSubscription;
    }

    internal List<SubscriberRecipe> GetMySubscribedRecipes(string accountId)
    {
      List<SubscriberRecipe> subRecipes = _repo.GetMySubscribedRecipes(accountId);
      return subRecipes;
    }
  }
}