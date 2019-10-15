using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using MyUserListAndroid.Models;

namespace MyUserListAndroid
{
    public class UserListViewAdapter : BaseAdapter<UserInfo>
    {
        private readonly List<UserInfo> userInfo;
        private readonly Context activityContext;

        /// <summary>
        /// This functions passes the User list in the adapter
        /// </summary>
        /// <param name="context">Parent context of type Context</param>
        /// <param name="userList">List of all the users in the database</param>
        public UserListViewAdapter(Context context, List<UserInfo> userList)
        {
            userInfo = userList;
            activityContext = context;
        }

        /// <summary>
        /// BaseAdapter contract method
        /// </summary>
        /// <param name="position">Position of type int</param>
        /// <returns>The user on position of type UserInfo</returns>
        public override UserInfo this[int position] => userInfo[position];

        /// <summary>
        /// returns the amount of users in the list
        /// </summary>
        public override int Count => userInfo.Count;


        /// <summary>
        /// returns a id of the user in the list. In this case position equals id
        /// </summary>
        /// <param name="position">position of type int</param>
        /// <returns>id of type int</returns>
        public override long GetItemId(int position)
        {
            return position;
        }

        /// <summary>
        /// Binds the user info to the view.
        /// </summary>
        /// <param name="position">position of the user in the list of type int</param>
        /// <param name="convertView">The row in the table view of type view</param>
        /// <param name="parent">Parent of type ViewGroup</param>
        /// <returns></returns>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(activityContext).Inflate(Resource.Layout.userinfo_row, null, false);
            }

            TextView firstNameTextView = row.FindViewById<TextView>(Resource.Id.firstName);
            TextView lastNameTextView = row.FindViewById<TextView>(Resource.Id.lastName);
            TextView ageTextView = row.FindViewById<TextView>(Resource.Id.age);

            firstNameTextView.Text = userInfo[position].FirstName;
            lastNameTextView.Text = userInfo[position].LastName;
            ageTextView.Text = userInfo[position].Age.ToString();

            return row;
        }
    }
}
