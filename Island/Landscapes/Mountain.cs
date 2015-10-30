using System.Drawing;
using Island.Actors;
using Island.Models;

namespace Island.Landscapes
{
  public class Mountain : Landscape
  {
    public Mountain() : base(Brushes.Chocolate)
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