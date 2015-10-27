using System.Drawing;
using Island.Behaviours;
using Island.Models;

namespace Island.Actors
{
  public abstract class Landscape : Actor
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

    public override Behaviour GetInitialBehaviour()
    {
      throw new System.NotImplementedException("TODO: Not sure whether landscape has behaviour yet. Rejig things a bit if not.");
    }

    public abstract bool IsAccessibleTo(Actor actor);
  }
}