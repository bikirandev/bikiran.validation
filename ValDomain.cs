using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

#nullable enable


namespace Bikiran.Validation
{
    /// <summary>
    /// Provides domain validation methods for domain name format verification
    /// </summary>
    public class ValDomain
    {
        /// <summary>
        /// Validates the format of a single domain name
        /// </summary>
        /// <param name="domainName">Domain name to validate (nullable)</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <param name="isOptional">When true, allows null or empty input (default: false)</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation rules:
        /// 1. If optional and empty: returns valid
        /// 2. Non-optional empty: returns error
        /// 3. Validates against domain format pattern:
        ///    - Starts with alphanumeric
        ///    - Allows hyphens except at start/end
        ///    - Minimum 2-character TLD
        ///    - Valid subdomain structure
        /// Does not verify actual domain existence, only format validity.
        /// </remarks>
        public static ValidateStatus IsValidDomainFormat(string? domainName, string title, bool isOptional = false)
        {
            if (isOptional && (domainName == null || domainName.Length == 0))
            {
                return new ValidateStatus { Error = false, Message = "Success" };
            }

            //--VerifyAsync Valid Domain Format
            if (domainName == null || domainName.Trim().Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            //--Define a regular expression pattern to match the domain format
            string pattern = @"^([a-zA-Z0-9][a-zA-Z0-9\-]{0,61}[a-zA-Z0-9]\.)+[a-zA-Z]{2,}$";
            var st = Regex.IsMatch(domainName, pattern);
            if (!st)
            {
                return new ValidateStatus { Error = true, Message = title + " is not valid" };
            }

            return new ValidateStatus { Error = false, Message = title + " is Valid" };
        }

        /// <summary>
        /// Validates format for multiple domain names in a list
        /// </summary>
        /// <param name="domainName">List of domains to validate (nullable)</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <param name="isOptional">When true, allows null or empty list (default: false)</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation rules:
        /// 1. If optional and empty list: returns valid
        /// 2. Non-optional empty list: returns error
        /// 3. Validates each domain using <see cref="IsValidDomainFormat"/>
        /// 4. Returns first invalid domain with error message
        /// 5. All domains must be valid for success
        /// </remarks>
        public static ValidateStatus IsValidDomainFormatAll(List<string>? domainName, string title, bool isOptional = false)
        {
            if (isOptional && (domainName == null || domainName.Count == 0))
            {
                return new ValidateStatus { Error = false, Message = "Success" };
            }

            if (domainName == null || domainName.Count == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            foreach (var domain in domainName)
            {
                var st = IsValidDomainFormat(domain, title);
                if (st.Error)
                {
                    st.Message = st.Message + ": " + domain;
                    return st;
                }
            }

            return new ValidateStatus { Error = false, Message = title + " is Valid" };
        }
    }
}