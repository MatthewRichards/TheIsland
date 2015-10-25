using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Island.Models;

namespace Island.Actors
{
  public class Forest : Content
  {
    private int trees;
    private static readonly Random Random = new Random();

    public Forest(Location location) : base(location)
    {
      trees = Random.Next(0, 100);
    }

    public override void Draw(Graphics graphics, float x, float y, float width, float height)
    {
      graphics.FillRectangle(new SolidBrush(Color.FromArgb(255 * Math.Min(trees, 100) / 100, Color.Green)), x, y, width, height);
    }
  }
}