using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricEncryption
{
	internal class Menu
	{
		public int GetMenu()
		{
			Console.WriteLine("Choose symmetric algorithm encryption\n"
				+ "1: AES\n"
				+ "2: DES\n"
				+ "3: TripleDES\n"
				+ "4: Exit");
			int input = int.Parse(Console.ReadLine());

			return input;
		}
	}
}
