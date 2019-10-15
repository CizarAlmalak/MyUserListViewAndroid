using SQLite;

namespace MyUserListAndroid.Models
{
    /*
     * Database table model
     */
    [Table("Items")]
    public class UserInfoTable
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
