using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace projectweek
{
	public class Input
	{
		public int[] controls = new int[] { 'w', 'a', 's', 'd', ' ', 'e' };
		ConsoleKeyInfo control;

		public char GetInput()
		{
			control = Console.ReadKey(true);
			if (control.KeyChar == 'w' || control.KeyChar == 'W')
			{
				return 'w';
			}
			if (control.KeyChar == 's' || control.KeyChar == 'S')
			{
				return 's';
			}
			if (control.KeyChar == 'd' || control.KeyChar == 'D')
			{
				return 'd';
			}
			if (control.KeyChar == 'A' || control.KeyChar == 'a')
			{
				return 'a';
			}
			if (control.KeyChar == ' ')
			{
				return ' ';
			}
			if (control.KeyChar == 'e' || control.KeyChar == 'E')
			{
				return 'e';
			}
			if (control.KeyChar == 'q' || control.KeyChar == 'Q')
			{
				return 'q';
			}
			return 'n';
		}
	}
}
