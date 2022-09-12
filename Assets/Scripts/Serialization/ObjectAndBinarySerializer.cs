using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace BallBalance.Serialization
{
	public class ObjectAndBinarySerializer : MonoBehaviour
	{
		public void SerializeToBinary<T>(T objToSave, string filePath) where T : ISavableFile
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

		public T DeserializeFromBinary<T>(string filePath) where T : ISavableFile
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
	}
}
