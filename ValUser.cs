using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bikiran.Validation
{
    public class ValUser
    {
        public static ValidateStatus IsValidUserNameFormat(string userName, string title)
        {
            //--Check is Username Format is valid
            if (userName == null || userName.Trim().Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            if (userName.Length < 5)
            {
                return new ValidateStatus { Error = true, Message = title + " should be minimum 5 characters long" };
            }

            if (userName.Length > 20)
            {
                return new ValidateStatus { Error = true, Message = title + " should be maximum 20 characters long" };
            }

            //--Define a regular expression pattern to match the username format
            string pattern = @"^[a-zA-Z0-9\.\-\@]+$";
            var st = Regex.IsMatch(userName, pattern);
            if (!st)
            {
                return new ValidateStatus { Error = true, Message = title + " should be alphanumeric or Dot(.), Hyphen(-), At the rate(@)" };
            }

            //--Check if username not starts with a letter
            if (!char.IsLetter(userName[0]))
            {
                return new ValidateStatus { Error = true, Message = title + " should start with a letter" };
            }

            //--Check if username not ends with a letter or number
            if (!char.IsLetterOrDigit(userName[^1]))
            {
                return new ValidateStatus { Error = true, Message = title + " should end with a letter or number" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        public static ValidateStatus IsValidPasswordFormat(string? password, string title = "Password")
        {
            if (password == null || password.Trim().Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            if (password.Length < 8)
            {
                return new ValidateStatus { Error = true, Message = title + " should be minimum 8 characters long" };
            }

            if (password.Length > 32)
            {
                return new ValidateStatus { Error = true, Message = title + " should be maximum 32 characters long" };
            }

            //--Define a regular expression pattern to match the password format
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,32}$";
            var st = Regex.IsMatch(password, pattern);
            if (!st)
            {
                return new ValidateStatus { Error = true, Message = title + " should contain at least one uppercase letter, one lowercase letter, one digit and one special character" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }
    }
}
