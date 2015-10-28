using Island.Actors;
using Island.Models;

namespace Island.Activities
{
  public class Harvest : Activity
  {
    public override void Act(Actor actor, WorldView state)
    {
      int wood = state.HarvestHere();
      ((Person) actor).AddWood(wood);
    }
  }
}