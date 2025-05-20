using System;
using System.Text.RegularExpressions;

namespace Bikiran.Validation
{
    public class ValEmail
    {
        public static ValidateStatus IsValidEmailFormat(string? email, string title, string postText = "")
        {
            if (email == null || email.Trim().Length == 0)
            {
                return new ValidateStatus { Error = true, Message = $"Please enter {title}. {postText}" };
            }

            if (email.Length < 6)
            {
                return new ValidateStatus { Error = true, Message = $"{title} should be minimum 3 characters long. {postText}" };
            }

            if (email.Length > 200)
            {
                return new ValidateStatus { Error = true, Message = $" {title} should be maximum 200 characters long. {postText}" };
            }

            // Define a regular expression pattern to match the email format
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            var st = Regex.IsMatch(email, pattern);
            if (!st)
            {
                return new ValidateStatus { Error = true, Message = $"Please enter valid {title}. {postText}" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        public static ValidateStatus IsValidEmailFormatAll(List<string> email, string title)
        {
            var validateAll = email.Select(x => IsValidEmailFormat(x, title, $"({x})")).ToList();

            return ValAll.ValidateAll(validateAll);
        }
    }
}
