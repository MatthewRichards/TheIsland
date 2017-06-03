using System;
using Island.Actors;
using Island.Behaviours;
using Island.Models;
using Action = Island.Behaviours.Action;

namespace Island.Activities
{
  public abstract class Activity
  {
    public abstract void Act(Actor actor, WorldView state);

    public Action Then(Behaviour next)
    {
      return new Action(this, next);
    }

    public Action Then(Func<WorldView, Action> next)
    {
      return Then(new Behaviour(next));
    }
  }
}