using BallBalance.SavingService;
using System.Collections.Generic;

namespace BallBalance
{
	// every account has a save file with its name
	public class AccountSaveModel : ISavableFile
	{
		public LevelSaveModel lastPlayedLevelSave;
		public List<LevelInfoModel> LevelsInfo = new List<LevelInfoModel>();
		public int GemsCount;

		public AccountSaveModel()
		{
		}
	}
}
