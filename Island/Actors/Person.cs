using System;
using System.Drawing;
using Island.Behaviours;
using Island.Models;

namespace Island.Actors
{
  public class Person : Mover
  {
    public Person(Location initialLocation) : base(initialLocation)
    {
    }

    public override void Draw(Graphics graphics, float x, float y, float width, float height)
    {
      graphics.FillEllipse(new SolidBrush(Color.Black), x + width/4, y + height/4, width/2, height/2);
    }

    public override Behaviour GetInitialBehaviour()
    {
      var movement = new Activity(state => Move(new Location(Location.X + Random.Next(-1, 2), Location.Y + Random.Next(-1, 2))));

      return Do.Activity(movement, GetInitialBehaviour);
    }
  }
}