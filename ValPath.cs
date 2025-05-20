using System;
using System.Text.RegularExpressions;

namespace Bikiran.Validation
{
    public class ValPath
    {
        public static ValidateStatus IsValidPathPattern(string sourceDir, string title)
        {
            if (sourceDir == null || sourceDir.Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            // Define a regular expression pattern to match the path format
            string pattern = @"^([a-zA-Z]:\\)?[^<>:""/\\|?*]+$";
            var st = Regex.IsMatch(sourceDir, pattern);
            if (!st)
            {
                return new ValidateStatus { Error = true, Message = title + " is not valid" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }
    }
}
