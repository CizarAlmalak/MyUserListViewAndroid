﻿namespace MyUserListAndroid
{
    /*
     * interface for the validation of the
     * user info input fields
     * @param: password of type string
     * @param: user name/age of type string
     */
    public interface IValidate
    {
        int ValidatePassword(string password);
        int ValidateUserInfoRequired(string userInfo);
    }
}
