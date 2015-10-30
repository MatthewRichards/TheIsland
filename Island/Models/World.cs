using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Island.Actors;
using Island.Behaviours;
using Island.Landscapes;
using Island.Resources;

namespace Island.Models
{
  public class World
  {
    private readonly Landscape[,] landscape;
    private readonly List<ActorWithLocationAndBehaviour> content;

    public World(Landscape[,] landscape, List<ActorWithLocationAndBehaviour> content)
    {
      this.landscape = landscape;
      this.content = content;
    }

    internal void Draw(Graphics graphics, Size imageSize)
    {
      float cellWidth = (float)imageSize.Width/landscape.GetLength(0);
      float cellHeight = (float)imageSize.Height/landscape.GetLength(1);

      for (int i = 0; i < landscape.GetLength(0); i++)
      {
        for (int j = 0; j < landscape.GetLength(1); j++)
        {
          landscape[i, j].Draw(graphics, i*cellWidth, j*cellHeight, cellWidth, cellHeight);
        }
      }

      content.ForEach(c => c.Draw(graphics, c.Location.X*cellWidth, c.Location.Y*cellHeight, cellWidth, cellHeight));
    }

    internal void ClockTick()
    {
      foreach (var item in content)
      {
        item.Behave(this);
      }

      foreach (var item in landscape)
      {
        item.ReplenishResources();
      }
    }

    public bool IsAccessibleTo(Location location, Actor actor)
    {
      return landscape[location.X, location.Y].IsAccessibleTo(actor);
    }

    public int Harvest<TResource>(Location location) where TResource : Resource
    {
      var harvestAmount = 20;
      return landscape[location.X, location.Y].Harvest<TResource>(harvestAmount);
    }

    public int CanHarvest<TResource>(Location location) where TResource : Resource
    {
      return landscape[location.X, location.Y].CanHarvest<TResource>();
    }

    public int Collect<TResource>(Location location, int collectAmount) where TResource : Resource
    {
      return landscape[location.X, location.Y].Collect<TResource>(collectAmount);
    }

    public int CanCollect<TResource>(Location location) where TResource : Resource
    {
      return landscape[location.X, location.Y].CanCollect<TResource>();
    }

    public void DropOff<TResource>(Location location, int amount) where TResource : Resource
    {
      landscape[location.X, location.Y].DropOff<TResource>(amount);
    }
  }
}
