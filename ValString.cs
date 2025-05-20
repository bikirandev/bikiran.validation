using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Bikiran.Validation
{
    public class ValString
    {
        public static ValidateStatus IsValidString(string? name, string title, int min = 2, int max = 100)
        {
            if (name == null || name.Trim().Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            if (name.Length < min)
            {
                return new ValidateStatus { Error = true, Message = title + " should be minimum " + min + " character long" };
            }

            if (name.Length > max)
            {
                return new ValidateStatus { Error = true, Message = title + " should be maximum " + max + " character long" };
            }

            //--Define a regular expression pattern to match the name format win a min and max length
            string pattern = @"^[a-zA-Z0-9\s\.\- ,\(\)]+$";
            var st = Regex.IsMatch(name, pattern);
            if (!st)
            {
                return new ValidateStatus { Error = true, Message = title + " should be alphanumeric" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        public static ValidateStatus IsValidLongString(string? name, string title, int min = 2, int max = 5000, bool isOptional = false)
        {
            if (isOptional && (name == null || name.Trim().Length == 0))
            {
                return new ValidateStatus { Error = false, Message = "Success" };
            }

            if (name == null || name.Trim().Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            if (name.Length < min)
            {
                return new ValidateStatus { Error = true, Message = title + " should be minimum " + min + " character long" };
            }

            if (name.Length > max)
            {
                return new ValidateStatus { Error = true, Message = title + " should be maximum " + max + " character long" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }
    }
}
