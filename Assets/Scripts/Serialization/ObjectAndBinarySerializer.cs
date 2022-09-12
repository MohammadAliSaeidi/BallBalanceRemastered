using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace BallBalance.Serialization
{
	public class ObjectAndBinarySerializer : MonoBehaviour
	{
		// TODO: Implement exception handling for this method
		public void SerializeToBinary<T>(T objToSave, string filePath) where T : ISavable
		{
			System.IO.Stream stream = File.OpenWrite(filePath);

			BinaryFormatter formatter = new BinaryFormatter();

			formatter.Serialize(stream, objToSave);

			stream.Flush();
			stream.Close();
			stream.Dispose();
		}

		public T DeserializeFromBinary<T>(string filePath) where T : ISavable
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream fileStream;

			try
			{
				fileStream = File.Open(filePath, FileMode.Open);
			}
			catch (Exception e)
			{
				Debug.LogError($"An error occurred while opening a file via \"FileStream\" object. The error message is: {e.Message}");
				return default;
			}

			T obj;
			try
			{
				obj = (T)(formatter.Deserialize(fileStream));
			}
			catch (Exception e)
			{
				Debug.LogError($"An error occurred while deserializing a file via \"BinaryFormatter\" object. The error message is: {e}");
				return default;
			}

			fileStream.Flush();
			fileStream.Close();
			fileStream.Dispose();

			return obj;
		}
	}
}
