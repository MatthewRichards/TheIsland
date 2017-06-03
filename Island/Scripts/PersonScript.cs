using System;
using Island.Activities;
using Island.Actors;
using Island.Models;
using Island.Resources;
using Action = Island.Behaviours.Action;

namespace Island.Scripts
{
  public class PersonScript
  {
    private readonly Person me;
    private readonly Location home;
    private Location lastWoodSource;

    private static readonly Random Random = new Random();

    public PersonScript(Person me, Location home)
    {
      this.me = me;
      this.home = home;
    }

    public Action CollectWood(WorldView state)
    {
      if (state.Location != home && state.CanCollect<Wood>() > 0)
      {
        lastWoodSource = state.Location;
        return Do.Collect<Wood>().Then(ReturnHome);
      }

      if (state.CanHarvest<Wood>() > 0)
      {
        return Do.Harvest<Wood>().Then(CollectWood);
      }

      if (lastWoodSource != null && lastWoodSource != state.Location)
      {
        return Move.Towards(lastWoodSource).Then(CollectWood);
      }

      lastWoodSource = null;
      return FindWood(state);
    }

    private Action FindWood(WorldView state)
    {
      return Move
        .By(Random.Next(-1, 2), Random.Next(-1, 2))
        .Then(CollectWood);
    }

    private Action ReturnHome(WorldView state)
    {
      if (state.Location == home)
      {
        return Do.DropOff<Wood>(me.Carrying<Wood>()).Then(CollectWood);
      }

      return Move.Towards(home).Then(ReturnHome);
    }
  }
}