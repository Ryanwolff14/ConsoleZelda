using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectweek
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Startmenu.MENU();
            Console.Clear();
            Game g = new Game();
            Console.CursorVisible = false;
            g.Start();
        }
    }
}
