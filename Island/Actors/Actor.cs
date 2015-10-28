using System;
using System.Drawing;
using Island.Behaviours;
using Island.Models;

namespace Island.Actors
{
  public abstract class Actor : IDrawable
  {
    protected static readonly Random Random = new Random();

    public abstract Behaviour GetInitialBehaviour();

    public abstract void Draw(Graphics graphics, float x, float y, float width, float height);
  }
}