using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Widget;
using MyUserListAndroid.Models;

namespace MyUserListAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private List<UserInfo> userList;
        private ListView userListView;
        private DataBaseService db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.SetImageResource(Resource.Drawable.plus_black);
            fab.Click += FabOnClick;

            userListView = FindViewById<ListView>(Resource.Id.userListView);
            userListView.DividerHeight = 0;
        }

        protected override void OnResume()
        {
            base.OnResume();

            db = DataBaseService.Instance;
            userList = db.getUserInfo();

            if (userList != null)
            {
                UserListViewAdapter adapter = new UserListViewAdapter(this, userList);
                userListView.Adapter = adapter;
            }

        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            var intent = new Intent(this, typeof(UserRegistration));
            StartActivity(intent);
        }
    }
}

