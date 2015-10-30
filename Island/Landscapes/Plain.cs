using System;
using System.ComponentModel.Design;
using System.Drawing;
using Island.Actors;
using Island.Drawing;
using Island.Models;
using Island.Resources;

namespace Island.Landscapes
{
  public class Plain : Landscape
  {
    private static readonly Bitmap TreeImage = Properties.Resources.Tree;
    private static readonly Bitmap LogImage = Properties.Resources.Log;

    public Plain() : base(Brushes.Bisque)
    {
      if (Random.Next(0, 3) == 0)
      {
        NaturalResources.Set<Wood>(Random.Next(0, 100));
      }
    }

    public override void ReplenishResources()
    {
      if (NaturalResources.Get<Wood>() > 0 && Random.Next(0, 100) == 0)
      {
        NaturalResources.Add<Wood>(1);
      }
    }

    public override void Draw(Graphics graphics, float x, float y, float width, float height)
    {
      int logs = HarvestedResources.Get<Wood>();

      if (logs > 0)
      {
        graphics.DrawImage(LogImage, x, y + height - LogImage.Height);
        graphics.DrawString($"x{logs}",
          SystemFonts.SmallCaptionFont, Brushes.Brown,
          x + LogImage.Width, y + height - LogImage.Height);
      }

      int trees = (int)Math.Ceiling(5*NaturalResources.Get<Wood>()/100f);

      if (trees >= 1) graphics.DrawImage(TreeImage, x + (width - TreeImage.Width) / 2, y + (height - TreeImage.Height) / 2);
      if (trees >= 2) graphics.DrawImage(TreeImage, x, y);
      if (trees >= 3) graphics.DrawImage(TreeImage, x + width - TreeImage.Width, y + height - TreeImage.Height);
      if (trees >= 4) graphics.DrawImage(TreeImage, x + width - TreeImage.Width, y);
      if (trees >= 5) graphics.DrawImage(TreeImage, x, y + height - TreeImage.Height);
    }

    public override bool IsAccessibleTo(Actor actor)
    {
      return true;
    }
  }
}