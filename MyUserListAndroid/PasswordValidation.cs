using System;
using System.Text.RegularExpressions;

namespace MyUserListAndroid
{
    public class PasswordValidation : IValidate
    {

        public string Validate(string password)
        {
            Console.WriteLine(password);
            if (!Regex.IsMatch(password, @"^[a-zA-Z0-9]+$"))
            {
                return "Only letters and numbers are allowed";
            }
            if (!(Regex.Matches(password, @"[a-zA-Z]").Count > 0))
            {
                return "Password has to have at least 1 letter";
            }
            if (!(Regex.Matches(password, @"[0-9]").Count > 0))
            {
                return "Password has to have at least 1 number";
            }
            if (!(password.Length >= 5 && password.Length <= 12))
            {
                return "Password has to be 5-12 characters long";
            }
            if (Regex.IsMatch(password, "(.{2,})\\1+"))
            {
                return "Repeated sequences are not allowed";
            }
            return null;
        }
    }
}
