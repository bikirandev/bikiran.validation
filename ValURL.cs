using System;
using System.Text.RegularExpressions;

namespace Bikiran.Validation
{
    public class ValURL
    {
        public static ValidateStatus IsValidUrlFormat(string? logoUrl, string title, bool isOptional = false)
        {
            if (string.IsNullOrEmpty(logoUrl) && isOptional)
            {
                return new ValidateStatus { Error = false, Message = "Optional" };
            }


            // Check if the URL is null or empty
            if (string.IsNullOrWhiteSpace(logoUrl))
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            // Updated pattern to allow localhost with ports and optional paths
            //             = @"^((http|https):\/\/)?([\w-]+\.)+[\w-]+(\/[\w- .\/?%&=]*)?$";
            string pattern = @"^(http|https):\/\/(localhost(:\d+)?|([\w-]+\.)+[\w-]+)(\/[\w- .\/?%&=]*)?$";
            bool isValid = Regex.IsMatch(logoUrl, pattern, RegexOptions.IgnoreCase);

            if (!isValid)
            {
                return new ValidateStatus { Error = true, Message = title + " is not valid" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }
    }
}
