namespace allSpice.Models;

public class Account
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public string Picture { get; set; }
}

public class SubscriberAccount : Account
{
  public int SubscriptionId { get; set; }
}
