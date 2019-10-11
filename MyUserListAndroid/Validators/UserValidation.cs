﻿using System;
using System.Text.RegularExpressions;
using Android.Content.Res;

namespace MyUserListAndroid
{
    public class UserValidation : IValidate
    {

        public int ValidatePassword(string password)
        {
            if (!Regex.IsMatch(password, @"^[a-zA-Z0-9]+$"))
            {
                return Resource.String.error_letters_and_number_only;
            }
            if (!(Regex.Matches(password, @"[a-zA-Z]").Count > 0))
            {
                return Resource.String.error_min_one_letter;
            }
            if (!(Regex.Matches(password, @"[0-9]").Count > 0))
            {
                return Resource.String.error_min_one_number;
            }
            if (!(password.Length >= 5 && password.Length <= 12))
            {
                return Resource.String.error_min_and_max_pass_length;
            }
            if (Regex.IsMatch(password, "(.{2,})\\1+"))
            {
                return Resource.String.error_repeat_char_sequence;
            }
            return -1;
        }

        public int ValidateUser(string userInfo)
        {
            return string.IsNullOrEmpty(userInfo) ? Resource.String.error_field_is_required : -1;
        }
    }
}