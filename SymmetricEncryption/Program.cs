using SymmetricEncryption;
using System.Text;

internal class Program
{
	private static void Main(string[] args)
	{
		Menu menu = new Menu();
		RandomNumber randomNumber = new RandomNumber();
		AES aes = new AES();
		DESEncryption des = new DESEncryption();
		TripleDESEncryption tripleDes = new TripleDESEncryption();
		byte[] key;
		byte[] iv;
		byte[] encryptedText;
		byte[] decryptedText;


		// repeating loop
		while (true)
		{

			//Calling menu
			int input = menu.GetMenu();

			// if input = exit, exit program.
			if (input == 4)
			{
				Environment.Exit(0);
			}

			//Get text to encrypt
			Console.WriteLine("Enter text to encrypt:");
			string textToEncrypt = Console.ReadLine();

			Console.WriteLine("-----------------------");
			Thread.Sleep(1000);

			if (input > 0 && input < 4)
			{
				if (textToEncrypt != "")
				{
					switch (input)
					{
						case 1:
							{
								Console.WriteLine("AES\n");
								key = randomNumber.GenerateRandomNumber(32);
								iv = randomNumber.GenerateRandomNumber(16);

								encryptedText = aes.Encrypt(Encoding.UTF8.GetBytes(textToEncrypt), key, iv);
								Console.WriteLine($"Encrypted text: {Convert.ToBase64String(encryptedText)}");
								decryptedText = aes.Decrypt(encryptedText, key, iv);
								Console.WriteLine($"Decrypted text: {Encoding.UTF8.GetString(decryptedText)}");
								break;
							}
						case 2:
							{
								Console.WriteLine("DES\n");
								key = randomNumber.GenerateRandomNumber(8);
								iv = randomNumber.GenerateRandomNumber(8);

								encryptedText = des.Encrypt(Encoding.UTF8.GetBytes(textToEncrypt), key, iv);
								Console.WriteLine($"Encrypted text: {Convert.ToBase64String(encryptedText)}");
								decryptedText = des.Decrypt(encryptedText, key, iv);
								Console.WriteLine($"Decrypted text: {Encoding.UTF8.GetString(decryptedText)}");

								break;
							}
						case 3:
							{
								Console.WriteLine("TripleDES\n");
								key = randomNumber.GenerateRandomNumber(16);
								iv = randomNumber.GenerateRandomNumber(8);

								encryptedText = tripleDes.Encrypt(Encoding.UTF8.GetBytes(textToEncrypt), key, iv);
								Console.WriteLine($"Encrypted text: {Convert.ToBase64String(encryptedText)}");
								decryptedText = tripleDes.Decrypt(encryptedText, key, iv);
								Console.WriteLine($"Decrypted text: {Encoding.UTF8.GetString(decryptedText)}");
								break;
							}
						default:
							{
								break;
							}
					}

					Console.WriteLine("-----------------------\n");
					Thread.Sleep(2000);
				}
			}
		}
	}
}