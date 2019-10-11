using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using MyUserListAndroid.Models;

namespace MyUserListAndroid
{
    public class UserListViewAdapter : BaseAdapter<UserInfo>
    {
        private List<UserInfo> userInfo;
        private Context activityContext;

        public UserListViewAdapter(Context context, List<UserInfo> userList)
        {
            userInfo = userList;
            activityContext = context;
        }

        public override UserInfo this[int position] => userInfo[position];

        public override int Count => userInfo.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

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
