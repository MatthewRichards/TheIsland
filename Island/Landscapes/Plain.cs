using System;
using System.Drawing;
using Island.Actors;
using Island.Models;
using Island.Resources;

namespace Island.Landscapes
{
  public class Plain : Landscape
  {
    protected int trees
    {
      get { return resources[typeof (Wood)]; }
      set { resources[typeof (Wood)] = value; }
    }

    public Plain() : base(Color.Bisque)
    {
      trees = Random.Next(0, 100);
    }

    public override void ReplenishResources()
    {
      trees++;
    }

    public override void Draw(Graphics graphics, float x, float y, float width, float height)
    {
      graphics.FillRectangle(new SolidBrush(Color.FromArgb(255 * Math.Min(trees, 100) / 100, Color.Green)), x, y, width, height);
    }

    public override bool IsAccessibleTo(Actor actor)
    {
      return true;
    }
  }
}