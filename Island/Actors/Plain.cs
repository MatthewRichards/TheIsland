using System.Drawing;
using Island.Models;

namespace Island.Actors
{
  public class Plain : Landscape
  {
    public Plain(Location location) : base(location, Color.Bisque)
    {
    }
  }
}