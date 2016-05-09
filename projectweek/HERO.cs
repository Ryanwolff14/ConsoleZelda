using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace projectweek
{


    public class HERO
    {

    public enum FaceDirection { Up, Down, Left, Right, noDir }


        public Input playerInput;

        public List<enemies> enemiesInRoom;

        public bool transition = true;

        public bool TookDamage { get; set; }

        public bool UseKey { get; set; }

        public int HP = 6;
        public int CurHP { get; set; }
        public FaceDirection curFacing { get; set; }
        public MapFunctions.coord location { get; set; }


        Thread inputThread;
        TimeSpan timeSinceUpdate = TimeSpan.Zero;
        char c;

        public HERO()
        {
            playerInput = new Input();
            location = new MapFunctions.coord(1, 1);
            CurHP = HP;
            curFacing = FaceDirection.Down;
            inputThread = new Thread(new ThreadStart(GetInput));
            inputThread.Start();
        }

        public HERO(MapFunctions.coord p)
        {
            playerInput = new Input();
            location = p;
            CurHP = HP;
            curFacing = FaceDirection.Down;
            inputThread = new Thread(new ThreadStart(GetInput));
            inputThread.Start();
        }

        public void GetInput()
        {
            while (true)
            {
                if (DateTime.Now.TimeOfDay.Subtract(timeSinceUpdate) > TimeSpan.FromMilliseconds(50))
                {
                    c = playerInput.GetInput();
                    timeSinceUpdate = DateTime.Now.TimeOfDay;
                }
            }
        }

        public void UpdatePlayer(ref List<enemies> e, out FaceDirection roomExit, List<FaceDirection> doors)
        {
            roomExit = FaceDirection.noDir;
            enemiesInRoom = e;
            if (c == 'w')
            {
                curFacing = FaceDirection.Up;
                if (location.Y > 0)
                {
                    if (!CheckCollision())
                    {
                        location = new MapFunctions.coord(location.X, (short)(location.Y - 1));
                        if (location.Y == 0 && transition)
                        {
                            roomExit = FaceDirection.Up;
                            transition = false;
                        }
                        else
                        {
                            transition = true;
                        }
                    }
                }
            }
            if (c == 's')
            {
                curFacing = FaceDirection.Down;
                if (location.Y < Console.WindowHeight - 10)
                {
                    if (!CheckCollision())
                    {
                        location = new MapFunctions.coord(location.X, (short)(location.Y + 1));
                        if (location.Y == Console.WindowHeight - 10 && transition)
                        {
                            roomExit = FaceDirection.Down;
                            transition = false;
                        }
                        else
                        {
                            transition = true;
                        }
                    }
                }
            }
            if (c == 'a')
            {
                curFacing = FaceDirection.Left;
                if (location.X > 0)
                {
                    if (!CheckCollision())
                    {
                        location = new MapFunctions.coord((short)(location.X - 1), location.Y);
                        if (location.X == 0 && transition)
                        {
                            roomExit = FaceDirection.Left;
                            transition = false;
                        }
                        else
                        {
                            transition = true;
                        }
                    }
                }
            }
            if (c == 'd')
            {
                curFacing = FaceDirection.Right;
                if (location.X < Console.WindowWidth - 1)
                {
                    if (!CheckCollision())
                    {
                        location = new MapFunctions.coord((short)(location.X + 1), location.Y);
                        if (location.X == Console.WindowWidth - 1 && transition)
                        {
                            roomExit = FaceDirection.Right;
                            transition = false;
                        }
                        else
                        {
                            transition = true;
                        }
                    }
                }
            }
            if (c == 'e')
            {
                if (location.X > Console.WindowWidth / 2 - 2 && location.X <= Console.WindowWidth / 2 + 2 &&
                    location.Y == 1 && curFacing == FaceDirection.Up)
                {
                    UseKey = true;
                }
                else if (location.X > Console.WindowWidth / 2 - 2 && location.X <= Console.WindowWidth / 2 + 2 &&
                    location.Y == (Console.WindowHeight - 11) && curFacing == FaceDirection.Down)
                {
                    UseKey = true;
                }
                else if (location.Y > (Console.WindowHeight - 10) / 2 - 2 && location.Y <= (Console.WindowHeight - 10) / 2 + 2 &&
                    location.X == Console.WindowWidth - 1 && curFacing == FaceDirection.Right)
                {
                    UseKey = true;
                }
                else if (location.Y > (Console.WindowHeight - 10) / 2 - 2 && location.Y <= (Console.WindowHeight - 10) / 2 + 2 &&
                    location.X == 1 && curFacing == FaceDirection.Left)
                {
                    UseKey = true;
                }
            }
            e = enemiesInRoom;
            c = 'n';
        }

        public void PlaceInNextRoom(FaceDirection exitDirection)
        {
            switch (exitDirection)
            {
                default:
                case FaceDirection.Up:
                    location = new MapFunctions.coord(location.X, (short)(Console.WindowHeight - 10));
                    break;
                case FaceDirection.Down:
                    location = new MapFunctions.coord(location.X, (short)(0));
                    break;
                case FaceDirection.Left:
                    location = new MapFunctions.coord((short)(Console.WindowWidth - 1), location.Y);
                    break;
                case FaceDirection.Right:
                    location = new MapFunctions.coord(0, location.Y);
                    break;
            }
            PlaceCharacterNewScreen();
        }
        public bool CheckCollision()
        {
            if (curFacing == FaceDirection.Up)
            {
                if (MapFunctions.GetCharacterAtPosition(new MapFunctions.coord(location.X, (short)(location.Y - 1))) == '#')
                {
                    return true;
                }
                else if (MapFunctions.COLLISION_CHARS.Contains(MapFunctions.screenBufferArray[location.Y - 1, location.X].AsciiChar))
                {
                    return true;
                }
            }
            else if (curFacing == FaceDirection.Down)
            {
                if (MapFunctions.GetCharacterAtPosition(new MapFunctions.coord(location.X, (short)(location.Y + 1))) == '#')
                {
                    return true;
                }
                else if (MapFunctions.COLLISION_CHARS.Contains(MapFunctions.screenBufferArray[location.Y + 1, location.X].AsciiChar))
                {
                    return true;
                }
            }
            else if (curFacing == FaceDirection.Left)
            {
                if (MapFunctions.GetCharacterAtPosition(new MapFunctions.coord((short)(location.X - 1), location.Y)) == '#')
                {
                    return true;
                }
                else if (MapFunctions.COLLISION_CHARS.Contains(MapFunctions.screenBufferArray[location.Y, location.X - 1].AsciiChar))
                {
                    return true;
                }
            }
            else if (curFacing == FaceDirection.Right)
            {
                if (MapFunctions.GetCharacterAtPosition(new MapFunctions.coord((short)(location.X + 1), location.Y)) == '#')
                {
                    return true;
                }
                else if (MapFunctions.COLLISION_CHARS.Contains(MapFunctions.screenBufferArray[location.Y, location.X + 1].AsciiChar))
                {
                    return true;
                }
            }
            return false;

        }
        public void PlaceCharacter()
        {
            switch (curFacing)
            {
                case FaceDirection.Up:
                default:
                    MapFunctions.DrawToConsole(location, '^');
                    break;
                case FaceDirection.Down:
                    MapFunctions.DrawToConsole(location, 'V');
                    break;
                case FaceDirection.Left:
                    MapFunctions.DrawToConsole(location, '<');
                    break;
                case FaceDirection.Right:
                    MapFunctions.DrawToConsole(location, '>');
                    break;
            }
        }
        public void PlaceCharacterNewScreen()
        {
            Console.SetCursorPosition(location.X, location.Y);
            switch (curFacing)
            {
                case FaceDirection.Up:
                default:
                    MapFunctions.DrawToConsole(location, '^');
                    break;
                case FaceDirection.Down:
                    MapFunctions.DrawToConsole(location, 'V');
                    break;
                case FaceDirection.Left:
                    MapFunctions.DrawToConsole(location, '<');
                    break;
                case FaceDirection.Right:
                    MapFunctions.DrawToConsole(location, '>');
                    break;
            }
        }
    }
}


                //Console.SetCursorPosition(newHero.X, newHero.Y);

                //Console.OutputEncoding = System.Text.Encoding.UTF8;

                //string input = "/\u263B\\";

                //string output = input;

                //System.Console.Write(output);
                