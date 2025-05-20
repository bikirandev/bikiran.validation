using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

#nullable enable


namespace Bikiran.Validation
{
    /// <summary>
    /// Provides email validation methods for email format verification
    /// </summary>
    public class ValEmail
    {
        /// <summary>
        /// Validates the format of a single email address
        /// </summary>
        /// <param name="email">Email address to validate (nullable)</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <param name="postText">Additional text to append to error messages (optional)</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Performs three checks:
        /// 1. Non-empty validation
        /// 2. Length check (6-200 characters)
        /// 3. Format validation using regular expression:
        ///    - Allows alphanumerics, underscores, dots and hyphens before @
        ///    - Requires domain parts with valid characters
        ///    - Top-level domain (2-4 characters)
        /// Note: This simplified pattern may not cover all RFC-compliant email addresses.
        /// The error message for minimum length references 3 characters while enforcing 6 character minimum.
        /// </remarks>
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

        /// <summary>
        /// Validates format for multiple email addresses in a list
        /// </summary>
        /// <param name="email">List of emails to validate</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <returns><see cref="ValidateStatus"/> object containing combined validation result</returns>
        /// <remarks>
        /// Validation rules:
        /// 1. Validates each email using <see cref="IsValidEmailFormat"/>
        /// 2. Appends specific email to error messages using postText parameter
        /// 3. Uses <see cref="ValidateBasic.ValidateAll"/> to aggregate results
        /// Returns success only if all emails are valid
        /// </remarks>
        public static ValidateStatus IsValidEmailFormatAll(List<string> email, string title)
        {
            var validateAll = email.Select(x => IsValidEmailFormat(x, title, $"({x})")).ToList();

            return ValidateBasic.ValidateAll(validateAll);
        }
    }
}