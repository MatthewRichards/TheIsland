using System.Drawing;
using Island.Models;

namespace Island.Actors
{
  public class Landscape : Entity
  {
    private readonly Color colour;

    public Landscape(Location location, Color colour) : base(location)
    {
      this.colour = colour;
    }


    public void Draw(Graphics graphics, float x, float y, float width, float height)
    {
      graphics.FillRectangle(new SolidBrush(colour), x, y, width, height);
    }
  }
}