using System;

namespace Island.Behaviours
{
  public static class Do
  {
    public static Behaviour Activity(Activity activity, Func<Behaviour> then)
    {
      return new Behaviour(state => Tuple.Create(activity, then()));
    }
  }
}