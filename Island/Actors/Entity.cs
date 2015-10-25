using System.Drawing;
using Island.Models;

namespace Island.Actors
{
  public abstract class Entity
  {
    protected Entity(Location initialLocation)
    {
      Location = initialLocation;
    }

    public Location Location { get; protected set; }

    public abstract void Draw(Graphics graphics, float x, float y, float width, float height);
  }
}