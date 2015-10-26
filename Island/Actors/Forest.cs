using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Island.Behaviours;
using Island.Models;

namespace Island.Actors
{
  public class Forest : Content
  {
    private int trees;
    private static readonly Random Random = new Random();
    private Behaviour behaviour;

    public Forest(Location location) : base(location)
    {
      trees = Random.Next(0, 100);
      behaviour = GetInitialBehaviour();
    }

    private Behaviour GetInitialBehaviour()
    {
      Activity grow = new Activity(state => trees += 10);
      Behaviour growth = Delay.For(Random.Next(0, 100), () => Do.Activity(grow, GetInitialBehaviour));
      return growth;
    }

    public override void Draw(Graphics graphics, float x, float y, float width, float height)
    {
      graphics.FillRectangle(new SolidBrush(Color.FromArgb(255 * Math.Min(trees, 100) / 100, Color.Green)), x, y, width, height);
    }

    public override void Behave(IWorld state)
    {
      var nowAndNext = behaviour.Invoke(state);
      behaviour = nowAndNext.Item2;
      nowAndNext.Item1.Act(state);
    }
  }
}