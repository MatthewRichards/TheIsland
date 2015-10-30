using System;
using System.Collections.Generic;
using System.Drawing;

namespace Island.Drawing
{
  public static class SemiTransparentBrushes
  {
    private static readonly Dictionary<Color, Dictionary<int, Brush>> Cache = new Dictionary<Color, Dictionary<int, Brush>>();

    public static Brush GetBrush(Color colour, float opacity)
    {
      int index = (int)Math.Ceiling(opacity*10);

      Dictionary<int, Brush> brushCache;
      if (!Cache.TryGetValue(colour, out brushCache))
      {
        brushCache = new Dictionary<int, Brush>();
        Cache[colour] = brushCache;
      }

      Brush brush;
      if (!brushCache.TryGetValue(index, out brush))
      {
        brush = new SolidBrush(Color.FromArgb((int)(255*opacity), colour));
        brushCache[index] = brush;
      }

      return brush;
    }
  }
}