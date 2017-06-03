using System;
using Island.Actors;
using Island.Models;
using Island.Resources;

namespace Island.Activities
{
  public static class Do
  {
    public static Activity Collect<TResource>() where TResource : Resource
    {
      return new Doer((actor, state) =>
      {
        int capacity = ((Person)actor).CanCarry<TResource>();
        int amountCollected = state.Collect<TResource>(capacity);
        ((Person)actor).PickUp<TResource>(amountCollected);
      });
    }

    public static Activity Harvest<TResource>() where TResource : Resource
    {
      return new Doer((actor, state) =>
      {
        state.Harvest<TResource>();
      });
    }

    public static Activity DropOff<TResource>(int amount) where TResource : Resource
    {
      return new Doer((actor, state) =>
      {
        int amountDropped = ((Person)actor).Drop<TResource>(amount);
        state.DropOff<TResource>(amountDropped);
      });
    }

    private class Doer : Activity
    {
      private readonly Action<Actor, WorldView> action;

      public Doer(Action<Actor, WorldView> action)
      {
        this.action = action;
      }

      public override void Act(Actor actor, WorldView state)
      {
        action(actor, state);
      }
    }
  }
}