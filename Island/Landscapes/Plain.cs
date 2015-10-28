using System;
using System.Drawing;
using Island.Actors;
using Island.Models;
using Island.Resources;

namespace Island.Landscapes
{
  public class Plain : Landscape
  {
    public Plain() : base(Color.Bisque)
    {
      Resources.Set<Wood>(Random.Next(0, 100));
    }

    public override void ReplenishResources()
    {
      Resources.Add<Wood>(1);
    }

    public override void Draw(Graphics graphics, float x, float y, float width, float height)
    {
      graphics.FillRectangle(new SolidBrush(Color.FromArgb(255 * Math.Min(Resources.Get<Wood>(), 100) / 100, Color.Green)), x, y, width, height);
    }

    public override bool IsAccessibleTo(Actor actor)
    {
      return true;
    }
  }
}