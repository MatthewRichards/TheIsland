using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Island.Actors;
using Island.Landscapes;
using Island.Models;

namespace Island
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Island(CreateWorld()));
    }

    private static World CreateWorld()
    {
      Random random = new Random();
      var content = new List<ActorWithBehaviour>();

      var islandInAscii = @"
WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWPPPPPPPPPPPPPPPWWWWWWWWWW
WWWWPPPPPPPPPPPPPPPPPPPPPPPPWWWWWW
WWWPPPPPPPPPPPPPPPPPPPPPPPPPPPPWWW
WWWPPPPPPPPPPPPPPPPPPPPPPPPPPPPWWW
WWWPPPPPPPPPPPPPPPPPPPPPPPPPPPPWWW
WWWPPPPPPPPPPPPPPPPPPPPPPPPPPPPWWW
WWWPPPPPPPPPPPPPPPPPPPPPPPPPPPPWWW
WWWWPPPPPPPPPPPPPPPPPPPPPPPPWWWWWW
WWWWWWWWWPPPPPPPPPPPPPPPWWWWWWWWWW
WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW";

      var landscapeArray = islandInAscii.Split('\n').Skip(1).Select(
        row => row.Trim().ToCharArray()).ToArray();

      Landscape[,] landscape = new Landscape[landscapeArray[0].Length, landscapeArray.Length];

      for (int i = 0; i < landscapeArray.Length; i++)
      {
        for (int j = 0; j < landscapeArray[0].Length; j++)
        {
          var location = new Location(j, i);

          switch (landscapeArray[i][j])
          {
            case 'W':
              landscape[j, i] = new Water();
              break;

            case 'P':
              landscape[j, i] = new Plain();
              break;
          }
        }
      }

      content.Add(new ActorWithBehaviour(new Person(), new Location(landscape.GetLength(0)/2, landscape.GetLength(1)/2)));
      
      return new World(landscape, content);
    }

  }
}
