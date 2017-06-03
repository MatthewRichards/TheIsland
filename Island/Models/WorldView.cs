using Island.Actors;
using Island.Resources;

namespace Island.Models
{
  public class WorldView
  {
    private readonly World world;
    private Location location;

    public WorldView(World world, Location location)
    {
      this.world = world;
      this.location = location;
    }

    public Location Location => location;

    public int Harvest<TResource>() where TResource : Resource
    {
      return world.Harvest<TResource>(location);
    }

    public int CanHarvest<TResource>() where TResource : Resource
    {
      return world.CanHarvest<TResource>(location);
    }

    public int Collect<TResource>(int amount) where TResource : Resource
    {
      return world.Collect<TResource>(location, amount);
    }

    public int CanCollect<TResource>() where TResource : Resource
    {
      return world.CanCollect<TResource>(location);
    }

    public void DropOff<TResource>(int amount) where TResource : Resource
    {
      world.DropOff<TResource>(location, amount);
    }

    public bool IsAccessibleTo(Location newLocation, Actor actor)
    {
      return world.IsAccessibleTo(newLocation, actor);
    }

    public void MoveTo(Location newLocation)
    {
      location = newLocation;
    }
  }
}