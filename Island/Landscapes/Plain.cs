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
      if (Random.Next(0, 3) == 0)
      {
        NaturalResources.Set<Wood>(Random.Next(0, 100));
      }
    }

    public override void ReplenishResources()
    {
      if (NaturalResources.Get<Wood>() > 0 && Random.Next(0, 100) == 0)
      {
        NaturalResources.Add<Wood>(1);
      }
    }

    public override void Draw(Graphics graphics, float x, float y, float width, float height)
    {
      graphics.FillRectangle(new SolidBrush(Color.FromArgb(255 * Math.Min(HarvestedResources.Get<Wood>(), 1000) / 1000, Color.Brown)), x, y + height/2, width, height/2);
      graphics.FillRectangle(new SolidBrush(Color.FromArgb(255 * Math.Min(NaturalResources.Get<Wood>(), 100) / 100, Color.Green)), x, y, width, height/2);
    }

    public override bool IsAccessibleTo(Actor actor)
    {
      return true;
    }
  }
}