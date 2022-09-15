using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;

namespace BallBalance.SavingService
{
	public static class FileSavingService
	{
		public static void SerializeToBinary<T>(T objToSave, string filePath) where T : ISavableFile
		{
			try
			{
				System.IO.Stream stream = File.OpenWrite(filePath);
				BinaryFormatter formatter = new BinaryFormatter();

				formatter.Serialize(stream, objToSave);

				stream.Flush();
				stream.Close();
				stream.Dispose();
			}
			catch (Exception e)
			{
				Debug.LogError($"An error occurred serializeing object to binary. The error message is: {e.Message}");
				return;
			}
		}

		public static T DeserializeFromBinary<T>(string filePath) where T : ISavableFile
		{
			try
			{
				BinaryFormatter formatter = new BinaryFormatter();
				FileStream fileStream;
				fileStream = File.Open(filePath, FileMode.Open);

				T obj = (T)(formatter.Deserialize(fileStream));

				fileStream.Flush();
				fileStream.Close();
				fileStream.Dispose();

				return obj;
			}
			catch (Exception e)
			{
				Debug.LogError($"An error occurred while deserialize from binary. The error message is: {e.Message}");
				return default;
			}
		}

		public static void SaveObjectAsJson<T>(string filePath, T objectToWrite, bool append = false) where T : new()
		{
			TextWriter writer = null;
			try
			{
				var contentsToWriteToFile = JsonUtility.ToJson(objectToWrite);
				writer = new StreamWriter(filePath, append);
				writer.Write(contentsToWriteToFile);
			}
			catch (Exception e)
			{
				Debug.LogError($"An error occurred while writing json file. The error message is: {e.Message}");
			}
			finally
			{
				if (writer != null)
				{
					writer.Close();
				}
			}
		}

		public static T LoadObjectFromJson<T>(string filePath) where T : new()
		{
			TextReader reader = null;
			try
			{
				reader = new StreamReader(filePath);
				var fileContents = reader.ReadToEnd();
				var obj = JsonUtility.FromJson<T>(fileContents);
				return obj;
			}
			catch (Exception e)
			{
				Debug.LogError($"An error occurred while reading json file. The error message is: {e.Message}");
				return default;
			}
			finally
			{
				if (reader != null)
				{
					reader.Close();
				}
			}
		}

		public static void SaveTextToFile(string content, string filePath)
		{
			FileInfo file = new FileInfo(filePath);
			file.Directory.Create();
			File.WriteAllText(file.FullName, content);
		}

		public static string LoadTextFromFile(string filePath)
		{
			var result = File.ReadAllText(filePath);

			return result;
		}
	}
}
