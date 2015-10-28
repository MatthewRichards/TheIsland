using System;
using System.Collections.Generic;

namespace Island.Resources
{
  public class ResourceStore
  {
    private readonly Dictionary<Type, int> resources = new Dictionary<Type, int>();

    public int Get<TResource>() where TResource : Resource
    {
      int amount;
      return resources.TryGetValue(typeof (TResource), out amount) ? amount : 0;
    }

    public void Set<TResource>(int amount) where TResource : Resource
    {
      resources[typeof (TResource)] = amount;
    }

    public void Add<TResource>(int amount) where TResource : Resource
    {
      resources[typeof (TResource)] = Get<TResource>() + amount;
    }

    public int Subtract<TResource>(int requestedAmount) where TResource : Resource
    {
      var currentAmount = Get<TResource>();
      var amountToSubtract = Math.Min(requestedAmount, currentAmount);
      Set<TResource>(currentAmount - amountToSubtract);
      return amountToSubtract;
    }
  }
}