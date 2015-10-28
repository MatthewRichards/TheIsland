using Island.Actors;
using Island.Models;
using Island.Resources;

namespace Island.Activities
{
  public class Harvest<TResource> : Activity where TResource : Resource
  {
    public override void Act(Actor actor, WorldView state)
    {
      int wood = state.Harvest<TResource>();
      ((Person) actor).AddWood(wood);
    }
  }
}