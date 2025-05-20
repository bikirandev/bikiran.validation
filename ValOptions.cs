using System;

namespace Bikiran.Validation
{
    /// <summary>
    /// Provides validation methods for option selection scenarios
    /// </summary>
    public class ValOptions
    {
        /// <summary>
        /// Validates a string option against allowed values
        /// </summary>
        /// <param name="option">Option value to validate (nullable string)</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <param name="validOptions">List of allowed values (optional)</param>
        /// <param name="postText">Additional text to append to error messages</param>
        /// <param name="isOptional">When true, allows empty/null input (default: false)</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation checks:
        /// 1. Empty/null check (unless optional)
        /// 2. Validation against allowed values list (if provided)
        /// Special cases:
        /// - Returns "Optional" message when valid and optional
        /// - Empty string considered invalid when not optional
        /// </remarks>
        public static ValidateStatus IsValidateOptions(string? option, string title, List<string>? validOptions = null, string postText = "", bool isOptional = false)
        {
            if (option == null || option.Length == 0)
            {
                if (isOptional)
                {
                    return new ValidateStatus { Error = false, Message = "Optional" };
                }

                return new ValidateStatus { Error = true, Message = $"Please select {title}. {postText}" };
            }

            if (validOptions != null && !validOptions.Contains(option))
            {
                return new ValidateStatus { Error = true, Message = $"{title} is not valid. {postText}" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        /// <summary>
        /// Validates an integer option against allowed values
        /// </summary>
        /// <param name="option">Option value to validate (nullable int)</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <param name="validOptions">List of allowed integer values (optional)</param>
        /// <param name="postText">Additional text to append to error messages</param>
        /// <param name="isOptional">When true, allows null/zero input (default: false)</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation checks:
        /// 1. Null/zero check (unless optional)
        /// 2. Validation against allowed values list (if provided)
        /// Note: Treats 0 as empty value for integer options
        /// </remarks>
        public static ValidateStatus IsValidateOptions(int? option, string title, List<int>? validOptions = null, string postText = "", bool isOptional = false)
        {
            if (option == null || option == 0)
            {
                if (isOptional)
                {
                    return new ValidateStatus { Error = false, Message = "Optional" };
                }

                return new ValidateStatus { Error = true, Message = $"Please select {title}. {postText}" };
            }

            if (validOptions != null && !validOptions.Contains(option ?? 0))
            {
                return new ValidateStatus { Error = true, Message = $"{title} is not valid. {postText}" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        /// <summary>
        /// Validates multiple string options against allowed values
        /// </summary>
        /// <param name="options">List of options to validate</param>
        /// <param name="validOptions">List of allowed values</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <returns><see cref="ValidateStatus"/> object containing combined validation result</returns>
        /// <remarks>
        /// Validation rules:
        /// 1. Validates each option using <see cref="IsValidateOptions"/>
        /// 2. Appends specific option value to error messages
        /// 3. Uses <see cref="ValAll.ValidateAll"/> to aggregate results
        /// Returns success only if all options are valid
        /// </remarks>
        public static ValidateStatus IsValidateOptionsAll(List<string> options, List<string> validOptions, string title)
        {
            var valAll = options.Select(x => IsValidateOptions(x, title, validOptions, $"({x})")).ToList();

            return ValAll.ValidateAll(valAll);
        }
    }
}