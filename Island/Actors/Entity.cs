using Island.Models;

namespace Island.Actors
{
  public class Entity
  {
    public Entity(Location initialLocation)
    {
      Location = initialLocation;
    }

    public Location Location { get; protected set; }
  }
}