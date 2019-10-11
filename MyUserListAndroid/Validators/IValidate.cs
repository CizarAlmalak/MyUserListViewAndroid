using System;
namespace MyUserListAndroid
{
    public interface IValidate
    {
        int ValidatePassword(string password);
        int ValidateUser(string userInfo);
    }
}
