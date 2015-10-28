using System.Drawing;
using Island.Actors;
using Island.Behaviours;

namespace Island.Models
{
  public class ActorWithBehaviour
  {
    private readonly Actor actor;
    private Location location;
    private Behaviour behaviour;

    public ActorWithBehaviour(Actor actor, Location location)
    {
      this.actor = actor;
      this.location = location;
      behaviour = actor.GetInitialBehaviour();
    }

    public void Behave(World state)
    {
      var worldView = new WorldView(state, location);
      var nowAndNext = behaviour.Invoke(worldView);
      nowAndNext.Item1.Act(actor, worldView);
      behaviour = nowAndNext.Item2;
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