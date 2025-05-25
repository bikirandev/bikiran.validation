using System;
using System.Text.RegularExpressions;

#nullable enable

namespace Bikiran.Validation
{
    /// <summary>
    /// Provides user credential validation methods for username and password formats
    /// </summary>
    public class ValUser
    {
        /// <summary>
        /// Validates username format against security requirements
        /// </summary>
        /// <param name="userName">Username to validate</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation checks:
        /// 1. Non-empty (after trimming)
        /// 2. Length between 5-20 characters
        /// 3. Allowed characters: letters, numbers, ., -, @
        /// 4. Starts with a letter
        /// 5. Ends with letter/number
        /// Note: Special characters .-@ are allowed but not required
        /// </remarks>
        public static ValidateStatus IsValidUserNameFormat(string userName, string title, int min = 5, int max = 20)
        {
            //--Check is Username Format is valid
            if (userName == null || userName.Trim().Length == 0)
            {
                return new ValidateStatus { Error = true, Message = $"Please enter {title}" };
            }

            if (userName.Length < min)
            {
                return new ValidateStatus { Error = true, Message = $"{title} should be minimum {min} characters long" };
            }

            if (userName.Length > max)
            {
                return new ValidateStatus { Error = true, Message = $"{title} should be maximum {max} characters long" };
            }

            //--Define a regular expression pattern to match the username format
            string pattern = @"^[a-zA-Z0-9\.\-\@]+$";
            var st = Regex.IsMatch(userName, pattern);
            if (!st)
            {
                return new ValidateStatus { Error = true, Message = title + $"{title} should be alphanumeric or Dot(.), Hyphen(-), At the rate(@)" };
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

        /// <summary>
        /// Validates password format against complexity requirements
        /// </summary>
        /// <param name="password">Password to validate (nullable)</param>
        /// <param name="title">Field name to use in error messages (default: "Password")</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation checks:
        /// 1. Non-empty (after trimming)
        /// 2. Length between 8-32 characters
        /// 3. Contains at least:
        ///    - One uppercase letter
        ///    - One lowercase letter
        ///    - One digit
        ///    - One special character
        /// Special characters: Any non-alphanumeric Unicode character
        /// </remarks>
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