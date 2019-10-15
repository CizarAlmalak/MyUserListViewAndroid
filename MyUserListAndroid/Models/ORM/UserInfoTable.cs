using SQLite;

namespace MyUserListAndroid.Models
{
    /// <summary>
    /// Model for the tabel that is stored in the database
    /// </summary>
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
