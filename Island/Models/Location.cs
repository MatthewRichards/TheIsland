﻿namespace Island.Models
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

    protected bool Equals(Location other)
    {
      return X == other.X && Y == other.Y;
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((Location) obj);
    }

    public static bool operator ==(Location left, Location right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(Location left, Location right)
    {
      return !Equals(left, right);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return (X*397) ^ Y;
      }
    }

    public Location Offset(int dx, int dy)
    {
      return new Location(X + dx, Y + dy);
    }
  }
}