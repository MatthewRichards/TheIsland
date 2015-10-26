using System;
using Island.Models;

namespace Island.Behaviours
{
  public class Behaviour
  {
    private Func<IWorld, Tuple<Activity, Behaviour>> behaviour;

    public Behaviour(Func<IWorld, Tuple<Activity, Behaviour>> behaviour)
    {
      this.behaviour = behaviour;
    }

    public Tuple<Activity, Behaviour> Invoke(IWorld state)
    {
      return behaviour(state);
    }

    public static implicit operator Behaviour(Func<IWorld, Tuple<Activity, Behaviour>> behaviour)
    {
      return new Behaviour(behaviour);
    }
  }
}