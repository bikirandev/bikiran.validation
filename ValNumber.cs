using System;

namespace Bikiran.Validation
{
    /// <summary>
    /// Provides numeric validation methods for range and validity checks
    /// </summary>
    public class ValNumber
    {
        /// <summary>
        /// Validates an integer value against optional range constraints
        /// </summary>
        /// <param name="number">Integer value to validate</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <param name="min">Optional minimum allowed value</param>
        /// <param name="max">Optional maximum allowed value</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation checks:
        /// 1. NaN check (though int cannot be NaN in C#)
        /// 2. Minimum value check if provided
        /// 3. Maximum value check if provided
        /// Note: The NaN check is redundant for integers in C# as they cannot represent NaN values
        /// </remarks>
        public static ValidateStatus IsValidateInt(int number, string title, int? min = null, int? max = null)
        {
            if (double.IsNaN(number))
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            if (min != null && number < min)
            {
                return new ValidateStatus { Error = true, Message = title + " should be minimum " + min };
            }

            if (max != null && number > max)
            {
                return new ValidateStatus { Error = true, Message = title + " should be maximum " + max };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        /// <summary>
        /// Validates a double-precision number against optional range constraints
        /// </summary>
        /// <param name="number">Double value to validate</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <param name="min">Optional minimum allowed value (nullable double)</param>
        /// <param name="max">Optional maximum allowed value (nullable double)</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation checks:
        /// 1. NaN check (using double.IsNaN)
        /// 2. Minimum value check if provided
        /// 3. Maximum value check if provided
        /// Properly handles floating-point special values and comparisons
        /// </remarks>
        public static ValidateStatus IsValidateNumber(double number, string title, double? min = null, double? max = null)
        {
            if (double.IsNaN(number))
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            if (min != null && number < min)
            {
                return new ValidateStatus { Error = true, Message = title + " should be minimum " + min };
            }

            if (max != null && number > max)
            {
                return new ValidateStatus { Error = true, Message = title + " should be maximum " + max };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }
    }
}