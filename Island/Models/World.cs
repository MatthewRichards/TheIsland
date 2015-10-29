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
      // ReSharper disable PossibleLossOfFraction
      float cellWidth = imageSize.Width/landscape.GetLength(0);
      float cellHeight = imageSize.Height/landscape.GetLength(1);
      // ReSharper enable PossibleLossOfFraction

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

    public int Collect<TResource>(Location location, int collectAmount) where TResource : Resource
    {
      return landscape[location.X, location.Y].Collect<TResource>(collectAmount);
    }
  }
}
