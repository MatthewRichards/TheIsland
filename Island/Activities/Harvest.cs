using Island.Actors;
using Island.Models;

namespace Island.Activities
{
  public class Harvest : Activity
  {
    public override void Act(Actor actor, IWorld state)
    {
      int wood = state.HarvestAt(actor.Location);
      ((Person) actor).AddWood(wood);
    }
  }
}