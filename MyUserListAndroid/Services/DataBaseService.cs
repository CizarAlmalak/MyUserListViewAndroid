using System;
using System.Collections.Generic;
using System.IO;
using MyUserListAndroid.Models;
using SQLite;

namespace MyUserListAndroid
{
    public sealed class DataBaseService
    {
        private readonly SQLiteConnection db;
        private static DataBaseService instance;

        /// <summary>
        /// Creates a singleton instance of the database. Also creates the table once.
        /// </summary>
        public static DataBaseService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataBaseService();
                    instance.CreateTable();
                }
                return instance;
            }
        }

        private DataBaseService() {
            var databasePath = Path.Combine(
                Environment.GetFolderPath(
                Environment.SpecialFolder.Personal), "userListTemp.db3");

            db = new SQLiteConnection(databasePath);
        }

        private void CreateTable()
        {
           db.CreateTable<UserInfoTable>();
        }

        /// <summary>
        /// Insert new row of user information in the database
        /// </summary>
        /// <param name="userInfo">The user information of type UserInfoTable</param>
        public void InsertTable(UserInfoTable userInfo)
        {
            db.Insert(userInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Close db instance.
        /// </summary>
        public void CloseDB()
        {
            db.Close();
        }
    }
}