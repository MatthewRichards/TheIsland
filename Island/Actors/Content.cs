using Island.Models;

namespace Island.Actors
{
  public abstract class Content : Entity
  {
    protected Content(Location initialLocation) : base(initialLocation)
    {
    }

    public abstract void Behave(IWorld state);
  }
}