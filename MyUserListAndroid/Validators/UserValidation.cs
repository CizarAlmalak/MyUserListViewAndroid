﻿using System.Text.RegularExpressions;

namespace MyUserListAndroid
{
    public class UserValidation : IValidate
    {
        /// <summary>
        /// Validates the password field, based on six conditions.
        /// </summary>
        /// <param name="password">Passed password of type string</param>
        /// <returns>Returns string resource id of type int</returns>
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

        /// <summary>
        /// Validate if the first name, last name and age fields are populated
        /// </summary>
        /// <param name="userInfo">The specific field of type string</param>
        /// <returns>Returns string resource id of type int</returns>
        public int ValidateUserInfoRequired(string userInfo)
        {
            return string.IsNullOrEmpty(userInfo) ? Resource.String.error_field_is_required : -1;
        }
    }
}
