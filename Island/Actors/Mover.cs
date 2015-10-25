using Island.Models;

namespace Island.Actors
{
  public class Mover : Content
  {
    public Mover(Location initialLocation) : base(initialLocation)
    {
    }

    public void Move(Location newLocation)
    {
      Location = newLocation;
    }
  }
}