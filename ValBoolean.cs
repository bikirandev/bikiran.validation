using System;

#nullable enable

namespace Bikiran.Validation
{
    /// <summary>
    /// Provides boolean validation methods for common validation scenarios
    /// </summary>
    public class ValBoolean
    {
        /// <summary>
        /// Validates if two string values are equal when the first value is non-empty
        /// </summary>
        /// <param name="val1">First value to compare (nullable string)</param>
        /// <param name="val2">Second value to compare</param>
        /// <param name="failedMessage">Message to return if validation fails</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation only occurs if val1 is not null and not empty. Returns error when:
        /// - val1 has content AND
        /// - val1 does not match val2
        /// </remarks>
        public static ValidateStatus IsEqual(string? val1, string? val2, string failedMessage)
        {
            if (val1 != null && val1.Length != 0 && val1 != val2)
            {
                return new ValidateStatus { Error = true, Message = failedMessage };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        /// <summary>
        /// Validates if a boolean value is true
        /// </summary>
        /// <param name="val">Value to check</param>
        /// <param name="failedMessage">Message to return if validation fails</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Returns error when the value is false
        /// </remarks>
        public static ValidateStatus IsTrue(bool val, string failedMessage)
        {
            if (!val)
            {
                return new ValidateStatus { Error = true, Message = failedMessage };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        /// <summary>
        /// Validates if two string values are not equal when the first value is non-empty
        /// </summary>
        /// <param name="val1">First value to compare (nullable string)</param>
        /// <param name="val2">Second value to compare</param>
        /// <param name="successMessage">Message to return if validation fails (values match)</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation only occurs if val1 is not null and not empty. Returns error when:
        /// - val1 has content AND
        /// - val1 matches val2
        /// </remarks>
        public static ValidateStatus IsFalse(string? val1, string? val2, string successMessage)
        {
            if (val1 != null && val1.Length != 0 && val1 == val2)
            {
                return new ValidateStatus { Error = true, Message = successMessage };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }
    }
}
#nullable restore