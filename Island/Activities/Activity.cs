using Island.Actors;
using Island.Models;

namespace Island.Activities
{
  public abstract class Activity
  {
    public abstract void Act(Actor actor, WorldView state);
  }
}