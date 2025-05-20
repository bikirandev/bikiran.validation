using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Bikiran.Validation
{
    /// <summary>
    /// Provides string validation methods for various length and format scenarios
    /// </summary>
    public class ValString
    {
        /// <summary>
        /// Validates a string against length and character format requirements
        /// </summary>
        /// <param name="name">String to validate (nullable)</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <param name="min">Minimum allowed length (default: 2)</param>
        /// <param name="max">Maximum allowed length (default: 100)</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation checks:
        /// 1. Non-empty (after trimming)
        /// 2. Length between min and max
        /// 3. Matches character pattern: letters, numbers, spaces, and .,-() symbols
        /// Note: Error message mentions "alphanumeric" but allows additional symbols
        /// </remarks>
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

        /// <summary>
        /// Validates long text content with length constraints
        /// </summary>
        /// <param name="name">String to validate (nullable)</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <param name="min">Minimum allowed length (default: 2)</param>
        /// <param name="max">Maximum allowed length (default: 5000)</param>
        /// <param name="isOptional">When true, allows empty/null input (default: false)</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation checks:
        /// 1. Optional empty check (when isOptional=true)
        /// 2. Length between min and max (if provided)
        /// Note: Does not validate character patterns like IsValidString
        /// </remarks>
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
