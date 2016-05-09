using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static projectweek.HERO;

namespace projectweek
{
	
	public class enemies
	{


		public MapFunctions.coord loc { get; private set; }
		public type type {get; private set;}
		public int Damage { get; set; }
		public TimeSpan timeSinceUpdate = TimeSpan.Zero;
        public enum type { enemy01, enemy02, enemy03 }		
		public enemies(type e)
		{
			type = e;
			switch (type)
			{
				case type.enemy01:
					Damage = 2;
					break;
				case type.enemy02:
					Damage = 4;
					break;
				case type.enemy03:
					Damage = 6;
					break;
			}				
		}

		public bool FindPosition(int Left, int Right)
		{
			bool posFound = false;
			byte tries = 0;
			while (!posFound && tries < 20)
			{
				short xPos = (short)(Game.rand.Next(Left + 1, Right - 1));
				short yPos = (short)(Game.rand.Next(5, 19));
				if (MapFunctions.screenBufferArray[yPos, xPos].AsciiChar == ' ')
				{
					posFound = true;
					loc = new MapFunctions.coord(xPos, yPos);
					break;
				}
				tries++;
			}

			if (!posFound) return false;
			else return true;
		}
		public void MoveEnemy()
		{
			if (DateTime.Now.TimeOfDay.Subtract(timeSinceUpdate) > TimeSpan.FromSeconds(1))
			{
				timeSinceUpdate = DateTime.Now.TimeOfDay;
				MapFunctions.coord curPlayerPos = Game.HERO.location;


				if (loc.X < curPlayerPos.X && loc.X < Console.WindowWidth - 3)
				{
					if (!CheckCollision(FaceDirection.Right))
					{
						MapFunctions.DrawToConsole(loc, ' ');
						loc = new MapFunctions.coord((short)(loc.X + 1), loc.Y);
					}
				}
				else if (loc.X > curPlayerPos.X && loc.X > 2)
				{
					if (!CheckCollision(FaceDirection.Left))
					{
						MapFunctions.DrawToConsole(loc, ' ');
						loc = new MapFunctions.coord((short)(loc.X - 1), loc.Y);
					}
				}

	
				if (loc.Y < curPlayerPos.Y && loc.Y < Console.WindowHeight - 13)
				{
					if (!CheckCollision(FaceDirection.Down))
					{
						MapFunctions.DrawToConsole(loc, ' ');
						loc = new MapFunctions.coord(loc.X, (short)(loc.Y + 1));
					}
				}
				else if (loc.Y > curPlayerPos.Y && loc.Y > 2)
				{
					if (!CheckCollision(FaceDirection.Up))
					{
						MapFunctions.DrawToConsole(loc, ' ');
						loc = new MapFunctions.coord(loc.X, (short)(loc.Y - 1));
					}
				}
			}
			DrawEnemy();
		}

		public void DrawEnemy()
		{
			switch (type)
			{
				case type.enemy01:
					MapFunctions.DrawToConsole(loc, 'E');
					break;
				case type.enemy02:
					MapFunctions.DrawToConsole(loc, 'B');
					break;
				case type.enemy03:
					MapFunctions.DrawToConsole(loc, 'F');
					break;

			}			
		}
		public bool CheckCollision(FaceDirection dir)
		{
			if (type == type.enemy01 || type == type.enemy03) return false;
			switch (dir)
			{
				case FaceDirection.Up:
					if (MapFunctions.COLLISION_CHARS.Contains(MapFunctions.screenBufferArray[loc.Y - 1, loc.X].AsciiChar))
					{
						return true;
					}
					break;
				case FaceDirection.Down:
					if (MapFunctions.COLLISION_CHARS.Contains(MapFunctions.screenBufferArray[loc.Y + 1, loc.X].AsciiChar))
					{
						return true;
					}
					break;
				case FaceDirection.Left:
					if (MapFunctions.COLLISION_CHARS.Contains(MapFunctions.screenBufferArray[loc.Y, loc.X - 1].AsciiChar))
					{
						return true;
					}
					break;
				case FaceDirection.Right:
					if (MapFunctions.COLLISION_CHARS.Contains(MapFunctions.screenBufferArray[loc.Y, loc.X + 1].AsciiChar))
					{
						return true;
					}
					break;
			}
			return false;
		}
	}
}
