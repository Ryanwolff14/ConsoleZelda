﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectweek
{
    class InfoMenu
    {
        public static void info()
        {
            Console.WriteLine("Welcome");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Suppose to be a similar game to the 1990s zelda that came out on the nintendo console");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Any tips or ideas on how to make it better just comment on the github page for the application");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("thanks for playing:)");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("whenever your ready to start press any key");
            Console.ReadKey();
        }
    }
}
