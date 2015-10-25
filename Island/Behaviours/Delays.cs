using System;

namespace Island.Behaviours
{
  public static class Delays
  {
    public static Behaviour DelayFor(int years, Behaviour thenDoThis)
    {
      if (years <= 0)
      {
        return thenDoThis;
      }

      return new Behaviour(state => Tuple.Create(Activity.None, DelayFor(years - 1, thenDoThis)));
    }
  }
}