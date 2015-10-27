using System.Drawing;
using Island.Models;

namespace Island.Actors
{
  public class Water : Landscape
  {
    public Water(Location location) : base(location, Color.Aqua)
    {
    }

    public override bool IsAccessibleTo(Actor actor)
    {
      return false;
    }
  }
}