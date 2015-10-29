using Island.Actors;
using Island.Models;
using Island.Resources;

namespace Island.Activities
{
  public class Harvest<TResource> : Activity where TResource : Resource
  {
    public override void Act(Actor actor, WorldView state)
    {
      state.Harvest<TResource>();
      int capacity = ((Person)actor).CanCarry<TResource>();
      int amountCollected = state.Collect<TResource>(capacity);
      ((Person) actor).Add<TResource>(amountCollected);
    }
  }
}