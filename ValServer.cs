using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

#nullable enable

namespace Bikiran.Validation
{
    /// <summary>
    /// Provides server-related validation methods for server names and configurations
    /// </summary>
    public class ValServer
    {
        /// <summary>
        /// Validates server name format against naming conventions
        /// </summary>
        /// <param name="serverName">Server name to validate</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <param name="min">Minimum length requirement (default: 5)</param>
        /// <param name="max">Maximum length requirement (default: 32)</param>
        /// <param name="specialCharacter">Allowed special characters (default: "-_")</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation checks:
        /// 1. Non-empty (after trimming)
        /// 2. Length between min-max characters
        /// 3. Allowed characters: letters (a-z), numbers (0-9), and specified special characters
        /// 4. Must start with a letter or number
        /// 5. Must end with a letter or number
        /// Note: Special characters are allowed in the middle but not at start or end
        /// </remarks>
        public static ValidateStatus IsValidServerNameFormat(string? serverName, string title, int min = 5, int max = 32, string specialCharacter = "-_")
        {
            //--Check if server name is null or empty
            if (serverName == null || serverName.Trim().Length == 0)
            {
                return new ValidateStatus { Error = true, Message = $"Please enter {title}" };
            }

            //--Check minimum length
            if (serverName.Length < min)
            {
                return new ValidateStatus { Error = true, Message = $"{title} should be minimum {min} characters long" };
            }

            //--Check maximum length
            if (serverName.Length > max)
            {
                return new ValidateStatus { Error = true, Message = $"{title} should be maximum {max} characters long" };
            }

            //--Escape special characters for regex pattern
            string escapedSpecialChars = Regex.Escape(specialCharacter);

            //--Define regex pattern to match the server name format
            string pattern = $@"^[a-zA-Z0-9{escapedSpecialChars}]+$";
            var st = Regex.IsMatch(serverName, pattern);
            if (!st)
            {
                return new ValidateStatus { Error = true, Message = $"{title} should contain only alphanumeric characters or special characters ({specialCharacter})" };
            }

            //--Check if server name starts with a special character
            if (specialCharacter.Contains(serverName[0]))
            {
                return new ValidateStatus { Error = true, Message = $"{title} should not start with a special character" };
            }

            //--Check if server name ends with a special character
            if (specialCharacter.Contains(serverName[^1]))
            {
                return new ValidateStatus { Error = true, Message = $"{title} should not end with a special character" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }
    }
}
