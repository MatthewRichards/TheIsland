using System.Drawing;
using Island.Models;

namespace Island.Actors
{
  public class Mountain : Landscape
  {
    public Mountain(Location location) : base(location, Color.Chocolate)
    {
    }

    public override void ReplenishResources()
    {
    }

    public override bool IsAccessibleTo(Actor actor)
    {
      return true;
    }
  }
}