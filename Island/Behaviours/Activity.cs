using System;
using Island.Models;

namespace Island.Behaviours
{
  public class Activity
  {
    private Action<IWorld> activity; 

    public Activity(Action<IWorld> activity)
    {
      this.activity = activity;
    }

    public void Act(IWorld state)
    {
      activity(state);
    }

    public static Activity None = new Activity(world => { });
  }
}