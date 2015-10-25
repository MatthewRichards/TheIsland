using Island.Models;

namespace Island.Actors
{
  public abstract class Mover : Content
  {
    protected Mover(Location initialLocation) : base(initialLocation)
    {
    }

    public void Move(Location newLocation)
    {
      Location = newLocation;
    }
  }
}