using System;
using Island.Activities;

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

      return Activity.None.Then(() => For(years - 1, thenDoThis));
    }
  }
}