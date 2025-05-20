using System;
using System.Text.RegularExpressions;

namespace Bikiran.Validation
{
    /// <summary>
    /// Provides validation methods for file path format verification
    /// </summary>
    public class ValPath
    {
        /// <summary>
        /// Validates a Windows file path format against invalid characters and basic structure
        /// </summary>
        /// <param name="sourceDir">Path string to validate</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation checks:
        /// 1. Non-empty input
        /// 2. Matches path pattern using regular expression:
        ///    - Optional drive letter (e.g., "C:\")
        ///    - No invalid characters: &lt;&gt;:"/\|?*
        ///    - No trailing backslash
        /// Note: This validation checks format only, not path existence or system accessibility.
        /// The pattern allows local paths but doesn't validate network/UNC paths.
        /// </remarks>
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
