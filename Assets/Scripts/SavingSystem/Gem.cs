using SQLite4Unity3d;

namespace BallBalance
{
	public class Gem
	{
		[PrimaryKey]
		public int Id { get; set; }
		public int LevelId { get; set; }
		public bool IsCollected { get; set; }
	}
}
