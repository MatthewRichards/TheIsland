using System;
using Island.Actors;
using Island.Behaviours;
using Island.Models;

namespace Island.Activities
{
  public abstract class Activity
  {
    public abstract void Act(Actor actor, IWorld state);

    public Behaviour Then(Func<Behaviour> nextBehaviour)
    {
      return Do.Activity(this, nextBehaviour);
    }

    public static Activity None = new DoNothing();

    private class DoNothing : Activity
    {
      public override void Act(Actor actor, IWorld state)
      {
      }
    }
  }
}