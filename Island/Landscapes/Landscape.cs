using System;
using System.Collections.Generic;
using System.Drawing;
using Island.Actors;
using Island.Models;
using Island.Resources;

namespace Island.Landscapes
{
  public abstract class Landscape : IDrawable
  {
    protected static readonly Random Random = new Random();

    protected readonly Dictionary<Type, int> resources = new Dictionary<Type, int>(); 
    private readonly Color colour;

    protected Landscape(Color colour)
    {
      this.colour = colour;
    }

    public abstract void ReplenishResources();

    public virtual void Draw(Graphics graphics, float x, float y, float width, float height)
    {
      graphics.FillRectangle(new SolidBrush(colour), x, y, width, height);
    }

    public abstract bool IsAccessibleTo(Actor actor);

    public int Deplete<TResource>(int requestedAmount) where TResource: Resource
    {
      var currentAmount = resources[typeof (TResource)];
      var amountToDeplete = Math.Min(requestedAmount, currentAmount);
      resources[typeof (TResource)] = currentAmount - amountToDeplete;
      return amountToDeplete;
    }
  }
}