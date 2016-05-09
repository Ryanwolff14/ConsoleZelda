using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectweek
{
    public class enemy01 : enemy
    {
        public static void move()
        {
            Random rnd = new Random();
            int Direction = 1;
            while (Direction != 6)
            {
                Direction = rnd.Next(1, 4);
                System.Threading.Thread.Sleep(500);
                if (Direction.Equals(1))
                    MoveEnemy(-1, 0);
                else if (Direction.Equals(2))
                    MoveEnemy(1, 0);
                else if (Direction.Equals(3))
                    MoveEnemy(-1, 0);
                else if (Direction.Equals(4))
                    MoveEnemy(1, 0);
            }
        }

        static void MoveEnemy(int x, int y)
        {
            Coordinate newEnemy01 = new Coordinate()
            {
                X = Enemy.X + x,
                Y = Enemy.Y + y
            };

            if (CanMove(newEnemy01))
            {
                RemoveEnemy01();

                Console.BackgroundColor = ENEMY_COLOR;
                Console.SetCursorPosition(newEnemy01.X, newEnemy01.Y);

                Console.OutputEncoding = System.Text.Encoding.UTF8;

                string input = "\u26C7";

                string output = input;

                System.Console.Write(output);

                Enemy = newEnemy01;
            }
        }
        static void RemoveEnemy01()
        {
            Console.SetCursorPosition(Enemy.X, Enemy.Y);
            Console.Write(" ");
        }


        static void InitAI()
        {
            SetBackgroundColor();

            Enemy = new Coordinate()
            {
                X = 0,
                Y = 0
            };

            MoveEnemy(0, 0);

            move();
        }

    }
}
