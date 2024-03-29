﻿using System;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Text;
using Android.Widget;
using Java.Lang;

namespace MyUserListAndroid
{
    [Activity(Label = "Registration", Theme = "@style/AppTheme.NoActionBar")]
    public class UserRegistration : AppCompatActivity, ITextWatcher
    {
        private IValidate userValidation;
        private TextInputEditText firstName;
        private TextInputEditText lastName;
        private TextInputEditText age;
        private TextInputEditText passwordInputField;
        private Button submitButton;
        private DataBaseService db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.user_registration);

            submitButton = FindViewById<Button>(Resource.Id.submitButton);
            submitButton.Click += OnSubmit;

            firstName = FindViewById<TextInputEditText>(Resource.Id.firstNameInput);
            lastName = FindViewById<TextInputEditText>(Resource.Id.lastNameInput);
            age = FindViewById<TextInputEditText>(Resource.Id.ageInput);

            passwordInputField = FindViewById<TextInputEditText>(Resource.Id.passwordInput);
            passwordInputField.AddTextChangedListener(this);

            userValidation = new UserValidation();

            db = DataBaseService.Instance;
        }

        private void OnSubmit(object sender, EventArgs eventArgs)
        {
            firstName.Error = GetStringResource(userValidation.ValidateUserInfoRequired(firstName.Text));
            lastName.Error = GetStringResource(userValidation.ValidateUserInfoRequired(lastName.Text));
            age.Error = GetStringResource(userValidation.ValidateUserInfoRequired(age.Text));

            int validAge;
            try
            {
                validAge = Int32.Parse(age.Text);
            }
            catch
            {
                validAge = 0;
            }

            if (firstName.Error == null && lastName.Error == null && age.Error == null)
            {
                db.InsertTable(new Models.UserInfoTable
                {
                    FirstName = firstName.Text,
                    LastName = lastName.Text,
                    Age = validAge
                });
                Finish();
            }
        }

        private string GetStringResource(int resourceId)
        {

            return resourceId != -1 ? this.Resources.GetString(resourceId) : null;
        }

        /// <summary>
        /// Event fires when text has changes on the password field
        /// </summary>
        /// <param name="s">The input text of type ICharSequence</param>
        /// <param name="start">The start position of type int</param>
        /// <param name="before"></param>
        /// <param name="count">Length of string</param>
        public void OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            passwordInputField.Error = GetStringResource(userValidation.ValidatePassword(s.ToString()));
            submitButton.Enabled |= passwordInputField.Error == null;
        }

        /// <summary>
        /// Event fires before the text is changed
        /// </summary>
        /// <param name="s"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <param name="after"></param>
        public void BeforeTextChanged(ICharSequence s, int start, int count, int after){}

        /// <summary>
        /// Event fires when text has changed
        /// </summary>
        /// <param name="s"></param>
        public void AfterTextChanged(IEditable s) { }
    }
}