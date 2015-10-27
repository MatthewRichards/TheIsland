﻿using System;
using Island.Actors;
using Island.Models;

namespace Island.Activities
{
  public class Move : Activity
  {
    private readonly int x;
    private readonly int y;

    public Move(int x, int y)
    {
      this.x = x;
      this.y = y;
    }

    public static Move By(int x, int y)
    {
      return new Move(x, y);
    }

    public override void Act(Actor actor, IWorld world)
    {
      Mover mover = actor as Mover;

      if (mover == null)
      {
        throw new Exception("Cannot move a " + actor.GetType());
      }

      mover.MoveTo(mover.Location.Offset(x, y));
    }
  }
}