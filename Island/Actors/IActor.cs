using System.Drawing;
using Island.Behaviours;
using Island.Models;

namespace Island.Actors
{
  public interface IActor
  {
    Location Location { get; }
    void Draw(Graphics graphics, float x, float y, float width, float height);
  }
}