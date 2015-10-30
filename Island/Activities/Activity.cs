using System;
using Island.Actors;
using Island.Behaviours;
using Island.Models;

namespace Island.Activities
{
  public abstract class Activity
  {
    public abstract void Act(Actor actor, WorldView state);

    public Tuple<Activity, Behaviour> Then(Behaviour next)
    {
      return Tuple.Create(this, next);
    }

    public Tuple<Activity, Behaviour> Then(Func<WorldView, Tuple<Activity, Behaviour>> next)
    {
      return Then(new Behaviour(next));
    }
  }
}