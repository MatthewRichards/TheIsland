using System;
using System.Drawing;
using Island.Behaviours;
using Island.Models;

namespace Island.Actors
{
  public abstract class Actor : IActor
  {
    protected static readonly Random Random = new Random();

    protected Actor(Location initialLocation)
    {
      Location = initialLocation;
    }

    public Location Location { get; protected set; }

    public abstract void Draw(Graphics graphics, float x, float y, float width, float height);

    public abstract Behaviour GetInitialBehaviour();
  }
}