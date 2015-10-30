using System;
using System.Drawing;
using Island.Activities;
using Island.Behaviours;
using Island.Drawing;
using Island.Models;
using Island.Resources;

namespace Island.Actors
{
  public class Person : Actor
  {
    private readonly ResourceStore resources = new ResourceStore(100);
    private static readonly Bitmap PersonImage = Properties.Resources.Person;

    public override void Draw(Graphics graphics, float x, float y, float width, float height)
    {
      graphics.DrawImage(PersonImage, x + (width-PersonImage.Width)/2, y + (height-PersonImage.Height)/2);
    }
    
    public int PickUp<TResource>(int amount) where TResource : Resource
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

    public int Drop<TResource>(int amount) where TResource : Resource
    {
      return resources.Subtract<TResource>(amount);
    }
  }
}