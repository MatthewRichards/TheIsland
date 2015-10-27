namespace Island.Models
{
  public class Location
  {
    public Location(int x, int y)
    {
      X = x;
      Y = y;
    }

    public int X { get; }

    public int Y { get; }

    public Location Offset(int dx, int dy)
    {
      return new Location(X + dx, Y + dy);
    }
  }
}