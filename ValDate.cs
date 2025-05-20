using System;
using System.Text.RegularExpressions;

namespace Bikiran.Validation
{
    /// <summary>
    /// Provides date validation methods for common validation scenarios
    /// </summary>
    public class ValDate
    {
        /// <summary>
        /// Validates if a string is in YYYY-MM-DD format and non-empty
        /// </summary>
        /// <param name="date">The date string to validate (nullable)</param>
        /// <param name="title">Field name to use in error messages (default: "Date")</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Performs two checks:
        /// 1. Checks if the input is non-empty
        /// 2. Validates format against YYYY-MM-DD pattern using regular expression
        /// Note: This validation only checks format validity, not calendar correctness.
        /// For example, "2023-02-30" would pass format check but is not a valid date.
        /// </remarks>
        public static ValidateStatus IsValidDateFormat(string? date, string title = "Date")
        {
            if (string.IsNullOrEmpty(date) || date.Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            // Define a regular expression pattern to match the YYYY-MM-DD format
            string pattern = @"^\d{4}-\d{2}-\d{2}$";
            var st = Regex.IsMatch(date, pattern);
            if (!st)
            {
                return new ValidateStatus { Error = true, Message = "Please enter valid " + title };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }
    }
}