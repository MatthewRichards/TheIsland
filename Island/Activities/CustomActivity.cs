using System;
using Island.Actors;
using Island.Models;

namespace Island.Activities
{
  public class CustomActivity : Activity
  {
    private readonly Action<Actor, WorldView> activity;

    public CustomActivity(Action<Actor, WorldView> activity)
    {
      this.activity = activity;
    }
    
    public override void Act(Actor actor, WorldView state)
    {
      activity(actor, state);
    }
  }
}