using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Island.Actors;
using Island.Behaviours;
using Island.Landscapes;
using Island.Models;
using Island.Scripts;

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
      var content = new List<ActorWithLocationAndBehaviour>();

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

      var firstPerson = new Person();
      var firstPersonLocation = new Location(landscape.GetLength(0)*2/5, landscape.GetLength(1)/2);
      content.Add(new ActorWithLocationAndBehaviour(
        firstPerson,
        firstPersonLocation,
        new Behaviour(new PersonScript(firstPerson, firstPersonLocation).CollectWood)));

      var secondPerson = new Person();
      var secondPersonLocation = new Location(landscape.GetLength(0) *3/5, landscape.GetLength(1) / 2);
      content.Add(new ActorWithLocationAndBehaviour(
        secondPerson,
        secondPersonLocation,
        new Behaviour(new PersonScript(secondPerson, secondPersonLocation).CollectWood)));
      
      return new World(landscape, content);
    }

  }
}
