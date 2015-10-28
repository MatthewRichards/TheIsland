using System;
using System.Collections.Generic;

namespace Island.Resources
{
  public class ResourceStore
  {
    private readonly Dictionary<Type, int> resources = new Dictionary<Type, int>();
    private readonly int limit;

    public ResourceStore(int limit)
    {
      this.limit = limit;
    }

    public ResourceStore() : this(int.MaxValue)
    {
    }

    public int Get<TResource>() where TResource : Resource
    {
      int amount;
      return resources.TryGetValue(typeof (TResource), out amount) ? amount : 0;
    }

    public void Set<TResource>(int amount) where TResource : Resource
    {
      resources[typeof (TResource)] = Math.Min(amount, limit);
    }

    public int Add<TResource>(int requestedAmount) where TResource : Resource
    {
      var currentAmount = Get<TResource>();
      var amountToAdd = Math.Min(requestedAmount, limit - currentAmount);
      resources[typeof (TResource)] = currentAmount + amountToAdd;
      return amountToAdd;
    }

    public int Subtract<TResource>(int requestedAmount) where TResource : Resource
    {
      var currentAmount = Get<TResource>();
      var amountToSubtract = Math.Min(requestedAmount, currentAmount);
      Set<TResource>(currentAmount - amountToSubtract);
      return amountToSubtract;
    }

    public int SpareCapacity<TResource>() where TResource : Resource
    {
      if (limit == int.MaxValue)
      {
        return int.MaxValue;
      }

      return limit - Get<TResource>();
    }
  }
}