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
	}
}
