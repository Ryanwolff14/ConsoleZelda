﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace projectweek
{
    public class Startmenu
    {

        public static void MENU()
        {
            Console.WriteLine("WELCOME HERO!!");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("THE WORLD NEEDS YOU");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("1. Startgame");
            Console.WriteLine("2. Info");
            var answer = Console.ReadLine();
            if (answer.Equals("1"))
            {
                Console.WriteLine("GET READY!");
                System.Threading.Thread.Sleep(1000);
            }
            else if (answer.Equals("2"))
            {
                Console.WriteLine("Info Menu");
                System.Threading.Thread.Sleep(1000);
                InfoMenu.info();
            }
            else
            {
                Console.WriteLine("Error");
                MENU();
            }
        }
    }
}