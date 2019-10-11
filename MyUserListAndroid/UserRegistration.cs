using System;
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
        private IValidate passValidation;
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
            submitButton.Click += onSubmit;

            firstName = FindViewById<TextInputEditText>(Resource.Id.firstNameInput);
            lastName = FindViewById<TextInputEditText>(Resource.Id.lastNameInput);
            age = FindViewById<TextInputEditText>(Resource.Id.ageInput);

            passwordInputField = FindViewById<TextInputEditText>(Resource.Id.passwordInput);
            passwordInputField.AddTextChangedListener(this);

            passValidation = new PasswordValidation();

            db = new DataBaseService();
            db.InitDataBase();
        }

        private void onSubmit(object sender, EventArgs eventArgs)
        {
            firstName.Error = string.IsNullOrEmpty(firstName.Text) ? "This field is required" : null;
            lastName.Error = string.IsNullOrEmpty(lastName.Text) ? "This field is required" : null;
            age.Error = string.IsNullOrEmpty(age.Text) ? "This field is required" : null;

            if (firstName.Error == null && lastName.Error == null && age.Error == null)
            {
                db.InsertTable(new Models.UserInfoTable
                {
                    FirstName = firstName.Text,
                    LastName = lastName.Text,
                    Age = Int32.Parse(age.Text)
                });
                Finish();
            }
        }

        public void AfterTextChanged(IEditable s)
        {
            //
        }

        public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {
            //
        }

        public void OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            passwordInputField.Error = passValidation.Validate(s.ToString());
            submitButton.Enabled |= passwordInputField.Error == null;
        }
    }
}