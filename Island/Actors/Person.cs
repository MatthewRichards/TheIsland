using System;
using System.Drawing;
using Island.Activities;
using Island.Behaviours;
using Island.Models;
using Island.Resources;

namespace Island.Actors
{
  public class Person : Mover
  {
    private readonly ResourceStore resources = new ResourceStore(100);

    public override void Draw(Graphics graphics, float x, float y, float width, float height)
    {
      graphics.FillEllipse(new SolidBrush(Color.FromArgb(255 * (Math.Min(resources.Get<Wood>(), 80) + 20) / 100, Color.Black)), x + width/4, y + height/4, width/2, height/2);
    }
    
    public int Add<TResource>(int amount) where TResource : Resource
    {
      return resources.Add<TResource>(amount);
    }

    public int CanCarry<TResource>() where TResource : Resource
    {
      return resources.SpareCapacity<TResource>();
    }

    public int Carrying<TResource>() where TResource : Resource
    {
      return resources.Get<TResource>();
    }
  }
}