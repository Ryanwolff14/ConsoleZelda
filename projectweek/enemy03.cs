using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectweek
{
    class enemy03
    {
        public const ConsoleColor ENEMY03_COLOR = ConsoleColor.Red;

        public static void move()
        {

            InitAI();
            Random rnd = new Random();
            int Direction = 0;
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
            Coordinate newEnemy03 = new Coordinate()
            {
                X = Enemy.X + x,
                Y = Enemy.Y + y
            };

            if (CanMove(newEnemy03))
            {
                RemoveEnemy();

                Console.ForegroundColor = ENEMY03_COLOR;
                Console.SetCursorPosition(newEnemy03.X, newEnemy03.Y);
                Console.Write("╥");

                Enemy = newEnemy03;
            }
        }
        static void RemoveEnemy()
        {
            Console.SetCursorPosition(Enemy.X, Enemy.Y);
            Console.Write(" ");
        }

        static void InitAI()
        {
            

            Enemy = new Coordinate()
            {
                X = 5,
                Y = 5
            };

            MoveEnemy(0, 0);
        }

    }
}
