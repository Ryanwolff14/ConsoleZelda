using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace projectweek
{
    public class MapFunctions
        {


        [StructLayout(LayoutKind.Sequential)]

        public struct coord
        {
            public short X;
            public short Y;

            public coord(short X, short Y)
            {
                this.X = X;
                this.Y = Y;
            }
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct Rectangle
        {
            public short Left;
            public short Top;
            public short Right;
            public short Bottom;
        };

        [StructLayout(LayoutKind.Sequential)]

        public struct screen_buffer
        {
            public uint cbSize;
            public coord dwSize;
            public coord dwCursorPosition;
            public short wAttributes;
            public Rectangle srWindow;
            public coord dwMaximumWindowSize;

            public ushort wPopupAttributes;
            public bool bFullscreenSupported;

            public static screen_buffer Create()
            {
                return new screen_buffer { cbSize = 96 };
            }
        };

        [StructLayout(LayoutKind.Explicit)]

        public struct CHAR_INFO
        {
            [FieldOffset(0)]
            internal char UnicodeChar;
            [FieldOffset(0)]
            internal char AsciiChar;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadConsoleOutputCharacter(IntPtr hConsoleOutput, [Out] StringBuilder lpCharacter, uint nLenght, coord dwReadcoord, out uint lpNumberOfCharactersRead);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int nStdHandle);

        public const int input_handle = -10;
        public const int output_handle = -11;

        public static readonly string COLLISION_CHARS = "¥";

        public static CHAR_INFO[,] screenBufferArray = new CHAR_INFO[30, 80];
        public static object guide;

        public static void SetBackgroundColor(ConsoleColor color)
        {
            for (int x = 0; x < Console.WindowWidth; x++)
            {
                for (int y = 0; y < Console.WindowHeight - 10; y++)
                {
                    DrawToConsole(new coord((short)x, (short)y), " ", ConsoleColor.Green);
                }
            }
        }

        public static void GetScreenBuffer()
        {
            Rectangle readArea;

            readArea.Top = 0;
            readArea.Left = 0;
            readArea.Right = 79;
            readArea.Bottom = 29;
        }


        public static char GetCharacterAtPosition(MapFunctions.coord pos)
        {
            IntPtr handler = GetStdHandle(output_handle);
            uint width = 1;
            StringBuilder sb = new StringBuilder((int)width);
            coord readcoord = new coord(pos.X, pos.Y);
            uint numCharsRead = 0;
            if (!ReadConsoleOutputCharacter(handler, sb, width, readcoord, out numCharsRead))
                return (char)0;
            else return sb.ToString()[0];
        }

        public static void DrawToConsole(coord p, char c)
        {
            screenBufferArray[p.Y, p.X].AsciiChar = c;
        }
        public static void DrawToConsole(char p, coord erase)
        {
            screenBufferArray[Console.WindowWidth, Console.WindowHeight].AsciiChar = p;
            screenBufferArray[erase.Y, erase.X].AsciiChar = ' ';
        }

        public static void DrawToConsole(coord p, string c, ConsoleColor color)
        {
            int stringPos = 0;
            for (short x = p.X; x < p.X + c.Length; x++)
            {
                screenBufferArray[p.Y, x].AsciiChar = c[stringPos];
                stringPos++;
            }
        }
    }

}
