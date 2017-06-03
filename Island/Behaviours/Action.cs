using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Island.Activities;
using Island.Actors;
using Island.Models;

namespace Island.Behaviours
{
  public class Action
  {
    private readonly Activity activity;
    private readonly Behaviour behaviour;

    public Action(Activity activity, Behaviour behaviour)
    {
      this.activity = activity;
      this.behaviour = behaviour;
    }

    internal Behaviour Act(Actor actor, WorldView state)
    {
      activity.Act(actor, state);
      return behaviour;
    }
  }
}
