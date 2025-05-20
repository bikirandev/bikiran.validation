using System;
using System.Text.RegularExpressions;

#nullable enable

namespace Bikiran.Validation
{

    /// <summary>
    /// Provides URL validation methods for format verification
    /// </summary>
    public class ValURL
    {
        /// <summary>
        /// Validates a URL format including support for localhost and optional paths
        /// </summary>
        /// <param name="logoUrl">URL to validate (nullable string)</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <param name="isOptional">When true, allows empty/null input (default: false)</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation checks:
        /// 1. Optional empty handling when isOptional=true
        /// 2. Non-empty check for required URLs
        /// 3. Matches URL pattern using regular expression:
        ///    - Requires http/https protocol
        ///    - Allows localhost with port numbers
        ///    - Valid domain names
        ///    - Optional paths and query parameters
        ///    - Case-insensitive validation
        /// Note: Validates format only, not accessibility or existence of the resource.
        /// </remarks>
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
