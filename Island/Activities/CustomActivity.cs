using System;
using Island.Actors;
using Island.Models;

namespace Island.Activities
{
  public class CustomActivity : Activity
  {
    private readonly Action<Actor, IWorld> activity;

    public CustomActivity(Action<Actor, IWorld> activity)
    {
      this.activity = activity;
    }
    
    public override void Act(Actor actor, IWorld state)
    {
      activity(actor, state);
    }
  }
}