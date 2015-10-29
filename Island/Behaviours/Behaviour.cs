using System;
using Island.Actors;
using Island.Models;

namespace Island.Behaviours
{
  public class Behaviour
  {
    private readonly Func<WorldView, Behaviour> behaviour;

    public Behaviour(Func<WorldView, Behaviour> behaviour)
    {
      this.behaviour = behaviour;
    }

    public Behaviour Invoke(Actor actor, WorldView state)
    {
      return behaviour(state);
    }
  }
}