using System;

namespace Bikiran.Validation
{
    /// <summary>
    /// Represents the validation result status
    /// </summary>
    public class ValidateStatus
    {

        /// <summary>
        /// Indicates if validation failed
        /// </summary>
        public bool Error { get; set; } = true;

        /// <summary>
        /// Message describing validation result
        /// </summary>
        public string Message { get; set; } = "Initial Error";

        /// <summary>
        /// Index of the error in the list of options
        /// </summary>
        public int ErrorIndex { get; set; } = 0;
    }
}