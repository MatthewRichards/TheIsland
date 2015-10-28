using Island.Actors;
using Island.Models;
using Island.Resources;

namespace Island.Activities
{
  public class Harvest<TResource> : Activity where TResource : Resource
  {
    public override void Act(Actor actor, WorldView state)
    {
      if (((Person) actor).CanCarry<TResource>() == 0)
      {
        return;
      }

      int amountHarvested = state.Harvest<TResource>();
      ((Person) actor).Add<TResource>(amountHarvested);
    }
  }
}