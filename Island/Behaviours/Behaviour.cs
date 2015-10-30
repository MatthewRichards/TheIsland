using System;
using Island.Activities;
using Island.Actors;
using Island.Models;

namespace Island.Behaviours
{
  public class Behaviour
  {
    private readonly Func<WorldView, Tuple<Activity, Behaviour>> behaviour;

    public Behaviour(Func<WorldView, Tuple<Activity, Behaviour>> behaviour)
    {
      this.behaviour = behaviour;
    }

    public Behaviour Invoke(Actor actor, WorldView state)
    {
      var result = behaviour(state);
      result.Item1.Act(actor, state);
      return result.Item2;
    }
  }
}