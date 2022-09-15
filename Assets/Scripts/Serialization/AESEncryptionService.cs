using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

namespace BallBalance.Serialization.Encryption
{
	public static class AESEncryptionService
	{
		public static byte[] GenerateRandomSalt()
		{
			byte[] data = new byte[32];

			using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
			{
				for (int i = 0; i < 10; i++)
				{
					// Fille the buffer with the generated data
					rng.GetBytes(data);
				}
			}

			return data;
		}

		public static void FileEncrypt(string filePath, string password)
		{
			byte[] salt = GenerateRandomSalt();
			FileStream fsCrypt = new FileStream(filePath + ".aes", FileMode.Create);
			byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

			RijndaelManaged AES = new RijndaelManaged();
			AES.KeySize = 256;
			AES.BlockSize = 128;
			AES.Padding = PaddingMode.PKCS7;
			var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
			AES.Key = key.GetBytes(AES.KeySize / 8);
			AES.IV = key.GetBytes(AES.BlockSize / 8);
			AES.Mode = CipherMode.CFB;

			// write salt to the begining of the output file, so in this case can be random every time
			fsCrypt.Write(salt, 0, salt.Length);

			CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

			FileStream fsIn = new FileStream(filePath, FileMode.Open);

			//create a buffer (1mb) so only this amount will allocate in the memory and not the whole file
			byte[] buffer = new byte[1048576];
			int read;

			try
			{
				while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
				{
					cs.Write(buffer, 0, read);
				}

				fsIn.Close();
			}
			catch (Exception e)
			{
				Debug.LogError($"An Error occurred while encrypting file the error message is: {e.Message}");
			}
			finally
			{
				cs.Close();
				fsCrypt.Close();
			}
		}

		public static byte[] EncryptBytes(byte[] bytes, string password)
		{
			byte[] ivSeed = Guid.NewGuid().ToByteArray();

			var rfc = new Rfc2898DeriveBytes(password, ivSeed);
			byte[] Key = rfc.GetBytes(16);
			byte[] IV = rfc.GetBytes(16);

			byte[] encrypted;

			using (MemoryStream mstream = new MemoryStream())
			using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
			using (CryptoStream cryptoStream = new CryptoStream(mstream, aesProvider.CreateEncryptor(Key, IV), CryptoStreamMode.Write))
			{
				cryptoStream.Write(bytes, 0, bytes.Length);
				encrypted = mstream.ToArray();
			}

			var messageLengthAs32Bits = Convert.ToInt32(bytes.Length);
			var messageLength = BitConverter.GetBytes(messageLengthAs32Bits);

			encrypted = encrypted.Prepend(ivSeed);
			encrypted = encrypted.Prepend(messageLength);

			return encrypted;
		}

		public static void FileDecrypt(string filePath, string decryptedFileSavingPath, string password)
		{
			byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
			byte[] salt = new byte[32];

			FileStream fsCrypt = new FileStream(filePath, FileMode.Open);
			fsCrypt.Read(salt, 0, salt.Length);

			RijndaelManaged AES = new RijndaelManaged();
			AES.KeySize = 256;
			AES.BlockSize = 128;
			var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
			AES.Key = key.GetBytes(AES.KeySize / 8);
			AES.IV = key.GetBytes(AES.BlockSize / 8);
			AES.Padding = PaddingMode.PKCS7;
			AES.Mode = CipherMode.CFB;

			CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

			FileStream fsOut = new FileStream(decryptedFileSavingPath, FileMode.Create);

			int read;
			byte[] buffer = new byte[1048576];

			try
			{
				while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
				{
					fsOut.Write(buffer, 0, read);
				}
			}
			catch (CryptographicException ex_CryptographicException)
			{
				Debug.LogError($"CryptographicException error: {ex_CryptographicException.Message}");
			}
			catch (Exception e)
			{
				Debug.LogError($"Error: {e.Message}");
			}

			try
			{
				cs.Close();
			}
			catch (Exception e)
			{
				Debug.LogError($"Error by closing CryptoStream: {e.Message}");
			}
			finally
			{
				fsOut.Close();
				fsCrypt.Close();
			}
		}
	}
}