using System;
using System.Drawing;
using Island.Activities;
using Island.Behaviours;
using Island.Models;

namespace Island.Actors
{
  public class Plain : Landscape
  {
    private int trees;

    public Plain(Location location) : base(location, Color.Bisque)
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

    public int Deplete(int amount)
    {
      var availableAmount = Math.Min(amount, trees);
      trees -= availableAmount;
      return trees;
    }

    public override bool IsAccessibleTo(Actor actor)
    {
      return true;
    }
  }
}