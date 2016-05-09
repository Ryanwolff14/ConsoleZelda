using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectweek
{
    public class Maps
    {
        public static KeyValuePair<ConsoleColor, char> STAGE_ONE_INFO = new KeyValuePair<ConsoleColor, char>(ConsoleColor.Green, '#');

        public static byte[,] STAGE_ONE = new byte[,] {{8, 7},{6, 5}};

        public static List<Tuple<MapFunctions.coord, MapFunctions.coord>> STAGE_ONE_DOORS = new List<Tuple<MapFunctions.coord, MapFunctions.coord>>()
            {
                new Tuple<MapFunctions.coord, MapFunctions.coord>(new MapFunctions.coord(0,0), new MapFunctions.coord(0,1)),
                new Tuple<MapFunctions.coord, MapFunctions.coord>(new MapFunctions.coord(0,1), new MapFunctions.coord(1,1))
            };

        public static readonly MapFunctions.coord STAGE_ONE_START = new MapFunctions.coord(0, 0);


        
    }
}
