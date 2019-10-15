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

        /*
         * Create a singleton instance of the database
         * And creates the table of type UserInfoTable.
         * Return: Singleton instance of the database
         */
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

        /*
         * Insert row into the created table using the
         * current db instance.
         * @Param: Row of type UserInfoTable
         */
        public void InsertTable(UserInfoTable userInfo)
        {
            db.Insert(userInfo);
        }

        /*
         * Returns a list of all the table content
         * using the current db instance.
         * Return: List of type UserInfo
         */
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

        /*
         * Closes the db instance.
         */
        public void CloseDB()
        {
            db.Close();
        }
    }
}