using SQLite4Unity3d;

namespace BallBalance
{
    public class Account
    {
        [PrimaryKey]
        public string id { get; set; }
        public string name { get; set; }
    }
}
