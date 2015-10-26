using System;

namespace Island.Behaviours
{
  public static class Delay
  {
    public static Behaviour For(int years, Func<Behaviour> thenDoThis)
    {
      if (years <= 0)
      {
        return thenDoThis();
      }

      return new Behaviour(state => Tuple.Create(Activity.None, For(years - 1, thenDoThis)));
    }
  }
}