using System;
using System.IO;

namespace Bikiran.Validation
{
    /// <summary>
    /// Provides validation methods for file path format verification.
    /// </summary>
    public class ValPath
    {
        /// <summary>
        /// Validates a Windows or Linux file path format for syntactic correctness.
        /// </summary>
        /// <param name="path">Path string to validate.</param>
        /// <param name="title">Field name to use in error messages.</param>
        /// <returns><see cref="ValidateStatus"/> object containing the validation result.</returns>
        /// <remarks>
        /// This method provides a robust, cross-platform validation for path formats.
        /// It checks for invalid characters and ensures the path conforms to the structural
        /// rules of the underlying operating system (Windows/Linux).
        ///
        /// Note: This method validates format and syntax, not whether the file or directory actually exists.
        /// </remarks>
        public static ValidateStatus IsValidPath(string path, string title = "Path")
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return new ValidateStatus { Error = true, Message = $"Please enter {title}." };
            }

            // Step 1: A quick check for characters that are invalid in *any* path on the current OS.
            // This is a fast and reliable first-pass filter.
            try
            {
                if (path.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
                {
                    return new ValidateStatus { Error = true, Message = $"{title} contains invalid characters." };
                }
            }
            catch (Exception)
            {
                // Path.GetInvalidPathChars() can, in rare cases, throw.
                return new ValidateStatus { Error = true, Message = $"{title} is not a valid path." };
            }


            // Step 2: A definitive structural check using the .NET runtime's logic.
            // Using a try-catch block with Path.GetFullPath is the most reliable way to validate
            // complex rules like Windows drive letters ("C:\") vs. invalid formats ("C:path")
            // and UNC paths ("\\server\share"). It is inherently cross-platform.
            try
            {
                // This call will throw exceptions for various malformed path issues,
                // which we can catch to determine invalidity.
                Path.GetFullPath(path);
            }
            catch (ArgumentException)
            {
                // Catches errors like empty paths or paths with illegal characters.
                return new ValidateStatus { Error = true, Message = $"{title} contains invalid characters." };
            }
            catch (NotSupportedException)
            {
                // This is a key error, catching paths with an invalid format, such as "C:badpath" on Windows.
                return new ValidateStatus { Error = true, Message = $"{title} has an invalid format." };
            }
            catch (PathTooLongException)
            {
                return new ValidateStatus { Error = true, Message = $"{title} is too long." };
            }
            catch (Exception)
            {
                // Catch any other unexpected exceptions during path validation.
                return new ValidateStatus { Error = true, Message = $"{title} is not a valid path." };
            }

            // If all checks pass, the path format is considered syntactically valid for the current OS.
            return new ValidateStatus { Error = false, Message = "Success" };
        }
    }
}