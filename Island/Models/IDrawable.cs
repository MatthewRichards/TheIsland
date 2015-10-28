using System.Drawing;

namespace Island.Models
{
  public interface IDrawable
  {
    void Draw(Graphics graphics, float x, float y, float width, float height);
  }
}