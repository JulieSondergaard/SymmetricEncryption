using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricEncryption
{
	internal class RandomNumber
	{

		public byte[] GenerateRandomNumber(int length)
		{
			using (var randomNumberGenerator = RandomNumberGenerator.Create())
			{
				var randomNumber = new byte[length];
				randomNumberGenerator.GetBytes(randomNumber);

				return randomNumber;
			}
		}
	}
}
