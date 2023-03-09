using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricEncryption
{
	internal class DESEncryption
	{

		public byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv)
		{
			using (DES des = DES.Create())
			{
				// Setting ciphermode to Cipher Block Chaining so it combines the plain block text to the one before it, and ensures that if 
				// there are many blocks containing the same, they will encrypt to different cipher text blocks.
				des.Mode = CipherMode.CBC;
				//Setting padding mode is to ensure there are no space left in the end, if a block is not filled out. 
				des.Padding = PaddingMode.PKCS7;

				// Setting the key used to encrypt/decrypt
				des.Key = key;
				// Setting the iv, ensures repeating in the encryption
				des.IV = iv;

				//Using a memory stream to build the encryption byte by byte, flushes the stream so it is ready to a new encryption,
				//returning the memory stream as i byte array
				using (var memoryStream = new MemoryStream())
				{
					var cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(),
						CryptoStreamMode.Write);

					cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
					cryptoStream.FlushFinalBlock();

					return memoryStream.ToArray();
				}
			}
		}

		public byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv)
		{
			using (DES des = DES.Create())
			{
				des.Mode = CipherMode.CBC;
				des.Padding = PaddingMode.PKCS7;

				des.Key = key;
				des.IV = iv;

				using (var memoryStream = new MemoryStream())
				{
					var cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(),
						CryptoStreamMode.Write);

					cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
					cryptoStream.FlushFinalBlock();

					return memoryStream.ToArray();
				}
			}
		}
	}
}
