using Island.Actors;

namespace Island.Models
{
  public interface IWorld
  {
    bool IsAccessibleTo(Location location, Actor actor);
  }
}