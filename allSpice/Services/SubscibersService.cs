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

    internal Subscriber GetById(int subId)
    {
      Subscriber sub = _repo.GetById(subId);
      if (sub == null) new Exception("Subscriber was not found");
      return sub;
    }

        internal void DeleteSubscriber(int subId, string userId)
        {
            Subscriber sub = GetById(subId);
            if (sub.accountId != userId) new Exception("Unauthorized!");
            int rows = _repo.DeleteSubscriber(subId);
        }

        internal List<SubscriberRecipe> GetMySubscribedRecipes(string accountId)
    {
      List<SubscriberRecipe> subRecipes = _repo.GetMySubscribedRecipes(accountId);
      return subRecipes;
    }
  }
}