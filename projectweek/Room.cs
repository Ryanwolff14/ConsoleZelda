using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace projectweek
{
	public class Room
	{
		public byte RoomType { get; private set; }
		public List<enemies> Enemy { get; set; }

		private List<MapFunctions.Rectangle> blocks;

		public List<MapFunctions.coord> destroyed;

		public Room(byte type, bool Genenemy)
		{
			this.RoomType = type;
			Enemy = new List<enemies>();
			blocks = new List<MapFunctions.Rectangle>();
			destroyed = new List<MapFunctions.coord>();
			GenerateObstacles();
			DrawRoom();
			if (Genenemy)
			{
				Generateenemy();
			}
		}

		public void Generateenemy()
		{
			int numenemy = Game.rand.Next(0, 9);
			for (int n = 0; n < numenemy; n++)
			{
                enemies.type t = enemies;
                int chance = Game.rand.Next(0, 100);
                if (chance >= 60)
                    t = type.enemy01;
                else if (chance >= 40)
                    t = type.enemy02;
                else if (chance >= 20)
                    t = type.enemy03;

				enemies e = new enemies(t);

                if (RoomType == 9)
                {
                    int left = Console.WindowWidth - 3 * (Console.WindowWidth / 4);

                    if (e.FindPosition(left, 78))
                        Enemy.Add(e);
                }
                else if (RoomType == 10)
                {
                    int right = Console.WindowWidth - (Console.WindowWidth / 4);
                    if (e.FindPosition(5, right))
                        Enemy.Add(e);
                }
                else if (RoomType == 11 || RoomType == 12)
                {
                    int left = Console.WindowWidth - 3 * (Console.WindowWidth / 4);
                    int right = Console.WindowWidth - (Console.WindowWidth / 4);
                    if (e.FindPosition(left, right))
                        Enemy.Add(e);
                }
                else
                {
                    if (e.FindPosition(5, 78))
                        Enemy.Add(e);
                }
			}
		}

		public void GenerateObstacles()
		{
			int num = Game.rand.Next(0, 5);
			for (int i = 0; i < num; i++)
			{
				MapFunctions.Rectangle obst = new MapFunctions.Rectangle();
				obst.Left = (short)(Game.rand.Next(10, 66));
				obst.Right = (short)(Game.rand.Next(obst.Left, obst.Left + (Console.WindowWidth - obst.Left - 10)));
				obst.Top = (short)(Game.rand.Next(3, 9));
				obst.Bottom = (short)(Game.rand.Next(obst.Top, obst.Top + (Console.WindowHeight - obst.Top - 13)));
				blocks.Add(obst);
			}
		}

		public void DrawRoom()
		{
			short yBottom = (short)(Console.WindowHeight - 10);
			short xFar = (short)(Console.WindowWidth - 1);
			#region Room Borders
			switch (RoomType)
			{
				case 0:
					{
						#region 4-way intersection
						for (short i = 0; i < Console.WindowWidth / 2 - 2; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord(i, (short)(0)), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord(i, yBottom), '#');
						}
						for (short i = (short)(Console.WindowWidth / 2 + 2); i < Console.WindowWidth; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord(i, (short)(0)), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord(i, yBottom), '#');
						}
						for (short i = 0; i < (Console.WindowHeight - 10) / 2 - 2; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(0), i), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord(xFar, i), '#');
						}
						for (short i = (short)((Console.WindowHeight - 10) / 2 + 2); i < Console.WindowHeight - 10; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(0), i), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord(xFar, i), '#');
						}
						#endregion
						break;
					}
				case 1:
					{
						#region T-up Intersection
						for (int i = 0; i < Console.WindowWidth / 2 - 2; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');
						}
						for (int i = Console.WindowWidth / 2 + 2; i < Console.WindowWidth; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');

                        for (int i = 0; i < Console.WindowWidth; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');

                        for (int i = 0; i < (Console.WindowHeight - 10) / 2 - 2; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord(0, (short)(i)), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord(xFar, (short)(i)), '#');
						}
						for (int i = (Console.WindowHeight - 10) / 2 + 2; i < Console.WindowHeight - 10; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord(0, (short)(i)), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord(xFar, (short)(i)), '#');
						}
						#endregion
						break;
					}
				case 2:
					{
						#region T-down Intersection
						for (int i = 0; i < Console.WindowWidth / 2 - 2; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');

                        for (int i = Console.WindowWidth / 2 + 2; i < Console.WindowWidth; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');

                        for (int i = 0; i < Console.WindowWidth; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');

                        for (int i = 0; i < (Console.WindowHeight - 10) / 2 - 2; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord(xFar, (short)(i)), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord(0, (short)(i)), '#');
						}
						for (int i = (Console.WindowHeight - 10) / 2 + 2; i < Console.WindowHeight - 10; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord(0, (short)(i)), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord(xFar, (short)(i)), '#');
						}
						#endregion
						break;
					}
				case 3:
					{
						#region T-Left intersection
						for (int i = 0; i < Console.WindowWidth / 2 - 2; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');
						}
						for (int i = Console.WindowWidth / 2 + 2; i < Console.WindowWidth; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');
						}
						for (int i = 0; i < (Console.WindowHeight - 10) / 2 - 2; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(0, (short)(i)), '#');

                        for (int i = (Console.WindowHeight - 10) / 2 + 2; i < Console.WindowHeight - 10; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(0, (short)(i)), '#');

						for (int i = 0; i < Console.WindowHeight - 10; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(xFar, (short)(i)), '#');

                        #endregion
						break;
					}
				case 4:
					{
						#region T-Right intersection
						for (int i = 0; i < Console.WindowWidth / 2 - 2; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');
						}
						for (int i = Console.WindowWidth / 2 + 2; i < Console.WindowWidth; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');
						}
						for (int i = 0; i < (Console.WindowHeight - 10) / 2 - 2; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(xFar, (short)(i)), '#');

                        for (int i = (Console.WindowHeight - 10) / 2 + 2; i < Console.WindowHeight - 10; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(xFar, (short)(i)), '#');

                        for (int i = 0; i < Console.WindowHeight - 10; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(0, (short)(i)), '#');

                        #endregion
						break;
					}
				case 5:
					{
						#region NW-corner
						for (int i = 0; i < Console.WindowWidth / 2 - 2; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');

                        for (int i = Console.WindowWidth / 2 + 2; i < Console.WindowWidth; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#'); ;

                        for (int i = 0; i < (Console.WindowHeight - 10) / 2 - 2; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(0, (short)(i)), '#');

                        for (int i = (Console.WindowHeight - 10) / 2 + 2; i < Console.WindowHeight - 10; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(0, (short)(i)), '#');

                        for (int i = 0; i < Console.WindowWidth; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');

                        for (int i = 0; i < Console.WindowHeight - 10; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(xFar, (short)(i)), '#');

                        #endregion
						break;
					}
				case 6:
					{
						#region NE-corner
						for (int i = 0; i < Console.WindowWidth / 2 - 2; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');

                        for (int i = Console.WindowWidth / 2 + 2; i < Console.WindowWidth; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');

                        for (int i = 0; i < (Console.WindowHeight - 10) / 2 - 2; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(xFar, (short)(i)), '#');

                        for (int i = (Console.WindowHeight - 10) / 2 + 2; i < Console.WindowHeight - 10; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(xFar, (short)(i)), '#');

						for (int i = 0; i < Console.WindowWidth; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');

						for (int i = 0; i < Console.WindowHeight - 10; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(0, (short)(i)), '#');

						#endregion
						break;
					}
				case 7:
					{
						#region SW-corner
						for (int i = 0; i < Console.WindowWidth / 2 - 2; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');

						for (int i = Console.WindowWidth / 2 + 2; i < Console.WindowWidth; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');

						for (int i = 0; i < (Console.WindowHeight - 10) / 2 - 2; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(0, (short)(i)), '#');

						for (int i = (Console.WindowHeight - 10) / 2 + 2; i < Console.WindowHeight - 10; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(0, (short)(i)), '#');

						for (int i = 0; i < Console.WindowWidth; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');

						for (int i = 0; i < Console.WindowHeight - 10; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(xFar, (short)(i)), '#');

						#endregion
						break;
					}
				case 8:
					{
						#region SE-corner
						for (int i = 0; i < Console.WindowWidth / 2 - 2; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');

						for (int i = Console.WindowWidth / 2 + 2; i < Console.WindowWidth; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');

						for (int i = 0; i < (Console.WindowHeight - 10) / 2 - 2; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(xFar, (short)(i)), '#');

						for (int i = (Console.WindowHeight - 10) / 2 + 2; i < Console.WindowHeight - 10; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(xFar, (short)(i)), '#');

						for (int i = 0; i < Console.WindowWidth; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');

						for (int i = 0; i < Console.WindowHeight - 10; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(0, (short)(i)), '#');

						#endregion
						break;
					}
				case 9:
					{
						#region E-dead End
						short stop = (short)(Console.WindowWidth - 3 * (Console.WindowWidth / 4));
						for (int i = stop; i < Console.WindowWidth; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');
						}
						for (int i = 0; i <= Console.WindowHeight - 10; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(stop, (short)(i)), '#');

						for (int i = 0; i < (Console.WindowHeight - 10) / 2 - 2; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(xFar, (short)(i)), '#');

						for (int i = (Console.WindowHeight - 10) / 2 + 2; i < Console.WindowHeight - 10; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(xFar, (short)(i)), '#');

						#endregion
						break;
					}
				case 10:
					{
						#region W-dead End
						short stop = (short)(Console.WindowWidth - (Console.WindowWidth / 4));
						for (int i = 0; i < stop; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');
						}
						for (int i = 0; i <= Console.WindowHeight - 10; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(stop, (short)(i)), '#');

						for (int i = 0; i < (Console.WindowHeight - 10) / 2 - 2; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(0, (short)(i)), '#');

						for (int i = (Console.WindowHeight - 10) / 2 + 2; i < Console.WindowHeight - 10; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord(0, (short)(i)), '#');

						#endregion
						break;
					}
				case 11:
					{
						#region N-dead End
						short Wstop = (short)(Console.WindowWidth - 3 * (Console.WindowWidth / 4));
						short Estop = (short)(Console.WindowWidth - (Console.WindowWidth / 4));

						for (int i = Wstop; i < Console.WindowWidth / 2 - 2; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');

						for (int i = Console.WindowWidth / 2 + 2; i < Estop; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');

						for (int i = Wstop; i <= Estop; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');

                        for (int i = 0; i < Console.WindowHeight - 10; i++)
                        {
                            MapFunctions.DrawToConsole(new MapFunctions.coord(Wstop, (short)(i)), '#');
                            MapFunctions.DrawToConsole(new MapFunctions.coord(Estop, (short)(i)), '#');
                        }

						#endregion
						break;
					}
				case 12:
					{
						#region S-dead End
						short Wstop = (short)(Console.WindowWidth - 3 * (Console.WindowWidth / 4));
						short Estop = (short)(Console.WindowWidth - (Console.WindowWidth / 4));

						for (int i = Wstop; i < Console.WindowWidth / 2 - 2; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');

						for (int i = Console.WindowWidth / 2 + 2; i <= Estop; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');

						for (int i = Wstop; i <= Estop; i++)
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');

                        for (int i = 0; i < Console.WindowHeight - 10; i++)
                        {
                            MapFunctions.DrawToConsole(new MapFunctions.coord(Wstop, (short)(i)), '#');
                            MapFunctions.DrawToConsole(new MapFunctions.coord(Estop, (short)(i)), '#');
                        }

						#endregion
						break;
					}
				case 13:
					{
						#region H-Hall
						for (int i = 0; i < Console.WindowWidth; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');
						}
						for (int i = 0; i < (Console.WindowHeight - 10) / 2 - 2; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord(0, (short)(i)), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord(xFar, (short)(i)), '#');
						}
						for (int i = (Console.WindowHeight - 10) / 2 + 2; i < Console.WindowHeight - 10; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord(0, (short)(i)), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord(xFar, (short)(i)), '#');
						}
						#endregion
						break;
					}
				case 14:
					{
						#region V-Hall
						short Wstop = (short)(Console.WindowWidth - 3 * (Console.WindowWidth / 4));
						short Estop = (short)(Console.WindowWidth - (Console.WindowWidth / 4));
						for (int i = Wstop; i < Console.WindowWidth / 2 - 2; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');
						}
						for (int i = Console.WindowWidth / 2 + 2; i <= Estop; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), 0), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord((short)(i), yBottom), '#');
						}
						for (int i = 0; i < Console.WindowHeight - 10; i++)
						{
							MapFunctions.DrawToConsole(new MapFunctions.coord(Wstop, (short)(i)), '#');
							MapFunctions.DrawToConsole(new MapFunctions.coord(Estop, (short)(i)), '#');
						}
						#endregion
						break;
					}
			}
			#endregion

			#region Draw Obstacles
			for (int index = 0; index < blocks.Count; index++)
			{
				for (short x = blocks[index].Left; x <= blocks[index].Right; x++)
				{
                    for (short y = blocks[index].Top; y <= blocks[index].Bottom; y++) ;
				}
			}
			#endregion

			#region Erase Sections
			for (int index = 0; index < destroyed.Count; index++)
				MapFunctions.DrawToConsole(new MapFunctions.coord(destroyed[index].X, destroyed[index].Y), ' ');

			#endregion
		}
	}
}
