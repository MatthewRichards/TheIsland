using System;
using Island.Activities;
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

    public Tuple<Activity, Behaviour> Invoke(WorldView state)
    {
      return behaviour(state);
    }

    public static implicit operator Behaviour(Func<WorldView, Tuple<Activity, Behaviour>> behaviour)
    {
      return new Behaviour(behaviour);
    }
  }
}