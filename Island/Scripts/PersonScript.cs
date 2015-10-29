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

    private static readonly Random Random = new Random();

    public PersonScript(Person me, Location home)
    {
      this.me = me;
      this.home = home;
    }

    public Behaviour CollectWood()
    {
      return new Behaviour(state =>
      {
        Move.By(Random.Next(-1, 2), Random.Next(-1, 2)).Act(me, state);
        return new Behaviour(FindWood);
      });
    }

    private Behaviour FindWood(WorldView state)
    {
      if (state.CanCollect<Wood>() > 0)
      {
        new Collect<Wood>().Act(me, state);
        return new Behaviour(ReturnHome);
      }

      if (state.CanHarvest<Wood>() > 0)
      {
        new Harvest<Wood>().Act(me, state);
        return new Behaviour(FindWood);
      }

      return CollectWood();
    }

    private Behaviour ReturnHome(WorldView state)
    {
      int dx = state.Location.X < home.X ? 1 : (state.Location.X > home.X ? -1 : 0);
      int dy = state.Location.Y < home.Y ? 1 : (state.Location.Y > home.Y ? -1 : 0);

      if (dx == 0 && dy == 0)
      {
        state.DropOff<Wood>(me.Carrying<Wood>());
        return new Behaviour(_ => CollectWood());
      }

      Move.By(dx, dy).Act(me, state);
      return new Behaviour(ReturnHome);
    }
  }
}