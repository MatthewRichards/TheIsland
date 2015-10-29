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
    protected readonly ResourceStore NaturalResources = new ResourceStore();
    protected readonly ResourceStore HarvestedResources = new ResourceStore();
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

    public int Harvest<TResource>(int requestedAmount) where TResource : Resource
    {
      var harvestedAmount = NaturalResources.Subtract<TResource>(requestedAmount);
      return HarvestedResources.Add<TResource>(harvestedAmount);
    }

    public int Collect<TResource>(int requestedAmount) where TResource : Resource
    {
      return HarvestedResources.Subtract<TResource>(requestedAmount);
    }
  }
}