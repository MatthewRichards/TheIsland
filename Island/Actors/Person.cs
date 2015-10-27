using System.Drawing;
using Island.Activities;
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
      return Move.By(Random.Next(-1, 2), Random.Next(-1, 2)).Then(GetInitialBehaviour);
    }
  }
}