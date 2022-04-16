using SQLite4Unity3d;
using UnityEngine;

namespace BallBalance.Database
{
    public static class Database
	{
		internal static string FileRootPath { get; private set; }
		private static SQLiteConnection _connection;

		internal static void Init()
		{
			//set constant addresses
			FileRootPath = Application.persistentDataPath + "/";

			//create SQLite Connection
			_connection = new SQLiteConnection(FileRootPath + "ball_balance.db", SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

			//create tables
			_connection.CreateTable<Account>();
		}
    }
}
