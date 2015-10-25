using System.Drawing;
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
      throw new System.NotImplementedException();
    }
  }
}