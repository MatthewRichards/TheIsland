using System.Drawing;
using Island.Models;

namespace Island.Actors
{
  public abstract class Landscape : Entity
  {
    private readonly Color colour;

    protected Landscape(Location location, Color colour) : base(location)
    {
      this.colour = colour;
    }

    public override void Draw(Graphics graphics, float x, float y, float width, float height)
    {
      graphics.FillRectangle(new SolidBrush(colour), x, y, width, height);
    }
  }
}