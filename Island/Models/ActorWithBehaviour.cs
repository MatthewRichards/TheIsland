using System.Drawing;
using Island.Actors;
using Island.Behaviours;

namespace Island.Models
{
  public class ActorWithBehaviour : IActor
  {
    private readonly Actor actor;
    private Behaviour behaviour;

    public ActorWithBehaviour(Actor actor)
    {
      this.actor = actor;
      behaviour = actor.GetInitialBehaviour();
    }

    public void Behave(IWorld state)
    {
      var nowAndNext = behaviour.Invoke(state);
      nowAndNext.Item1.Act(actor, state);
      behaviour = nowAndNext.Item2;
    }

    public Location Location => actor.Location;

    public void Draw(Graphics graphics, float x, float y, float width, float height)
    {
      actor.Draw(graphics, x, y, width, height);
    }
  }
}