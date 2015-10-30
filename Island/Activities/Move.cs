using System;
using Island.Actors;
using Island.Models;

namespace Island.Activities
{
  public class Move : Activity
  {
    private int dx;
    private int dy;
    private readonly Location destination;

    public Move(int dx, int dy)
    {
      this.dx = dx;
      this.dy = dy;
    }

    public Move(Location destination)
    {
      this.destination = destination;
    }

    public static Move By(int x, int y)
    {
      return new Move(x, y);
    }

    public static Move Towards(Location destination)
    {
      return new Move(destination);
    }

    public override void Act(Actor actor, WorldView world)
    {
      Mover mover = actor as Mover;

      if (mover == null)
      {
        throw new Exception("Cannot move a " + actor.GetType());
      }

      if (destination != null)
      {
        dx = world.Location.X < destination.X ? 1 : world.Location.X > destination.X ? -1 : 0;
        dy = world.Location.Y < destination.Y ? 1 : world.Location.Y > destination.Y ? -1 : 0;
      }

      Location newLocation = world.Location.Offset(dx, dy);

      if (world.IsAccessibleTo(newLocation, actor))
      {
        world.MoveTo(newLocation);
      }
    }
  }
}