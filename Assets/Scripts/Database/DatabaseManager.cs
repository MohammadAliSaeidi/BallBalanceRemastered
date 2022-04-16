using System.Threading.Tasks;
using UnityEngine;

namespace BallBalance.Database
{
	public static class DatabaseManager
	{
		internal static async Task InitDatabase()
		{
			await Task.Run(
				delegate
				{
					Database.Init();
				});
		}

		internal static async Task InsertOrReplace(Account account)
		{
			await Task.Run(
				delegate
				{
					Database.InsertOrReplace(account);
				});
		}
	}
}
