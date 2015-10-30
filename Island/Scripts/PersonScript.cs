using System;
using Island.Activities;
using Island.Actors;
using Island.Behaviours;
using Island.Models;
using Island.Resources;

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

    public Tuple<Activity, Behaviour> CollectWood(WorldView state)
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

    private Tuple<Activity, Behaviour> FindWood(WorldView state)
    {
      return Tuple.Create((Activity)Move.By(Random.Next(-1, 2), Random.Next(-1, 2)), new Behaviour(CollectWood));
    }

    private Tuple<Activity, Behaviour> ReturnHome(WorldView state)
    {
      int dx = state.Location.X < home.X ? 1 : (state.Location.X > home.X ? -1 : 0);
      int dy = state.Location.Y < home.Y ? 1 : (state.Location.Y > home.Y ? -1 : 0);

      if (dx == 0 && dy == 0)
      {
        return Do.DropOff<Wood>(me.Carrying<Wood>()).Then(CollectWood);
      }

      return Move.By(dx, dy).Then(ReturnHome);
    }
  }
}