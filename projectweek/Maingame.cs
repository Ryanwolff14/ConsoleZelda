using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectweek
{

    public class Maingame
    {
        public const ConsoleColor BACKGROUND_COLOR = Map.MAPCOLOR;


        public static void game()
        {

           Console.SetWindowSize(80, 30);
           
           Map01.Render();
           
        }
    }
}