using System;
using Island.Actors;
using Island.Models;

namespace Island.Behaviours
{
  public class Behaviour
  {
    private readonly Func<WorldView, Action> behaviour;

    public Behaviour(Func<WorldView, Action> behaviour)
    {
      this.behaviour = behaviour;
    }

    public Behaviour Invoke(Actor actor, WorldView state)
    {
      var result = behaviour(state);
      return result.Act(actor, state);
    }
  }
}