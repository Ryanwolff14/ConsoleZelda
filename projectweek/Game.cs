using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using static projectweek.HERO;

namespace projectweek
{
    public class Game
	{
		#region Vars
		public static Random rand = new Random();
        public static HERO HERO { get; set; }
        public MapDetails m { get; set; }
        public enemies e { get; set; }

		public static bool gameOver = false;
		public static bool ResetGame = false;

		public FaceDirection mapRoomTransition = FaceDirection.noDir;

		public bool levelTransition;
		public bool setBg = true;



		#endregion

		public Game()
        {
			Console.SetWindowSize(80, 30);
        }

		public void Start()
		{
			while (true)
			{
				if (ResetGame)
				{
					ResetGame = false;
				}


                #region Enemies


                CheckEnemyCollision();

                if (HERO.TookDamage)
                {
                    HERO.TookDamage = false;
                }
                #endregion

                #region Change Rooms
                if (mapRoomTransition != FaceDirection.noDir)
				{
					m.MoveToNextRoom(mapRoomTransition);
					HERO.PlaceInNextRoom(mapRoomTransition);


					MapDetails r = m.getRoom();
                    m.SetRoom(r);
				}
				#endregion


            }
		}                 

		public void CheckEnemyCollision()
		{
			foreach (enemies e in type)
			{
				if (e.loc.Equals(new MapFunctions.coord((short)(HERO.location.X - 1), HERO.location.Y)))
				{
					MapFunctions.DrawToConsole(HERO.location, ' ');
					if (HERO.location.X + 4 >= Console.WindowWidth - 1)
					{
						HERO.location = new MapFunctions.coord((short)(Console.WindowWidth - 2), HERO.location.Y);
					}
					else
					{
						HERO.location = new MapFunctions.coord((short)(HERO.location.X + 4), HERO.location.Y);
					} 
                    HERO.TookDamage = true;
					HERO.CurHP -= e.Damage;
				}
				else if (e.loc.Equals(new MapFunctions.coord((short)(HERO.location.X + 1), HERO.location.Y)))
				{
					MapFunctions.DrawToConsole(HERO.location, ' ');
					if (HERO.location.X - 4 <= 0)
					{
						HERO.location = new MapFunctions.coord((short)(1), HERO.location.Y);
					}
					else
					{
						HERO.location = new MapFunctions.coord((short)(HERO.location.X - 4), HERO.location.Y);
					}
					HERO.TookDamage = true;
					HERO.CurHP -= e.Damage;
				}
				else if (e.loc.Equals(new MapFunctions.coord(HERO.location.X, (short)(HERO.location.Y - 1))))
				{
					MapFunctions.DrawToConsole(HERO.location, ' ');
					if (HERO.location.Y + 4 >= Console.WindowHeight - 11)
					{
						HERO.location = new MapFunctions.coord(HERO.location.X, (short)(Console.WindowHeight - 12));
					}
					else
					{
						HERO.location = new MapFunctions.coord(HERO.location.X, (short)(HERO.location.Y + 4));
					} HERO.TookDamage = true;
					HERO.CurHP -= e.Damage;
				}
				else if (e.loc.Equals(new MapFunctions.coord(HERO.location.X, (short)(HERO.location.Y + 1))))
				{
					MapFunctions.DrawToConsole(HERO.location, ' ');
					if (HERO.location.Y - 4 <= 0)
					{
						HERO.location = new MapFunctions.coord(HERO.location.X, (short)(1));
					}
					else
					{
						HERO.location = new MapFunctions.coord(HERO.location.X, (short)(HERO.location.Y - 4));
					}
					HERO.TookDamage = true;
					HERO.CurHP -= e.Damage;
				}
			}
			if (HERO.CurHP <= 0)
			{
				gameOver = true;
                DrawScreen();

			}
			HERO.PlaceCharacter();
		}

		public void DrawScreen()
		{
		    if (gameOver==true)
		    {
                Console.WriteLine("GAMEOVER");

		    }
		    else
		    {

                HERO.PlaceCharacter();
	        }
		}

	}
}
