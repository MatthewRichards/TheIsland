using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Island.Models;

namespace Island
{
  public partial class Island : Form
  {
    private readonly World world;
    private int time = 0;

    public Island(World world)
    {
      InitializeComponent();

      this.world = world;
    }

    private void WorldImage_Paint(object sender, PaintEventArgs e)
    {
      world.Draw(e.Graphics, WorldImage.ClientSize);
    }

    private void Clock_Tick(object sender, EventArgs e)
    {
      world.ClockTick();
      WorldImage.Invalidate();
      time++;
      TimeLabel.Text = $"Time: {time}";
    }
  }
}
