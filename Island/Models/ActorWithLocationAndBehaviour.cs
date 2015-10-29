using System.Drawing;
using Island.Actors;
using Island.Behaviours;
using Island.Scripts;

namespace Island.Models
{
  public class ActorWithLocationAndBehaviour
  {
    private readonly Actor actor;
    private Location location;
    private Behaviour behaviour;

    public ActorWithLocationAndBehaviour(Actor actor, Location location, Behaviour behaviour)
    {
      this.actor = actor;
      this.location = location;
      this.behaviour = behaviour;
    }

    public void Behave(World state)
    {
      var worldView = new WorldView(state, location);
      behaviour = behaviour.Invoke(actor, worldView);
      location = worldView.Location;
    }

    public Location Location => location;

    public Actor Actor => actor;

    public void Draw(Graphics graphics, float x, float y, float width, float height)
    {
      actor.Draw(graphics, x, y, width, height);
    }
  }
}