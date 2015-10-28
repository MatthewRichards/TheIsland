using System;
using System.Drawing;
using Island.Activities;
using Island.Behaviours;
using Island.Models;

namespace Island.Actors
{
  public class Person : Mover
  {
    private int wood;

    public override void Draw(Graphics graphics, float x, float y, float width, float height)
    {
      graphics.FillEllipse(new SolidBrush(Color.FromArgb(255 * (Math.Min(wood, 80) + 20) / 100, Color.Black)), x + width/4, y + height/4, width/2, height/2);
    }

    public override Behaviour GetInitialBehaviour()
    {
      return Move.By(Random.Next(-1, 2), Random.Next(-1, 2)).Then(() => 
        new Harvest().Then(GetInitialBehaviour));
    }

    public void AddWood(int amount)
    {
      wood += amount;
    }
  }
}