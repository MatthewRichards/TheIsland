using System.Drawing;
using Island.Actors;
using Island.Models;

namespace Island.Landscapes
{
  public class Water : Landscape
  {
    public Water() : base(Brushes.Aqua)
    {
    }

    public override void ReplenishResources()
    {
    }

    public override bool IsAccessibleTo(Actor actor)
    {
      return false;
    }
  }
}