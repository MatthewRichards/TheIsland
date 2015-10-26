using System;
using System.Collections.Generic;
using System.Drawing;
using Island.Actors;

namespace Island.Models
{
  public class World
  {
    private readonly Landscape[,] landscape;
    private readonly List<Content> content;

    public World(Landscape[,] landscape, List<Content> content)
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
        item.Behave(null);
      }
    }
  }
}
