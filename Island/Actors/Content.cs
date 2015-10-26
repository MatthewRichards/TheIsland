using Island.Models;

namespace Island.Actors
{
  public abstract class Content : Actor
  {
    protected Content(Location initialLocation) : base(initialLocation)
    {
    }
  }
}