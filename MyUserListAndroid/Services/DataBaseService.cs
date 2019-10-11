using System.Collections.Generic;
using System.IO;
using MyUserListAndroid.Models;
using SQLite;

namespace MyUserListAndroid
{
    public class DataBaseService
    {
        private SQLiteConnection db;

        public void InitDataBase()
        {
            var databasePath = Path.Combine(
                System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Personal), "userListTemp.db3");

            db = new SQLiteConnection(databasePath);
        }

        public void CreateTable()
        {
            db.CreateTable<UserInfoTable>();
        }

        public void InsertTable(UserInfoTable userInfo)
        {
            db.Insert(userInfo);
        }

        public List<UserInfo> getUserInfo()
        {
            List<UserInfo> userList = new List<UserInfo>();
            var table = db.Table<UserInfoTable>();

            foreach (var items in table)
            {
                userList.Add(
                    new UserInfo
                    {
                        FirstName = items.FirstName,
                        LastName = items.LastName,
                        Age = items.Age
                    });
            }
            return userList;
        }

        public void CloseDB()
        {
            db.Close();
        }
    }
}
